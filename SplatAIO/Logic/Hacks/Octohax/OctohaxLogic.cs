using SplatAIO.Logic.Gecko;

namespace SplatAIO.Logic.Hacks.Octohax
{
    public class OctohaxLogic
    {
        private TCPGecko Gecko { get; set; }

        public OctohaxLogic(TCPGecko gecko)
        {
            Gecko = gecko;
        }

        public void switchToOctopus()
        {
            SwitchZlMode(true);
        }

        public void switchToSquid()
        {
            SwitchZlMode(false);
        }

        private void SwitchZlMode(bool octopus)
        {
            uint tnkRvlOne = 0x52766C30; // "Rvl0"
            uint tnkRvlTwo = 0x30000000; // "0"

            // Tnk_Simple 1
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleOne + 0x4, tnkRvlOne);
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleOne + 0x8, tnkRvlTwo);

            // Tnk_Simple 2
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleTwo + 0x4, tnkRvlOne);
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleTwo + 0x8, tnkRvlTwo);

            // Player00
            Gecko.poke32((uint)OctohaxAddress.Player00, 0x52697661);
            Gecko.poke32((uint)OctohaxAddress.Player00 + 0x4, 0x6C303000);

            // Player00_Hlf
            Gecko.poke32((uint)OctohaxAddress.Player00Hlf, 0x52697661);
            Gecko.poke32((uint)OctohaxAddress.Player00Hlf + 0x4, 0x6C30305F);
            Gecko.poke32((uint)OctohaxAddress.Player00Hlf + 0x8, 0x486C6600);

            // Rival_Squid
            if (octopus)
            {
                Gecko.poke32((uint)OctohaxAddress.RivalSquid, 0x52697661);
                Gecko.poke32((uint)OctohaxAddress.RivalSquid + 0x4, 0x6C5F5371);
                Gecko.poke32((uint)OctohaxAddress.RivalSquid + 0x8, 0x75696400);
            }
            else
            {
                Gecko.poke32((uint)OctohaxAddress.RivalSquid, 0x506C6179);
                Gecko.poke32((uint)OctohaxAddress.RivalSquid + 0x4, 0x65725F53);
                Gecko.poke32((uint)OctohaxAddress.RivalSquid + 0x8, 0x71756964);
            }

            // Tnk_Simple 3
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleThree + 0x4, tnkRvlOne);
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleThree + 0x8, tnkRvlTwo);

            // Tnk_Simple 4
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleFour + 0x4, tnkRvlOne);
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleFour + 0x8, tnkRvlTwo);

            // Tnk_Simple 5
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleFive + 0x4, tnkRvlOne);
            Gecko.poke32((uint)OctohaxAddress.TnkSimpleFive + 0x8, tnkRvlTwo);

            /*if (SendStats) ToDo
                StatisticTransmitter.WriteToSlot(9, 1);*/
        }
    }
}
