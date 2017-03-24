using System.Collections.Generic;

namespace SplatAIO.Logic.Weapons
{
    public class WeaponDatabase
    {
        private static readonly List<Weapon> weapons = new List<Weapon>();
        private static readonly Dictionary<uint, int> idToIndex = new Dictionary<uint, int>();

        public static List<Weapon> Weapons { get { return weapons; } }

        static WeaponDatabase()
        {
            // These weapons are added in the order inside the dropdown box in WeaponEditForm.
            AddWeapon(0x3f2, 0x66, SubWeapon.SplatBomb, SpecialWeapon.Bubbler);
            AddWeapon(0x3f3, 0x67, SubWeapon.Disruptor, SpecialWeapon.Echolocator);
            AddWeapon(0x410, 0x6c, SubWeapon.BurstBomb, SpecialWeapon.BombRush);
            AddWeapon(0x411, 0x6d, SubWeapon.SuctionBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0x415, 0x6e, SubWeapon.BurstBomb, SpecialWeapon.BombRush);
            AddWeapon(0x416, 0x6f, SubWeapon.SuctionBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0x412, 0x8a, SubWeapon.SplatBomb, SpecialWeapon.Inkstrike);
            AddWeapon(0x42e, 0x74, SubWeapon.SplatBomb, SpecialWeapon.Inkstrike);
            AddWeapon(0x42f, 0x75, SubWeapon.PointSensor, SpecialWeapon.Inkzooka);
            AddWeapon(0x430, 0x8b, SubWeapon.SuctionBomb, SpecialWeapon.BombRush);
            AddWeapon(0x406, 0x6a, SubWeapon.Seeker, SpecialWeapon.Inkzooka);
            AddWeapon(0x407, 0x6b, SubWeapon.InkMine, SpecialWeapon.Inkstrike);
            AddWeapon(0x408, 0x8d, SubWeapon.BurstBomb, SpecialWeapon.Kraken);
            AddWeapon(0x44c, 0x7a, SubWeapon.SplashWall, SpecialWeapon.Inkstrike);
            AddWeapon(0x44d, 0x7b, SubWeapon.BurstBomb, SpecialWeapon.Kraken);
            AddWeapon(0x442, 0x78, SubWeapon.SplatBomb, SpecialWeapon.Echolocator);
            AddWeapon(0x443, 0x79, SubWeapon.Beakon, SpecialWeapon.KillerWail);
            AddWeapon(0x488, 0x86, SubWeapon.Disruptor, SpecialWeapon.KillerWail);
            AddWeapon(0x489, 0x87, SubWeapon.BurstBomb, SpecialWeapon.Kraken);
            AddWeapon(0x492, 0x88, SubWeapon.SuctionBomb, SpecialWeapon.Echolocator);
            AddWeapon(0x493, 0x89, SubWeapon.PointSensor, SpecialWeapon.Inkzooka);
            AddWeapon(0x494, 0x90, SubWeapon.SplashWall, SpecialWeapon.Bubbler);
            AddWeapon(0x424, 0x72, SubWeapon.SplatBomb, SpecialWeapon.Echolocator);
            AddWeapon(0x425, 0x73, SubWeapon.Sprinkler, SpecialWeapon.Inkstrike);
            AddWeapon(0x426, 0x83, SubWeapon.PointSensor, SpecialWeapon.Kraken);
            AddWeapon(0x3fc, 0x68, SubWeapon.SuctionBomb, SpecialWeapon.BombRush);
            AddWeapon(0x3fd, 0x69, SubWeapon.BurstBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0x3e8, 0x64, SubWeapon.Beakon, SpecialWeapon.KillerWail);
            AddWeapon(0x3e9, 0x65, SubWeapon.PointSensor, SpecialWeapon.Kraken);
            AddWeapon(0x3ea, 0x8c, SubWeapon.SplatBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0x41a, 0x70, SubWeapon.SplashWall, SpecialWeapon.KillerWail);
            AddWeapon(0x41b, 0x71, SubWeapon.Seeker, SpecialWeapon.Inkstrike);
            AddWeapon(0x438, 0x76, SubWeapon.Sprinkler, SpecialWeapon.Echolocator);
            AddWeapon(0x439, 0x77, SubWeapon.SplashWall, SpecialWeapon.Kraken);
            AddWeapon(0x460, 0x7e, SubWeapon.Disruptor, SpecialWeapon.KillerWail);
            AddWeapon(0x461, 0x7f, SubWeapon.PointSensor, SpecialWeapon.Bubbler);
            AddWeapon(0x46a, 0x80, SubWeapon.SplashWall, SpecialWeapon.Inkstrike);
            AddWeapon(0x46b, 0x81, SubWeapon.SplatBomb, SpecialWeapon.Kraken);
            AddWeapon(0x46c, 0x8f, SubWeapon.BurstBomb, SpecialWeapon.KillerWail);
            AddWeapon(0x474, 0x82, SubWeapon.InkMine, SpecialWeapon.Bubbler);
            AddWeapon(0x475, 0x83, SubWeapon.SuctionBomb, SpecialWeapon.BombRush);
            AddWeapon(0x47e, 0x84, SubWeapon.Seeker, SpecialWeapon.Inkzooka);
            AddWeapon(0x47f, 0x85, SubWeapon.Disruptor, SpecialWeapon.KillerWail);
            AddWeapon(0x456, 0x7c, SubWeapon.InkMine, SpecialWeapon.Inkzooka);
            AddWeapon(0x457, 0x7d, SubWeapon.SplatBomb, SpecialWeapon.BombRush);
            AddWeapon(0xfaa, 0x12e, SubWeapon.SplatBomb, SpecialWeapon.BombRush);
            AddWeapon(0xfab, 0x12f, SubWeapon.Sprinkler, SpecialWeapon.KillerWail);
            AddWeapon(0xfaf, 0x130, SubWeapon.SplatBomb, SpecialWeapon.BombRush);
            AddWeapon(0xfac, 0x13b, SubWeapon.SplashWall, SpecialWeapon.KillerWail);
            AddWeapon(0xfb4, 0x131, SubWeapon.SplatBomb, SpecialWeapon.BombRush);
            AddWeapon(0xfb5, 0x132, SubWeapon.Sprinkler, SpecialWeapon.KillerWail);
            AddWeapon(0xfb6, 0x13c, SubWeapon.SplashWall, SpecialWeapon.KillerWail);
            AddWeapon(0xfbe, 0x133, SubWeapon.BurstBomb, SpecialWeapon.Echolocator);
            AddWeapon(0xfbf, 0x134, SubWeapon.Beakon, SpecialWeapon.Kraken);
            AddWeapon(0xfc8, 0x135, SubWeapon.BurstBomb, SpecialWeapon.Echolocator);
            AddWeapon(0xfc9, 0x136, SubWeapon.Beakon, SpecialWeapon.Kraken);
            AddWeapon(0xfa0, 0x12c, SubWeapon.PointSensor, SpecialWeapon.Bubbler);
            AddWeapon(0xfa1, 0x12d, SubWeapon.InkMine, SpecialWeapon.Inkzooka);
            AddWeapon(0xfa2, 0x139, SubWeapon.SuctionBomb, SpecialWeapon.Kraken);
            AddWeapon(0xfd2, 0x137, SubWeapon.SplashWall, SpecialWeapon.KillerWail);
            AddWeapon(0xfd3, 0x138, SubWeapon.Disruptor, SpecialWeapon.Echolocator);
            AddWeapon(0xfd4, 0x13a, SubWeapon.BurstBomb, SpecialWeapon.Inkstrike);
            AddWeapon(0x7da, 0xca, SubWeapon.SuctionBomb, SpecialWeapon.KillerWail);
            AddWeapon(0x7db, 0xcb, SubWeapon.Beakon, SpecialWeapon.Kraken);
            AddWeapon(0x7df, 0xcc, SubWeapon.SuctionBomb, SpecialWeapon.KillerWail);
            AddWeapon(0x7dc, 0xd5, SubWeapon.SplashWall, SpecialWeapon.Inkzooka);
            AddWeapon(0x7e4, 0xcd, SubWeapon.Sprinkler, SpecialWeapon.Echolocator);
            AddWeapon(0x7e5, 0xce, SubWeapon.SplatBomb, SpecialWeapon.Inkstrike);
            AddWeapon(0x7e6, 0xd3, SubWeapon.Seeker, SpecialWeapon.KillerWail);
            AddWeapon(0x7d0, 0xc8, SubWeapon.BurstBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0x7d1, 0xc9, SubWeapon.Seeker, SpecialWeapon.BombRush);
            AddWeapon(0x7ee, 0xcf, SubWeapon.Sprinkler, SpecialWeapon.Inkstrike);
            AddWeapon(0x7ef, 0xd0, SubWeapon.InkMine, SpecialWeapon.Bubbler);
            AddWeapon(0x7f0, 0xd4, SubWeapon.SplatBomb, SpecialWeapon.Kraken);
            AddWeapon(0x7f8, 0xd1, SubWeapon.Beakon, SpecialWeapon.Kraken);
            AddWeapon(0x7f9, 0xd2, SubWeapon.SplatBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0xbb8, 0x190, SubWeapon.BurstBomb, SpecialWeapon.Inkstrike);
            AddWeapon(0xbb9, 0x191, SubWeapon.SplashWall, SpecialWeapon.Kraken);
            AddWeapon(0xbba, 0x196, SubWeapon.SplatBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0xbc2, 0x192, SubWeapon.Disruptor, SpecialWeapon.Bubbler);
            AddWeapon(0xbc3, 0x193, SubWeapon.Seeker, SpecialWeapon.Echolocator);
            AddWeapon(0xbcc, 0x194, SubWeapon.SplatBomb, SpecialWeapon.BombRush);
            AddWeapon(0xbcd, 0x195, SubWeapon.PointSensor, SpecialWeapon.Inkzooka);
            AddWeapon(0x1392, 0x1f6, SubWeapon.SplashWall, SpecialWeapon.Inkstrike);
            AddWeapon(0x1393, 0x1f7, SubWeapon.PointSensor, SpecialWeapon.Kraken);
            AddWeapon(0x1394, 0x1fb, SubWeapon.Sprinkler, SpecialWeapon.KillerWail);
            AddWeapon(0x1388, 0x1f4, SubWeapon.SuctionBomb, SpecialWeapon.Inkzooka);
            AddWeapon(0x1389, 0x1f5, SubWeapon.Disruptor, SpecialWeapon.Bubbler);
            AddWeapon(0x138a, 0x1fa, SubWeapon.BurstBomb, SpecialWeapon.BombRush);
            AddWeapon(0x139c, 0x1f8, SubWeapon.SplatBomb, SpecialWeapon.Echolocator);
            AddWeapon(0x139d, 0x1f9, SubWeapon.Sprinkler, SpecialWeapon.Bubbler);
        }

        private static void AddWeapon(uint id, uint uniqueNum, SubWeapon sub, SpecialWeapon special)
        {
            Weapon weapon = new Weapon(id, uniqueNum, sub, special);
            weapons.Add(weapon);
            idToIndex.Add(id, weapons.Count - 1);
        }

        public static int GetIndex(uint id)
        {
            return idToIndex[id];
        }        
    }
}
