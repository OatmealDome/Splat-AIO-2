using SplatAIO.Logic.Singleplayer;
using SplatAIO.Properties;
using System;
using System.Windows.Forms;

namespace SplatAIO.UI.Singleplayer
{
    public partial class EditLevelDataForm : Form
    {
        private LevelDataHax _levelDatahHax;
        public LevelData LevelData { get; private set; }

        public EditLevelDataForm(LevelDataHax levelDatahHax)
        {
            InitializeComponent();
            _levelDatahHax = levelDatahHax;
        }

        public EditLevelDataForm(LevelDataHax levelDatahHax, LevelData levelData)
            : this(levelDatahHax)
        {
            LevelData = levelData;

            if (LevelData.LevelNumber >= 0x65) // boss stages are 0x65 and up
            {
                levelBox.SelectedIndex = Convert.ToInt32(LevelData.LevelNumber - 0x65);
            }                
            else
            {
                levelBox.SelectedIndex = Convert.ToInt32(LevelData.LevelNumber + 0x4);
            }                

            // disable the level box
            levelBox.Enabled = false;

            // 0x1 is skipped in clearState
            clearStateBox.SelectedIndex = Convert.ToInt32(LevelData.ClearState - (LevelData.ClearState != 0 ? 1 : 0));
            scrollBox.Checked = LevelData.Scroll;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (levelBox.SelectedIndex == -1 || clearStateBox.SelectedIndex == -1)
            {
                MessageBox.Show(Strings.FILL_IN_ALL_FIELDS_TEXT);
                return;
            }

            uint levelNumber = 0;
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
                foreach (var data in _levelDatahHax.LevelData)
                    if (data.LevelNumber == levelNumber)
                    {
                        // Refuse to save
                        MessageBox.Show(Strings.LEVEL_ALREADY_ADDED_TEXT);
                        return;
                    }
            }

            uint selectedState = Convert.ToUInt32(clearStateBox.SelectedIndex);
            uint clearState = selectedState != 0 ? selectedState + 1 : selectedState;
            LevelData = new LevelData(levelNumber, clearState, scrollBox.Checked);

            Close();
        }
    }
}