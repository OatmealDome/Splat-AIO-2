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
            Id = id;
            Description = desc;
            Low = low;
            High = high;
        }

        public AddressRange(AddressType desc, uint low, uint high) :
            this(desc, (byte) (low >> 24), low, high)
        {
        }

        public AddressType Description { get; }
        public byte Id { get; }
        public uint Low { get; }
        public uint High { get; }
    }
}