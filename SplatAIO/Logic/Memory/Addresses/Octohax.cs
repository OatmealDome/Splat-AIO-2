namespace SplatAIO.Logic.Memory.Addresses
{
    public enum Octohax : uint
    {
        TnkSimpleFive = 0x12BEB3E,
        TnkSimpleOne = 0x10506BC0,
        TnkSimpleTwo = 0x105E62B0,
        Player00 = TnkSimpleTwo + 0x9100, // 0x105EF3B0
        Player00Hlf = Player00 + 0xC, // 0x105EF3BC
        RivalSquid = Player00Hlf + 0x10, //0x105EF3CC
        TnkSimpleThree = 0x12BEB354,
        TnkSimpleFour = TnkSimpleThree + 0x4C // 0x12BEB3A0
    }
}