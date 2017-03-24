using SplatAIO.Logic.Gecko;
using System;

namespace SplatAIO.Logic.TimeHax
{
    public class TimerHaxLogic
    {
        public const uint SafeAddress = 0x10000004; //safe area to poke if error occurs

        private const uint BasePointer = 0x106E5814;
        private const uint OffsetOne = 0x2A4;
        private const uint OffsetTwo = 0x280;
        private const uint OffsetTwoAmiibo = 0x2B4;

        private TCPGecko Gecko { get; set; }
        private uint TimerAddress { get; set; }

        public TimerHaxLogic(TCPGecko gecko)
        {
            Gecko = gecko;
        }

        public uint GetPointerValaue(uint basePointer, uint offset1, uint offset2)
        {
            uint result = 0;
            try
            {
                uint pointerValue = Gecko.peek(Gecko.peek(basePointer) + offset1) + offset2;
                if (pointerValue > 0x1F000000 && pointerValue < 0x21000000)
                {
                    result = pointerValue;
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                // ToDo log
            }
            return result;
        }

        public bool RecalculatePointer(bool recon = true)
        {
            return (TimerAddress = GetPointerValaue(BasePointer, OffsetOne, recon ? OffsetTwo : OffsetTwoAmiibo)) > 0;
        }

        public void SetTimer(uint value)
        {
            Gecko.poke32(TimerAddress, value);
        }
    }
}
