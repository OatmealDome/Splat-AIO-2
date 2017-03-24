using System;

namespace SplatAIO.Memory
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
        private AddressType PDesc;
        private Byte PId;
        private UInt32 PLow;
        private UInt32 PHigh;

        public AddressType description { get { return PDesc; } }
        public Byte id { get { return PId; } }
        public UInt32 low { get { return PLow; } }
        public UInt32 high { get { return PHigh; } }

        public AddressRange(AddressType desc, Byte id, UInt32 low, UInt32 high)
        {
            this.PId = id;
            this.PDesc = desc;
            this.PLow = low;
            this.PHigh = high;
        }

        public AddressRange(AddressType desc, UInt32 low, UInt32 high) :
            this(desc, (Byte)(low >> 24), low, high)
        { }
    }
}