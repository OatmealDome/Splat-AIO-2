using SplatAIO.Logic.Hacks.Weapons;
using SplatAIO.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SplatAIO.UI.Weapons
{
    public partial class WeaponEditForm : Form
    {   
        private IReadOnlyList<Weapon> OwnedWeapons { get; set; }

        public Weapon Weapon { get; private set; }

        public WeaponEditForm()
        {
            InitializeComponent();
        }

        public WeaponEditForm(Weapon chosenWeapon, IReadOnlyList<Weapon> ownedWeapons)
        {
            InitializeComponent();

            Weapon = chosenWeapon;
            OwnedWeapons = ownedWeapons;
            weaponBox.SelectedIndex = WeaponDatabase.GetIndex(Weapon.Id);
            weaponBox.Enabled = false;
            turfInkedBox.Value = Convert.ToInt32(Weapon.TurfInked);
            newFlagBox.Checked = Weapon.IsNew;
        }

        private void saveBox_Click(object sender, EventArgs e)
        {
            // check if we're adding a new weapon
            if (weaponBox.Enabled)
            {
                var selectedWeapon = WeaponDatabase.Weapons[weaponBox.SelectedIndex];

                // make sure this new weapon isn't already in the list
                if (OwnedWeapons.Any(existingWeapon => selectedWeapon.Id == existingWeapon.Id))
                {
                    MessageBox.Show(Strings.WEAPON_EXISTS_TEXT);
                    return;
                }
                Weapon = selectedWeapon;
            }

            Weapon.TurfInked = Convert.ToUInt32(turfInkedBox.Value);
            Weapon.IsNew = newFlagBox.Checked;

            Close();
        }
    }
}