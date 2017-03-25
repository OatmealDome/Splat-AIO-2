namespace SplatAIO.Logic.Memory.es
{
    public enum World : uint
    {
        SaveSlots = 0x12CDC2B8,
        EnvironmentFlags = SaveSlots + 0x300, // 0x12CDC5B8
        HeroShot = EnvironmentFlags + 0x10, // 0x12CDC5C8
        InkTank = HeroShot + 0x4, // 0x12CDC5CC
        SplatBomb = InkTank + 0x8, // 0x12CDC5D4
        BurstBomb = SplatBomb + 0x4, // 0x12CDC5D8
        Seeker = BurstBomb + 0x4, // 0x12CDC5DC
        PowerEggs = Seeker + 0x4 // 0x12CDC5E0
    }
}
