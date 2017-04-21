using SplatAIO.Logic.Gecko;

namespace SplatAIO.Logic.Hacks
{
    class SplatAIOCore
    {
        private TCPGecko Gecko { get; set; }
        private uint Offset { get; set; }

        public SplatAIOCore(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            Offset = offset;
        }
    }
}
