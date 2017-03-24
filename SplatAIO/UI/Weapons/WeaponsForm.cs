using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Memory.Addresses;
using SplatAIO.Logic.Weapons;
using SplatAIO.Properties;

namespace SplatAIO.UI.Weapons
{
    public partial class WeaponsForm : Form
    {
        private readonly TCPGecko gecko;
        private readonly uint offset;

        private readonly SingleAssemblyComponentResourceManager weaponEditFormResources =
            new SingleAssemblyComponentResourceManager(typeof(WeaponEditForm));

        public readonly List<Weapon> weapons = new List<Weapon>();
        private uint equippedWeapon;

        public WeaponsForm(TCPGecko gecko, uint offset)
        {
            InitializeComponent();

            this.gecko = gecko;
            this.offset = offset;

            ReloadWeaponsList();
        }

        private void ReloadWeaponsList()
        {
            weapons.Clear();

            equippedWeapon = gecko.peek((uint) Gear.EquippedWeapon + offset);

            // dump all weapon save slots
            var weaponData = SplatAIOForm.DumpSaveSlots(gecko, offset, (uint) Gear.Weapons, 5120);

            // read data from slots
            var j = 0;
            while (j < weaponData.Length)
            {
                var id = weaponData[j];

                // check if an empty save slot
                if (id == 0xFFFFFFFF)
                    break;

                var number = weaponData[j + 1];
                var sub = (SubWeapon) weaponData[j + 2];
                var special = (SpecialWeapon) weaponData[j + 3];
                var turfInked = weaponData[j + 4];
                var timestamp = weaponData[j + 7];
                var newFlag = weaponData[j + 8] == 0x0;

                weapons.Add(new Weapon(id, number, sub, special, turfInked, timestamp, newFlag));

                // move to next slot
                j += 10;
            }

            // reload the list
            ReloadListBox();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            // poke weapons into memory
            PokeWeapons(weapons, gecko, offset);

            // poke the equipped weapon
            gecko.poke32((uint) Gear.EquippedWeapon, equippedWeapon);
        }

        public static void PokeWeapons(List<Weapon> weapons, TCPGecko gecko, uint offset)
        {
            var currentPosition = (uint) Gear.Weapons + offset;
            foreach (var weapon in weapons)
            {
                gecko.poke32(currentPosition, weapon.id);
                gecko.poke32(currentPosition + 0x4, weapon.weaponSpecificNumber);
                gecko.poke32(currentPosition + 0x8, (uint) weapon.subWeapon);
                gecko.poke32(currentPosition + 0xc, (uint) weapon.specialWeapon);
                gecko.poke32(currentPosition + 0x10, weapon.turfInked);
                gecko.poke32(currentPosition + 0x18, weapon.lastUsageTimestamp);

                if (weapon.isNew)
                    gecko.poke32(currentPosition + 0x1c, 0x0);
                else
                    gecko.poke32(currentPosition + 0x1c, 0x00010000);

                // move to next slot
                currentPosition += 0x28;
            }

            // fill the rest of the slots with dummy data
            for (var i = weapons.Count; i < 128; i++)
            {
                gecko.poke32(currentPosition, 0xFFFFFFFF);
                gecko.poke32(currentPosition + 0x4, 0xFFFFFFFF);
                gecko.poke32(currentPosition + 0x8, 0xFFFFFFFF);
                gecko.poke32(currentPosition + 0xc, 0xFFFFFFFF);
                gecko.poke32(currentPosition + 0x10, 0x0);
                gecko.poke32(currentPosition + 0x18, 0x0);
                gecko.poke32(currentPosition + 0x1c, 0x0);

                // move to next slot
                currentPosition += 0x28;
            }
        }

        private void ReloadListBox()
        {
            weaponsList.Items.Clear();

            foreach (var weapon in weapons)
            {
                string name;

                var index = WeaponDatabase.GetIndex(weapon.id);
                if (index == 0)
                    name = weaponEditFormResources.GetString("weaponBox.Items");
                else
                    name = weaponEditFormResources.GetString("weaponBox.Items" + index);

                if (weapon.id == equippedWeapon)
                    name += " " + Strings.EQUIPPED;

                weaponsList.Items.Add(name);
            }
        }

        private void equipBox_Click(object sender, EventArgs e)
        {
            if (weaponsList.SelectedIndex != -1)
            {
                equippedWeapon = weapons[weaponsList.SelectedIndex].id;
                ReloadListBox();
            }
        }

        private void addBox_Click(object sender, EventArgs e)
        {
            var editForm = new WeaponEditForm();
            editForm.ShowDialog(this);

            if (editForm.weapon != null)
            {
                weapons.Add(editForm.weapon);
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
            var editForm = new WeaponEditForm(weapons[weaponsList.SelectedIndex]);
            editForm.ShowDialog(this);

            ReloadListBox();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var weapon = weapons[weaponsList.SelectedIndex];

            if (weapon.id == 0x3f2)
            {
                // refuse to remove the Splattershot Jr.
                MessageBox.Show(Strings.CANNOT_REMOVE_JR_TEXT);
            }
            else
            {
                // check if the removed weapon is currently equipped
                if (weapon.id == equippedWeapon)
                    equippedWeapon = 0x3f2;

                weapons.Remove(weapon);
                ReloadListBox();
            }
        }
    }
}