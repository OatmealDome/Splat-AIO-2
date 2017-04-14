using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.Unlock;
using SplatAIO.Logic.Memory;
using System.Collections.Generic;

namespace SplatAIO.Logic.Hacks.Weapons
{
    class WeaponsHax
    {
        public const uint DefaultWeapon = 0x3f2; //0x3f2 Splattershot Jr.

        private TCPGecko Gecko { get; set; }
        private uint Offset { get; set; }

        private readonly List<Weapon> _weapons;
        public IReadOnlyList<Weapon> Weapons => _weapons.AsReadOnly();
        public uint EquippedWeapon { get; private set; }

        public WeaponsHax(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            Offset = offset;
            _weapons = new List<Weapon>();
        }

        public void ReloadWeapons()
        {
            _weapons.Clear();
            EquippedWeapon = Gecko.peek((uint)GearAddress.EquippedWeapon + Offset);
            var weaponData = MemoryUtils.DumpSaveSlots(Gecko, Offset, (uint) GearAddress.Weapons, 5120);
            // read data from slots
            var j = 0;
            while (j < weaponData.Length)
            {
                var id = weaponData[j];

                // check if an empty save slot
                if (id.Equals(uint.MaxValue))
                {
                    break;
                }

                var number = weaponData[j + 1];
                var sub = (SubWeapon) weaponData[j + 2];
                var special = (SpecialWeapon) weaponData[j + 3];
                var turfInked = weaponData[j + 4];
                var timestamp = weaponData[j + 7];
                var newFlag = weaponData[j + 8] == 0x0;

                AddWeapon(new Weapon(id, number, sub, special, turfInked, timestamp, newFlag));
                // move to next slot
                j += 10;
            }
        }

        public void AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            _weapons.Remove(weapon);
        }

        public Weapon GetWeapon(int index)
        {
            return _weapons.Count > index ? _weapons[index] : null;
        }

        public void SetEquippedWeapon(int index)
        {
            Weapon weapon = GetWeapon(index);
            EquippedWeapon = _weapons[0].Id;
            if (weapon != null)
            {
                EquippedWeapon = weapon.Id;
            }
        }

        public void EquipDefaultWeapon()
        {
            EquippedWeapon = DefaultWeapon;
        }

        public void PokeWeapons()
        {
            PokeWeapons(_weapons, Gecko, Offset);
            // set equipped weapon
            Gecko.poke32((uint)GearAddress.EquippedWeapon, EquippedWeapon);
        }

        public static void PokeWeapons(List<Weapon> weapons, TCPGecko gecko, uint offset)
        {
            var currentPosition = (uint)GearAddress.Weapons + offset;
            foreach (var weapon in weapons)
            {
                gecko.poke32(currentPosition, weapon.Id);
                gecko.poke32(currentPosition + 0x4, weapon.WeaponSpecificNumber);
                gecko.poke32(currentPosition + 0x8, (uint)weapon.SubWeapon);
                gecko.poke32(currentPosition + 0xc, (uint)weapon.SpecialWeapon1);
                gecko.poke32(currentPosition + 0x10, weapon.TurfInked);
                gecko.poke32(currentPosition + 0x18, weapon.LastUsageTimestamp);

                if (weapon.IsNew)
                {
                    gecko.poke32(currentPosition + 0x1c, 0x0);
                }                    
                else
                {
                    gecko.poke32(currentPosition + 0x1c, 0x00010000);
                }
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
    }
}
