﻿using SplatAIO.Logic.Hacks.Weapons;
using SplatAIO.Properties;
using System;
using System.Windows.Forms;

namespace SplatAIO.UI.Weapons
{
    public partial class WeaponEditForm : Form
    {
        public Weapon weapon;

        public WeaponEditForm()
        {
            InitializeComponent();
        }

        public WeaponEditForm(Weapon wep)
        {
            InitializeComponent();

            weapon = wep;
            weaponBox.SelectedIndex = WeaponDatabase.GetIndex(weapon.Id);
            weaponBox.Enabled = false;
            turfInkedBox.Value = Convert.ToInt32(weapon.TurfInked);
            newFlagBox.Checked = weapon.IsNew;
        }

        private void saveBox_Click(object sender, EventArgs e)
        {
            // check if we're adding a new weapon
            if (weaponBox.Enabled)
            {
                var weaponsForm = (WeaponsForm) Owner;
                var selectedWeapon = WeaponDatabase.Weapons[weaponBox.SelectedIndex];

                // make sure this new weapon isn't already in the list
                foreach (var existingWeapon in weaponsForm.weapons)
                    if (selectedWeapon.Id == existingWeapon.Id)
                    {
                        // refuse to save
                        MessageBox.Show(Strings.WEAPON_EXISTS_TEXT);
                        return;
                    }

                weapon = selectedWeapon;
            }

            weapon.TurfInked = Convert.ToUInt32(turfInkedBox.Value);
            weapon.IsNew = newFlagBox.Checked;

            Close();
        }
    }
}