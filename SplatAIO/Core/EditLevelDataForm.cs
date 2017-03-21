using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO.Core
{
    public partial class EditLevelDataForm : Form
    {
        public LevelData levelData = null;

        public EditLevelDataForm()
        {
            InitializeComponent();
        }

        public EditLevelDataForm(LevelData levelData)
        {
            InitializeComponent();

            this.levelData = levelData;
            uint levelNumber = levelData.levelNumber;
            uint clearState = levelData.clearState;

            if (levelNumber >= 0x65) // boss stages are 0x65 and up
            {
                // bosses come first in the level list
                levelBox.SelectedIndex = Convert.ToInt32(levelNumber - 0x65);
            }
            else
            {
                // levels come after bosses
                levelBox.SelectedIndex = Convert.ToInt32(levelNumber + 0x4);
            }

            // disable the level box
            levelBox.Enabled = false;

            // 0x1 is skipped in clearState
            clearStateBox.SelectedIndex = Convert.ToInt32((clearState != 0x0) ? clearState - 1 : clearState);

            scrollBox.Checked = levelData.scroll;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (levelBox.SelectedIndex == -1 || clearStateBox.SelectedIndex == -1)
            {
                MessageBox.Show(Properties.Strings.FILL_IN_ALL_FIELDS_TEXT);
                return;
            }

            uint levelNumber = 0x0;
            uint clearState = 0x0;
            bool scroll = false;

            if (levelBox.SelectedIndex <= 4) // bosses come first in the list
            {
                levelNumber = Convert.ToUInt32(levelBox.SelectedIndex + 0x65);
            }
            else
            {
                levelNumber = Convert.ToUInt32(levelBox.SelectedIndex - 0x4);
            }

            if (levelBox.Enabled) // we're in edit mode if this is disabled
            {
                // check to make sure that this isn't already in the list
                SinglePlayerForm singlePlayerForm = (SinglePlayerForm)this.Owner;
                foreach (LevelData data in singlePlayerForm.levelSaveData)
                {
                    if (data.levelNumber == levelNumber)
                    {
                        // Refuse to save
                        MessageBox.Show(Properties.Strings.LEVEL_ALREADY_ADDED_TEXT);
                        return;
                    }
                }
            }

            uint selectedState = Convert.ToUInt32(clearStateBox.SelectedIndex);
            clearState = (selectedState != 0) ? selectedState + 1 : selectedState;

            scroll = scrollBox.Checked;

            if (levelData == null)
            {
                levelData = new LevelData(levelNumber, clearState, scroll);
            }
            else
            {
                levelData.levelNumber = levelNumber;
                levelData.clearState = clearState;
                levelData.scroll = scroll;
            }

            this.Close();
        }
    }
}
