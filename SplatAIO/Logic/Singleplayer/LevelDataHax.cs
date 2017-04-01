using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.Singleplayer;
using SplatAIO.Logic.Memory;
using System;
using System.Collections.Generic;

namespace SplatAIO.Logic.Singleplayer
{
    public class LevelDataHax
    {
        private uint SaveSlotsAddress { get; set; }
        private TCPGecko Gecko { get; set; }
        public List<LevelData> LevelData { get; private set; }

        public LevelDataHax(TCPGecko gecko, uint offset)
        {
            Gecko = gecko;
            SaveSlotsAddress = (uint)WorldAddress.SaveSlots + offset;
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
                if (levelNumber == uint.MaxValue)
                {
                    break;
                }   

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
    }
}
