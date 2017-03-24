using SplatAIO.Logic.Gecko;

namespace SplatAIO.Logic.Memory
{
    public static class ValidMemory
    {
        public static bool addressDebug = false;

        public static readonly AddressRange[] ValidAreas =
        {
            new AddressRange(AddressType.Ex, 0x01000000, 0x01800000),
            new AddressRange(AddressType.Ex, 0x0e300000, 0x10000000),
            new AddressRange(AddressType.Rw, 0x10000000, 0x50000000),
            new AddressRange(AddressType.Ro, 0xe0000000, 0xe4000000),
            new AddressRange(AddressType.Ro, 0xe8000000, 0xea000000),
            new AddressRange(AddressType.Ro, 0xf4000000, 0xf6000000),
            new AddressRange(AddressType.Ro, 0xf6000000, 0xf6800000),
            new AddressRange(AddressType.Ro, 0xf8000000, 0xfb000000),
            new AddressRange(AddressType.Ro, 0xfb000000, 0xfb800000),
            new AddressRange(AddressType.Rw, 0xfffe0000, 0xffffffff)
        };

        public static AddressType rangeCheck(uint address)
        {
            var id = rangeCheckId(address);
            if (id == -1)
                return AddressType.Unknown;
            return ValidAreas[id].Description;
        }

        public static int rangeCheckId(uint address)
        {
            for (var i = 0; i < ValidAreas.Length; i++)
            {
                var range = ValidAreas[i];
                if (address >= range.Low && address < range.High)
                    return i;
            }
            return -1;
        }

        public static bool validAddress(uint address, bool debug)
        {
            return debug || rangeCheckId(address) >= 0;
        }

        public static bool validAddress(uint address)
        {
            return validAddress(address, addressDebug);
        }

        public static bool validRange(uint low, uint high, bool debug)
        {
            return debug || rangeCheckId(low) == rangeCheckId(high - 1);
        }

        public static bool validRange(uint low, uint high)
        {
            return validRange(low, high, addressDebug);
        }

        public static void setDataUpper(TCPGecko upper)
        {
            uint mem;
            switch (upper.OsVersionRequest())
            {
                case 400:
                case 410:
                    mem = upper.peek_kern(0xffe8619c);
                    break;
                case 500:
                case 510:
                // TODO: This doesn't work for some reason - crashes on connection?
                //mem = upper.peek_kern(0xffe8591c);
                //break;
                default:
                    return;
            }
            var tbl = upper.peek_kern(mem + 4);
            var lst = upper.peek_kern(tbl + 20);

            var init_start = upper.peek_kern(lst + 0 + 0x00);
            var init_len = upper.peek_kern(lst + 4 + 0x00);
            var code_start = upper.peek_kern(lst + 0 + 0x10);
            var code_len = upper.peek_kern(lst + 4 + 0x10);
            var data_start = upper.peek_kern(lst + 0 + 0x20);
            var data_len = upper.peek_kern(lst + 4 + 0x20);
            ValidAreas[0] = new AddressRange(AddressType.Ex, init_start, init_start + init_len);
            ValidAreas[1] = new AddressRange(AddressType.Ex, code_start, code_start + code_len);
            ValidAreas[2] = new AddressRange(AddressType.Rw, data_start, data_start + data_len);
        }
    }
}