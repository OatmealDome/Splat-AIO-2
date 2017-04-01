namespace SplatAIO.Logic.Hacks.Weapons
{
    public class Weapon
    {
        public uint Id { get; }
        public SpecialWeapon SpecialWeapon1 { get; }
        public SubWeapon SubWeapon { get; }
        public uint WeaponSpecificNumber { get; }
        public bool IsNew { get; set; }
        public uint LastUsageTimestamp { get; }
        public uint TurfInked { get; set; }

        public Weapon(uint id, uint number, SubWeapon sub, SpecialWeapon special)
        {
            Id = id;
            WeaponSpecificNumber = number;
            SubWeapon = sub;
            SpecialWeapon1 = special;
            TurfInked = 0;
            LastUsageTimestamp = 0;
            IsNew = true;
        }

        public Weapon(uint id, uint number, SubWeapon sub, SpecialWeapon special, uint inked, uint timestamp, bool isNew)
        {
            Id = id;
            WeaponSpecificNumber = number;
            SubWeapon = sub;
            SpecialWeapon1 = special;
            TurfInked = inked;
            LastUsageTimestamp = timestamp;
            IsNew = isNew;
        }
        
        public Weapon Copy()
        {
            return new Weapon(Id, WeaponSpecificNumber, SubWeapon, SpecialWeapon1, TurfInked, LastUsageTimestamp, IsNew);
        }
    }
}