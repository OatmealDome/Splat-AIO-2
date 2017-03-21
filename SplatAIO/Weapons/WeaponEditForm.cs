using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO.Weapons
{
    public partial class WeaponEditForm : Form
    {
        public Weapon weapon = null;

        public WeaponEditForm()
        {
            InitializeComponent();
        }

        public WeaponEditForm(Weapon wep)
        {
            InitializeComponent();

            weapon = wep;
            weaponBox.SelectedIndex = WeaponDatabase.getIndex(weapon.id);
            weaponBox.Enabled = false;
            turfInkedBox.Value = Convert.ToInt32(weapon.turfInked);
            newFlagBox.Checked = weapon.isNew;
        }

        private void saveBox_Click(object sender, EventArgs e)
        {
            // check if we're adding a new weapon
            if (weaponBox.Enabled != false)
            {
                WeaponsForm weaponsForm = (WeaponsForm)this.Owner;
                Weapon selectedWeapon = WeaponDatabase.GetWeapons()[weaponBox.SelectedIndex];

                // make sure this new weapon isn't already in the list
                foreach (Weapon existingWeapon in weaponsForm.weapons)
                {
                    if (selectedWeapon.id == existingWeapon.id)
                    {
                        // refuse to save
                        MessageBox.Show(Properties.Strings.WEAPON_EXISTS_TEXT);
                        return;
                    }
                }

                weapon = selectedWeapon;
            }

            weapon.turfInked = Convert.ToUInt32(turfInkedBox.Value);
            weapon.isNew = newFlagBox.Checked;

            this.Close();
        }

    }
}
