using SplatAIO.Logic.Gecko;

namespace SplatAIO.Logic.Hacks.Singleplayer
{
    public class UpgradesHax
    {
        private uint BurstBombAddress { get; set; }
        private uint HeroShotAddress { get; set; }
        private uint InkTankAddress { get; set; }
        private uint PowerEggsAddress { get; set; }        
        private uint SeekerAddress { get; set; }
        private uint SplatBombAddress { get; set; }

        private TCPGecko Gecko { get; set; }

        public UpgradesHax(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            HeroShotAddress = (uint)WorldAddress.HeroShot + offset;
            InkTankAddress = (uint)WorldAddress.InkTank + offset;
            SplatBombAddress = (uint)WorldAddress.SplatBomb + offset;
            BurstBombAddress = (uint)WorldAddress.BurstBomb + offset;
            SeekerAddress = (uint)WorldAddress.Seeker + offset;
            PowerEggsAddress = (uint)WorldAddress.PowerEggs + offset;
        }

        public void SetBurstBomb(uint value)
        {
            Gecko.poke32(BurstBombAddress, value);
        }

        public uint GetBurstBomb()
        {
            return Gecko.peek(BurstBombAddress);
        }

        public void SetHeroShot(uint value)
        {
            Gecko.poke32(HeroShotAddress, value);
        }

        public uint GetHeroShot()
        {
            return Gecko.peek(HeroShotAddress);
        }

        public void SetInkTank(uint value)
        {
            Gecko.poke32(InkTankAddress, value);
        }

        public uint GetInkTank()
        {
            return Gecko.peek(InkTankAddress);
        }

        public void SetPowerEggs(uint value)
        {
            Gecko.poke32(PowerEggsAddress, value);
        }

        public uint GetPowerEggs()
        {
            return Gecko.peek(PowerEggsAddress);
        }

        public void SetSeeker(uint value)
        {
            Gecko.poke32(SeekerAddress, value);
        }

        public uint GetSeeker()
        {
            return Gecko.peek(SeekerAddress);
        }

        public void SetSplatBomb(uint value)
        {
            Gecko.poke32(SplatBombAddress, value);
        }

        public uint GetSplatBomb()
        {
            return Gecko.peek(SplatBombAddress);
        }
    }
}
