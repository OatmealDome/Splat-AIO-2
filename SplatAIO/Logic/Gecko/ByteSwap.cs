using System;

namespace SplatAIO.Logic.Gecko
{
    public class ByteSwap
    {
        public static UInt16 Swap(UInt16 input)
        {
            if (BitConverter.IsLittleEndian)
                return ((UInt16)(
                    ((0xFF00 & input) >> 8) |
                    ((0x00FF & input) << 8)));
            else
                return input;
        }

        public static UInt32 Swap(UInt32 input)
        {
            if (BitConverter.IsLittleEndian)
                return ((UInt32)(
                    ((0xFF000000 & input) >> 24) |
                    ((0x00FF0000 & input) >> 8) |
                    ((0x0000FF00 & input) << 8) |
                    ((0x000000FF & input) << 24)));
            else
                return input;
        }

        public static UInt64 Swap(UInt64 input)
        {
            if (BitConverter.IsLittleEndian)
                return ((UInt64)(
                    ((0xFF00000000000000 & input) >> 56) |
                    ((0x00FF000000000000 & input) >> 40) |
                    ((0x0000FF0000000000 & input) >> 24) |
                    ((0x000000FF00000000 & input) >> 8) |
                    ((0x00000000FF000000 & input) << 8) |
                    ((0x0000000000FF0000 & input) << 24) |
                    ((0x000000000000FF00 & input) << 40) |
                    ((0x00000000000000FF & input) << 56)));
            else
                return input;
        }
    }
}
