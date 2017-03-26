using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Memory.Addresses;

namespace SplatAIO.Logic.Hacks.Sisterhax
{
    public class SisterhaxLogic
    {
        private TCPGecko Gecko { get; set; }

        public SisterhaxLogic(TCPGecko gecko)
        {
            Gecko = gecko;
        }

        public void changeModels(SisterhaxMode mode)
        {
            Gecko.poke32((uint)SisterhaxAddress.Aori, (uint)SisterhaxValue.ValueOne);
            Gecko.poke32((uint)SisterhaxAddress.AoriTwo, (uint)SisterhaxValue.ValueTwo);
            Gecko.poke32((uint)SisterhaxAddress.AoriModel, mode.AoriValue);

            Gecko.poke32((uint)SisterhaxAddress.Hotaru, (uint)SisterhaxValue.ValueOne);
            Gecko.poke32((uint)SisterhaxAddress.HotaruTwo, (uint)SisterhaxValue.ValueTwo);
            Gecko.poke32((uint)SisterhaxAddress.HotaruModel, mode.HotaruValue);

            /* if (SendStats) ToDo
                StatisticTransmitter.WriteToSlot(8, 1);*/
        }
    }
}
