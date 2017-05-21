using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.Singleplayer;

namespace SplatAIO.Logic.Hacks.Unlock
{
    public class MinigamesUnlocker
    {
        private TCPGecko Gecko { get; set; }
        private uint Offset { get; set; }

        public MinigamesUnlocker(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            Offset = offset;
        }

        public void UnlockMinigames()
        {
            Gecko.poke32((uint)PlayerAddress.Minigames + Offset, 0x000F0000);
        }
    }
}
