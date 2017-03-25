namespace SplatAIO.Logic.Memory.Addresses
{
    public enum Singleplayer : uint
    {
        SaveSlotsAddress = 0x12CDC2B8,
        EnvironmentFlagsAddress = SaveSlotsAddress + 0x300, // 0x12CDC5B8
        NeroShotAddress = EnvironmentFlagsAddress + 0x10, // 0x12CDC5C8
        InkTankAddress = NeroShotAddress + 0x4, // 0x12CDC5CC
        SplatBombAddress = InkTankAddress + 0x8, // 0x12CDC5D4
        BurstBombAddress = SplatBombAddress + 0x4, // 0x12CDC5D8
        SeekerAddress = BurstBombAddress + 0x4, // 0x12CDC5DC
        PowerEggsAddress = SeekerAddress + 0x4 // 0x12CDC5E0
    }
}
