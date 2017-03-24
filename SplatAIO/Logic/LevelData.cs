namespace SplatAIO.Logic
{
    public class LevelData
    {
        public uint clearState;
        public uint levelNumber;
        public bool scroll;

        public LevelData(uint levelNumber, uint clearState, bool scroll)
        {
            this.levelNumber = levelNumber;
            this.clearState = clearState;
            this.scroll = scroll;
        }

        public override string ToString()
        {
            return "LevelData: levelNumber = " + levelNumber + ", clearState = " + clearState + ", scroll = " + scroll;
        }
    }
}