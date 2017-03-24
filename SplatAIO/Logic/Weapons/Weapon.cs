namespace SplatAIO.Logic.Weapons
{
    public class Weapon
    {
        public readonly uint id;
        public readonly uint weaponSpecificNumber;
        public readonly SubWeapon subWeapon;
        public readonly SpecialWeapon specialWeapon;
        public uint turfInked;
        public uint lastUsageTimestamp;
        public bool isNew;

        public Weapon(uint id, uint number, SubWeapon sub, SpecialWeapon special)
        {
            this.id = id;
            weaponSpecificNumber = number;
            subWeapon = sub;
            specialWeapon = special;
            turfInked = 0;
            lastUsageTimestamp = 0;
            isNew = true;
        }

        public Weapon(uint id, uint number, SubWeapon sub, SpecialWeapon special, uint inked, uint timestamp, bool isNew)
        {
            this.id = id;
            weaponSpecificNumber = number;
            subWeapon = sub;
            specialWeapon = special;
            turfInked = inked;
            lastUsageTimestamp = timestamp;
            this.isNew = isNew;
        }

        public Weapon Copy()
        {
            return new Weapon(id, weaponSpecificNumber, subWeapon, specialWeapon, turfInked, lastUsageTimestamp, isNew);
        }

    }
}
