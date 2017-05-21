namespace SplatAIO.Logic.Hacks.Singleplayer
{
    enum PlayerAddress : uint
    {
        Minigames = 0x12CD1C40,
        Gender = Minigames + 0x150, //0x12CD1D90
        Skin = Gender + 0x4,// 0x12CD1D94
        Eyes = Skin + 0x4, // 0x12CD1D98
        Okane = 0x12CDC1A0,
        Rank = Okane + 0x8, // 0x12CDC1A8
        Ude = Rank + 0x4, // 0x12CDC1AC
        Mae = Ude + 0x4, // 0x12CDC1B0
        Sazae = Mae + 0x4, // 0x12CDC1B4
        Amiibo = 0x12D1F130
    }
}