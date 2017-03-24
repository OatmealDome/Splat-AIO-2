namespace SplatAIO.Logic
{
    public class LevelData
    {
        public uint ClearState { get; set; }
        public uint LevelNumber { get; set; }
        public bool Scroll { get; set; }

        public LevelData(uint levelNumber, uint clearState, bool scroll)
        {
            this.LevelNumber = levelNumber;
            this.ClearState = clearState;
            this.Scroll = scroll;
        }

        public override string ToString()
        {
            return "LevelData: levelNumber = " + LevelNumber + ", clearState = " + ClearState + ", scroll = " + Scroll;
        }
    }
}