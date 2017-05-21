using SplatAIO.Logic.Gecko;
using System;
using System.IO;

namespace SplatAIO.Logic.Memory
{
    public class MemoryUtils
    {
        public static uint Offset { get; set; }
        public static uint[] DumpSaveSlots(TCPGecko gecko, uint diff, uint start, uint size)
        {
            using (var memoryStream = new MemoryStream())
            {
                // dump all save slots
                gecko.Dump(start + diff, start + diff + size, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                // convert to a uint array
                var saveSlots = new uint[size / 4];
                for (var i = 0; i < saveSlots.Length; i++)
                {
                    var buffer = new byte[4];
                    memoryStream.Read(buffer, 0, 4);
                    saveSlots[i] = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
                }

                return saveSlots;
            }
        }
    }
}
