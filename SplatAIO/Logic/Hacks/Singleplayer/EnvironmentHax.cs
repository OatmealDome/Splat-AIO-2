using SplatAIO.Logic.Gecko;

namespace SplatAIO.Logic.Hacks.Singleplayer
{
    public class EnvironmentHax
    {
        private uint EnvironmentFlagsAddress { get; set; }
        private TCPGecko Gecko { get; set; }

        public EnvironmentHax(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            EnvironmentFlagsAddress = (uint)WorldAddress.EnvironmentFlags + offset;
        }

        public void SetAllEnvironmentFlags()
        {
            Gecko.poke32(EnvironmentFlagsAddress, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0x4, 0x001FFFFF);
            Gecko.poke32(EnvironmentFlagsAddress + 0x8, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0xC, 0x0003EFBE);
        }

        public void ClearEnvironmentFlags()
        {
            Gecko.poke32(EnvironmentFlagsAddress, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0x4, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0x8, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0xC, 0);
        }
    }
}
