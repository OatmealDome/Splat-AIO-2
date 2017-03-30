using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.Singleplayer;
using SplatAIO.Logic.Memory;
using System;
using System.Collections.Generic;

namespace SplatAIO.Logic.Singleplayer
{
    public class SingleplayerLogic
    {   

        private uint BurstBombAddress { get; set; }
        private uint EnvironmentFlagsAddress { get; set; }
        private uint HeroShotAddress { get; set; }
        private uint InkTankAddress { get; set; }
        private uint PowerEggsAddress { get; set; }
        private uint SaveSlotsAddress { get; set; }
        private uint SeekerAddress { get; set; }
        private uint SplatBombAddress { get; set; }

        private TCPGecko Gecko { get; set; }
        public List<LevelData> LevelData { get; private set; }

        public SingleplayerLogic(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            SaveSlotsAddress = (uint)WorldAddress.BurstBomb + offset;
            EnvironmentFlagsAddress = (uint)WorldAddress.EnvironmentFlags + offset;
            HeroShotAddress = (uint)WorldAddress.HeroShot + offset;
            InkTankAddress = (uint)WorldAddress.InkTank + offset;
            SplatBombAddress = (uint)WorldAddress.PowerEggs + offset;
            BurstBombAddress = (uint)WorldAddress.SaveSlots + offset;
            SeekerAddress = (uint)WorldAddress.Seeker + offset;
            PowerEggsAddress = (uint)WorldAddress.SplatBomb + offset;
        }

        public void LoadLevelData()
        {
            LevelData = new List<LevelData>();
            // dump all single player save slots
            var rawLevelData = MemoryUtils.DumpSaveSlots(Gecko, 0, SaveSlotsAddress, 768);

            // read data from slots
            var j = 0;
            while (j < rawLevelData.Length)
            {
                var levelNumber = rawLevelData[j];

                // check if an empty save slot
                if (levelNumber == 0xFFFFFFFF)
                    break;

                var clearState = rawLevelData[j + 1];
                var scroll = Convert.ToBoolean(rawLevelData[j + 2]);

                // add to the list
                LevelData.Add(new LevelData(levelNumber, clearState, scroll));

                // move to next slot
                j += 3;
            }
        }

        public void ClearLevelData()
        {
            LevelData = new List<LevelData>();
        }

        public LevelData GetLevelData(int index)
        {
            return LevelData[index];
        }

        public void AddLevelData(LevelData levelData)
        {
            LevelData.Add(levelData);
        }

        public bool RemoveLevelData(int index)
        {
            return LevelData.Remove(GetLevelData(index));
        }

        public void FillSaveSlots()
        {
            var position = SaveSlotsAddress;
            foreach (var data in LevelData)
            {
                // poke values
                SetSaveSlotData(position, data.LevelNumber, data.ClearState, data.Scroll);
                // move to next save slot
                position += 0xC; // 12
            }

            // fill in the rest of the slots with dummy data
            for (var i = LevelData.Count; i < 64; i++)
            {
                // poke values
                SetSaveSlotData(position, uint.MaxValue, uint.MinValue, false);
                // move to next save slot
                position += 0xC; // 12
            }
        }

        private void SetSaveSlotData(uint address, uint level, uint clearState, bool scroll)
        {
            Gecko.poke32(address, level);
            Gecko.poke32(address + 0x4, clearState);
            Gecko.poke32(address + 0x8, Convert.ToUInt32(scroll));
        }

        public void SetAllEnvironmentFlags()
        {
            Gecko.poke32(EnvironmentFlagsAddress, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0x4, 0x001FFFFF);
            Gecko.poke32(EnvironmentFlagsAddress + 0x8, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0xC, 0x0003EFBE);
        }

        public void ClearEnvironmentFlags()
        {
            Gecko.poke32(EnvironmentFlagsAddress, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0x4, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0x8, 0);
            Gecko.poke32(EnvironmentFlagsAddress + 0xC, 0);
        }

        public void SetBurstBomb(uint value)
        {
            Gecko.poke32(BurstBombAddress, value);
        }

        public uint GetBurstBomb()
        {
            return Gecko.peek(BurstBombAddress);
        }

        public void SetEnvironmentFlags(uint value)
        {
            Gecko.poke32(EnvironmentFlagsAddress, value);
        }

        public uint GetEnvironmentFlags()
        {
            return Gecko.peek(EnvironmentFlagsAddress);
        }

        public void SetHeroShot(uint value)
        {
            Gecko.poke32(HeroShotAddress, value);
        }

        public uint GetHeroShot()
        {
            return Gecko.peek(HeroShotAddress);
        }

        public void SetInkTank(uint value)
        {
            Gecko.poke32(InkTankAddress, value);
        }

        public uint GetInkTank()
        {
            return Gecko.peek(InkTankAddress);
        }

        public void SetPowerEggs(uint value)
        {
            Gecko.poke32(PowerEggsAddress, value);
        }

        public uint GetPowerEggs()
        {
            return Gecko.peek(PowerEggsAddress);
        }

        public void SetSaveSlots(uint value)
        {
            Gecko.poke32(SaveSlotsAddress, value);
        }

        public uint GetSaveSlots()
        {
            return Gecko.peek(SaveSlotsAddress);
        }

        public void SetSeeker(uint value)
        {
            Gecko.poke32(SeekerAddress, value);
        }

        public uint GetSeeker()
        {
            return Gecko.peek(SeekerAddress);
        }

        public void SetSplatBomb(uint value)
        {
            Gecko.poke32(SplatBombAddress, value);
        }

        public uint GetSplatBomb()
        {
            return Gecko.peek(SplatBombAddress);
        }
    }
}
