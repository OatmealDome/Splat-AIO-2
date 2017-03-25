namespace SplatAIO.Logic.Memory.Addresses
{
    public enum Player : uint
    {
        Minigames = 0x12CD1C40,
        Gender = Minigames + 0x150, //0x12CD1D90
        Skin = Gender + 0x4,// 0x12CD1D94
        Eyes = Skin + 0x4, // 0x12CD1D98
        Okane = Eyes + 0xA480, // 0x12CDC1A0
        Rank = Okane + 0x8, // 0x12CDC1A8
        Ude = Rank + 0x4, // 0x12CDC1AC
        Mae = Ude + 0x4, // 0x12CDC1B0
        Sazae = Mae + 0x4, // 0x12CDC1B4
        Amiibo = Sazae + 0x42F7C //0x12D1F130
    }
}