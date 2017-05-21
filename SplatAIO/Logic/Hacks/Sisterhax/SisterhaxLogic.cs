using SplatAIO.Logic.Gecko;

namespace SplatAIO.Logic.Hacks.Sisterhax
{
    public class SisterhaxLogic
    {
        private TCPGecko Gecko { get; set; }

        public SisterhaxLogic(TCPGecko gecko)
        {
            Gecko = gecko;
        }

        public void ChangeModels(SisterhaxMode mode)
        {
            Gecko.poke32((uint)SisterhaxAddress.Aori, (uint)SisterhaxValue.ValueOne);
            Gecko.poke32((uint)SisterhaxAddress.AoriTwo, (uint)SisterhaxValue.ValueTwo);
            Gecko.poke32((uint)SisterhaxAddress.AoriModel, mode.AoriValue);

            Gecko.poke32((uint)SisterhaxAddress.Hotaru, (uint)SisterhaxValue.ValueOne);
            Gecko.poke32((uint)SisterhaxAddress.HotaruTwo, (uint)SisterhaxValue.ValueTwo);
            Gecko.poke32((uint)SisterhaxAddress.HotaruModel, mode.HotaruValue);
        }
    }
}
