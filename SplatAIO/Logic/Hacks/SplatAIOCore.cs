using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.ProgressHax;
using SplatAIO.Logic.Hacks.Singleplayer;
using SplatAIO.Logic.Memory;
using System;

namespace SplatAIO.Logic.Hacks
{
    class SplatAIOCore
    {
        private TCPGecko Gecko { get; set; }
        private uint Offset { get; set; }

        private ProgressFlags ProgressFlags { get; set; }

        public int Rank { get; set; }
        public int Okane { get; set; }
        public int Ude { get; set; }
        public int Mae { get; set; }
        public int Sazae { get; set; }
        public int Gender { get; set; }
        public int Eyes { get; set; }
        public int Skin { get; set; }
        public uint Amiibo { get; set; }

        public SplatAIOCore(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            Offset = offset;
            ProgressFlags = new ProgressFlags(gecko, offset);
        }

        public void loadValues()
        {
            Rank = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Rank + MemoryUtils.Offset)) + 1;
            Okane = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Okane + MemoryUtils.Offset));
            Ude = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Ude + MemoryUtils.Offset));
            Mae = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Mae + MemoryUtils.Offset));
            Sazae = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Sazae + MemoryUtils.Offset));
            Gender = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Gender + MemoryUtils.Offset));
            Eyes = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Eyes + MemoryUtils.Offset));
            Skin = Convert.ToInt32(Gecko.peek((uint)PlayerAddress.Skin + MemoryUtils.Offset));
            Amiibo = Gecko.peek((uint)PlayerAddress.Amiibo + MemoryUtils.Offset);
        }

        public void PokeRank(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Rank + Offset, value - 1); // Rank
            Gecko.poke32((uint)PlayerAddress.Rank + Offset - 0x4, 0); // experience to 0

            // set progression bits appropriately            
            ProgressFlags.LevelCapRaised = value >= 20;
            // rank cap flag, remove if rank < 20, set if rank >= 20
            ProgressFlags.RankedUnlocked = value >= 10;
            // gachi unlocked flag, remove if rank < 10, set if rank >= 10
            ProgressFlags.Apply();
        }

        public void PokeOkane(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Okane + Offset, value);
        }

        public void PokeUde(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Ude + Offset, value);
        }

        public void PokeMae(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Mae + Offset, value);
        }

        public void PokeSazae(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Sazae + Offset, value);
        }

        public void PokeGender(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Gender + Offset, value);
        }

        public void PokeEyes(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Eyes + Offset, value);
        }

        public void PokeSkin(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Skin + Offset, value);
        }

        public void PokeAmiibo(uint value)
        {
            Gecko.poke32((uint)PlayerAddress.Amiibo + Offset, value);
        }
    }
}
