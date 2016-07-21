using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatAIO
{
    public class LevelData
    {
        public uint levelNumber;
        public uint clearState;
        public bool scroll;

        public LevelData(uint levelNumber, uint clearState, bool scroll)
        {
            this.levelNumber = levelNumber;
            this.clearState = clearState;
            this.scroll = scroll;
        }

        public override String ToString()
        {
            return "LevelData: levelNumber = " + levelNumber + ", clearState = " + clearState + ", scroll = " + scroll;
        }
    }
}
