using System;
using System.IO;

namespace SplatAIO.Logic.Gecko
{
    public class Dump
    {
        private int _fileNumber;

        /*
        public void WriteCompressedStreamToDisk(string filepath)
        {
            ZipFile foo = new ZipFile(filepath);
            foo.AddEntry("mem", mem);
            foo.Dispose();
        }
        */

        public byte[] mem;

        public Dump(uint theStartAddress, uint theEndAddress)
        {
            Construct(theStartAddress, theEndAddress, 0);
        }

        public Dump(uint theStartAddress, uint theEndAddress, int theFileNumber)
        {
            Construct(theStartAddress, theEndAddress, theFileNumber);
        }

        public uint StartAddress { get; private set; }

        public uint EndAddress { get; private set; }

        public uint ReadCompletedAddress { get; set; }

        private void Construct(uint theStartAddress, uint theEndAddress, int theFileNumber)
        {
            StartAddress = theStartAddress;
            EndAddress = theEndAddress;
            ReadCompletedAddress = theStartAddress;
            mem = new byte[EndAddress - StartAddress];
            _fileNumber = theFileNumber;
        }


        public uint ReadAddress32(uint addressToRead)
        {
            //dumpStream.Seek(addressToRead - startAddress, SeekOrigin.Begin);
            //byte [] buffer = new byte[4];

            //dumpStream.Read(buffer, 0, 4);
            if (addressToRead < StartAddress) return 0;
            if (addressToRead > EndAddress - 4) return 0;
            var buffer = new byte[4];
            Buffer.BlockCopy(mem, index(addressToRead), buffer, 0, 4);
            //GeckoApp.SubArray<byte> buffer = new GeckoApp.SubArray<byte>(mem, (int)(addressToRead - startAddress), 4);

            //Read buffer
            var result = BitConverter.ToUInt32(buffer, 0);

            //Swap to machine endianness and return
            return ByteSwap.Swap(result);
        }

        private int index(uint addressToRead)
        {
            return (int) (addressToRead - StartAddress);
        }

        public uint ReadAddress(uint addressToRead, int numBytes)
        {
            if (addressToRead < StartAddress) return 0;
            if (addressToRead > EndAddress - numBytes) return 0;

            var buffer = new byte[4];
            Buffer.BlockCopy(mem, index(addressToRead), buffer, 0, numBytes);

            //Read buffer
            switch (numBytes)
            {
                case 4:
                    var result = BitConverter.ToUInt32(buffer, 0);

                    //Swap to machine endianness and return
                    return ByteSwap.Swap(result);

                case 2:
                    var result16 = BitConverter.ToUInt16(buffer, 0);

                    //Swap to machine endianness and return
                    return ByteSwap.Swap(result16);

                default:
                    return buffer[0];
            }
        }

        public void WriteStreamToDisk()
        {
            var myDirectory = Environment.CurrentDirectory + @"\searchdumps\";
            if (!Directory.Exists(myDirectory))
                Directory.CreateDirectory(myDirectory);
            var myFile = myDirectory + "dump" + _fileNumber + ".dmp";

            WriteStreamToDisk(myFile);
        }

        public void WriteStreamToDisk(string filepath)
        {
            var foo = new FileStream(filepath, FileMode.Create);
            foo.Write(mem, 0, (int) (EndAddress - StartAddress));
            foo.Close();
            foo.Dispose();
        }
    }
}