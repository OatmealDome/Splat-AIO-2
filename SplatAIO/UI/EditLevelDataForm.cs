using System;
using System.Windows.Forms;
using SplatAIO.Logic;
using SplatAIO.Properties;

namespace SplatAIO.UI
{
    public partial class EditLevelDataForm : Form
    {
        public LevelData levelData;

        public EditLevelDataForm()
        {
            InitializeComponent();
        }

        public EditLevelDataForm(LevelData levelData)
        {
            InitializeComponent();

            this.levelData = levelData;
            var levelNumber = levelData.LevelNumber;
            var clearState = levelData.ClearState;

            if (levelNumber >= 0x65) // boss stages are 0x65 and up
                levelBox.SelectedIndex = Convert.ToInt32(levelNumber - 0x65);
            else
                levelBox.SelectedIndex = Convert.ToInt32(levelNumber + 0x4);

            // disable the level box
            levelBox.Enabled = false;

            // 0x1 is skipped in clearState
            clearStateBox.SelectedIndex = Convert.ToInt32(clearState != 0x0 ? clearState - 1 : clearState);

            scrollBox.Checked = levelData.Scroll;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (levelBox.SelectedIndex == -1 || clearStateBox.SelectedIndex == -1)
            {
                MessageBox.Show(Strings.FILL_IN_ALL_FIELDS_TEXT);
                return;
            }

            uint levelNumber = 0x0;
            uint clearState = 0x0;
            var scroll = false;

            if (levelBox.SelectedIndex <= 4) // bosses come first in the list
                levelNumber = Convert.ToUInt32(levelBox.SelectedIndex + 0x65);
            else
                levelNumber = Convert.ToUInt32(levelBox.SelectedIndex - 0x4);

            if (levelBox.Enabled) // we're in edit mode if this is disabled
            {
                // check to make sure that this isn't already in the list
                var singlePlayerForm = (SinglePlayerForm) Owner;
                foreach (var data in singlePlayerForm.levelSaveData)
                    if (data.LevelNumber == levelNumber)
                    {
                        // Refuse to save
                        MessageBox.Show(Strings.LEVEL_ALREADY_ADDED_TEXT);
                        return;
                    }
            }

            var selectedState = Convert.ToUInt32(clearStateBox.SelectedIndex);
            clearState = selectedState != 0 ? selectedState + 1 : selectedState;

            scroll = scrollBox.Checked;

            if (levelData == null)
            {
                levelData = new LevelData(levelNumber, clearState, scroll);
            }
            else
            {
                levelData.LevelNumber = levelNumber;
                levelData.ClearState = clearState;
                levelData.Scroll = scroll;
            }

            Close();
        }
    }
}