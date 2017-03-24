namespace SplatAIO.Logic.Memory
{
    public enum AddressType
    {
        Rw,
        Ro,
        Ex,
        Hardware,
        Unknown
    }

    public class AddressRange
    {
        public AddressRange(AddressType desc, byte id, uint low, uint high)
        {
            this.id = id;
            description = desc;
            this.low = low;
            this.high = high;
        }

        public AddressRange(AddressType desc, uint low, uint high) :
            this(desc, (byte) (low >> 24), low, high)
        {
        }

        public AddressType description { get; }
        public byte id { get; }
        public uint low { get; }
        public uint high { get; }
    }
}