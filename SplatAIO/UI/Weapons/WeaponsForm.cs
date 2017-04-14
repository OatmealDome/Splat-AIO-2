using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.Weapons;
using SplatAIO.Logic.Memory;
using SplatAIO.Properties;
using System;
using System.Windows.Forms;

namespace SplatAIO.UI.Weapons
{
    public partial class WeaponsForm : Form
    {
        private WeaponsHax WeaponsHax { get; set; }

        private readonly SingleAssemblyComponentResourceManager weaponEditFormResources =
            new SingleAssemblyComponentResourceManager(typeof(WeaponEditForm));
        
        public WeaponsForm()
        {
            InitializeComponent();

            WeaponsHax = new WeaponsHax(TCPGecko.Instance(), MemoryUtils.Offset);
            ReloadWeaponsList();
        }

        private void ReloadWeaponsList()
        {
            WeaponsHax.ReloadWeapons();
            // reload the list
            ReloadListBox();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            WeaponsHax.PokeWeapons();
        }
        
        private void ReloadListBox()
        {
            weaponsList.Items.Clear();

            foreach (var weapon in WeaponsHax.Weapons)
            {
                string name = "";
                var index = WeaponDatabase.GetIndex(weapon.Id);
                if (index == 0)
                {
                    name = weaponEditFormResources.GetString("weaponBox.Items");
                }                    
                else
                {
                    name = weaponEditFormResources.GetString("weaponBox.Items" + index);
                }
                if (weapon.Id.Equals(WeaponsHax.EquippedWeapon))
                {
                    name += " " + Strings.EQUIPPED;
                }
                weaponsList.Items.Add(name);
            }
        }

        private void equipBox_Click(object sender, EventArgs e)
        {
            if (weaponsList.SelectedIndex != -1)
            {
                WeaponsHax.SetEquippedWeapon(weaponsList.SelectedIndex);
                ReloadListBox();
            }
        }

        private void addBox_Click(object sender, EventArgs e)
        {
            var editForm = new WeaponEditForm();
            editForm.ShowDialog(this);

            if (editForm.Weapon != null)
            {
                WeaponsHax.AddWeapon(editForm.Weapon);
                ReloadListBox();
            }
        }

        private void weaponsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                weaponsList.SelectedIndex = weaponsList.IndexFromPoint(e.Location);
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WeaponEditForm(WeaponsHax.GetWeapon(weaponsList.SelectedIndex), WeaponsHax.Weapons)
                .ShowDialog(this);

            ReloadListBox();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var weapon = WeaponsHax.GetWeapon(weaponsList.SelectedIndex);

            if (weapon.Id.Equals(WeaponsHax.DefaultWeapon))
            {
                // refuse to remove the Splattershot Jr.
                MessageBox.Show(Strings.CANNOT_REMOVE_JR_TEXT);
            }
            else
            {
                // check if the removed weapon is currently equipped
                if (weapon.Id.Equals(WeaponsHax.EquippedWeapon))
                {
                    WeaponsHax.EquipDefaultWeapon();
                }
                WeaponsHax.RemoveWeapon(weapon);
                ReloadListBox();
            }
        }
    }
}