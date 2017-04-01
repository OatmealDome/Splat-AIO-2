namespace SplatAIO.Logic.Hacks.Unlock
{
    enum GearAddress : uint
    {
        EquippedClothes = 0x12CD1D80,
        EquippedShoes = EquippedClothes + 0x4, // 0x12CD1D84
        EquippedHat = EquippedShoes + 0x4, // 0x12CD1D88
        EquippedWeapon = EquippedHat + 0x4, // 0x12CD1D8C
        Shoes = EquippedWeapon + 0x14, // 0x12CD1DA0
        Clothes = Shoes + 0x3000, // 0x12CD4DA0
        Hats = Clothes + 0x3000, // 0x12CD7DA0
        Weapons = Hats + 0x3000 // 0x12CDADA0
    }
}
