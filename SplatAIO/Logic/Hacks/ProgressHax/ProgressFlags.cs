using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Memory;

namespace SplatAIO.Logic.Hacks.ProgressHax
{
    enum ProgressBits
    {
        Tutorial = 0x1,
        Splatfest= 0x2,
        RankedNews = 0x4,
        Lobby = 0x8,
        HeroSuit = 0x10,
        GreatZapfish = 0x80,
        CuttlefishPostGame = 0x100,
        RankedUnlocked = 0x800,
        RankShown = 0x1000,
        SnailsShown = 0x10000,
        LevelCapRaised = 0x100000,
        Warning = 0x200000
    }

    class ProgressFlags
    {
        private const uint ProgressBitsAddress = 0x12CD1C24;

        private TCPGecko Gecko { get; set; }
        private uint _progression;

        public bool Tutorial { get { return (_progression & (uint)ProgressBits.Tutorial) != 0; } set { SetFlag((uint)ProgressBits.Tutorial, value); } }
        public bool Splatfest { get { return (_progression & (uint)ProgressBits.Splatfest) != 0; } set { SetFlag((uint)ProgressBits.Splatfest, value); } }
        public bool RankedNews { get { return (_progression & (uint)ProgressBits.RankedNews) != 0; } set { SetFlag((uint)ProgressBits.RankedNews, value); } }
        public bool Lobby { get { return (_progression & (uint)ProgressBits.Lobby) != 0; } set { SetFlag((uint)ProgressBits.Lobby, value); } }
        public bool HeroSuit { get { return (_progression & (uint)ProgressBits.HeroSuit) != 0; } set { SetFlag((uint)ProgressBits.HeroSuit, value); } }
        public bool GreatZapfish { get { return (_progression & (uint)ProgressBits.GreatZapfish) != 0; } set { SetFlag((uint)ProgressBits.GreatZapfish, value); } }
        public bool CuttlefishPostGame { get { return (_progression & (uint)ProgressBits.CuttlefishPostGame) != 0; } set { SetFlag((uint)ProgressBits.CuttlefishPostGame, value); } }
        public bool RankedUnlocked { get { return (_progression & (uint)ProgressBits.RankedUnlocked) != 0; } set { SetFlag((uint)ProgressBits.RankedUnlocked, value); } }
        public bool RankShown { get { return (_progression & (uint)ProgressBits.RankShown) != 0; } set { SetFlag((uint)ProgressBits.RankShown, value); } }
        public bool SnailsShown { get { return (_progression & (uint)ProgressBits.SnailsShown) != 0; } set { SetFlag((uint)ProgressBits.SnailsShown, value); } }
        public bool LevelCapRaised { get { return (_progression & (uint)ProgressBits.LevelCapRaised) != 0; } set { SetFlag((uint)ProgressBits.LevelCapRaised, value); } }
        public bool Warning { get { return (_progression & (uint)ProgressBits.Warning) != 0; } set { SetFlag((uint)ProgressBits.Warning, value); } }

        public ProgressFlags(TCPGecko gecko)
        {
            Gecko = gecko;
            Refresh();
        }

        private void SetFlag(uint flag, bool set)
        {
            if ((_progression & flag) != 0 && !set)
            {
                _progression ^= flag;
            }                
            else if ((_progression & flag) == 0 && set)
            {
                _progression |= flag;
            }   
        }

        public void Refresh()
        {
            _progression = Gecko.peek(ProgressBitsAddress + MemoryUtils.Offset);
        }

        public void Apply()
        {
            Gecko.poke32(ProgressBitsAddress + MemoryUtils.Offset, _progression);
        }
    }
}
