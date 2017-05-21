using System.Collections.Generic;

namespace SplatAIO.Logic.Hacks.Sisterhax
{
    public class SisterhaxMode
    {
        public static readonly SisterhaxMode Aori = new SisterhaxMode(SisterhaxValue.AoriModel, SisterhaxValue.AoriModel);
        public static readonly SisterhaxMode Hotaru = new SisterhaxMode(SisterhaxValue.HotaruModel, SisterhaxValue.HotaruModel);
        public static readonly SisterhaxMode Swap = new SisterhaxMode(SisterhaxValue.HotaruModel, SisterhaxValue.AoriModel);
        public static readonly SisterhaxMode Normal = new SisterhaxMode(SisterhaxValue.AoriModel, SisterhaxValue.HotaruModel);

        public uint AoriValue { get; }
        public uint HotaruValue { get; }

        public static IEnumerable<SisterhaxMode> Values
        {
            get
            {
                yield return Aori;
                yield return Hotaru;
                yield return Swap;
                yield return Normal;
            }
        }

        private SisterhaxMode(SisterhaxValue aoriValue, SisterhaxValue hotaruValue)
        {
            AoriValue = (uint)aoriValue;
            HotaruValue = (uint)hotaruValue;
        }
    }
}
