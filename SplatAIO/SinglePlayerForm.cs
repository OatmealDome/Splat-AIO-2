using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO
{

    public partial class SinglePlayerForm : Form
    {
        private uint saveSlotsAddress = 0x12CDC2B8;
        private uint environmentFlagsAddress = 0x12CDC5B8;
        private uint heroShotAddress = 0x12CDC5C8;
        private uint inkTankAddress = 0x12CDC5CC;
        private uint splatBombAddress = 0x12CDC5D4;
        private uint burstBombAddress = 0x12CDC5D8;
        private uint seekerAddress = 0x12CDC5DC;
        private uint powerEggsAddress = 0x12CDC5E0;

        private readonly SingleAssemblyComponentResourceManager editFormResources = new SingleAssemblyComponentResourceManager(typeof(EditLevelDataForm));
        public List<LevelData> levelSaveData = new List<LevelData>();

        public SinglePlayerForm()
        {
            InitializeComponent();
        }

        private void SinglePlayerForm_Load(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.Owner;
            TCPGecko gecko = mainForm.Gecko;

            // apply diff to the addresses
            saveSlotsAddress += mainForm.diff;
            environmentFlagsAddress += mainForm.diff;
            heroShotAddress += mainForm.diff;
            inkTankAddress += mainForm.diff;
            splatBombAddress += mainForm.diff;
            burstBombAddress += mainForm.diff;
            seekerAddress += mainForm.diff;
            powerEggsAddress += mainForm.diff;

            // load level information
            // iterate over all 64 save slots
            uint currentPosition = saveSlotsAddress;
            for (int i = 0; i < 64; i++)
            {
                uint levelNumber = gecko.peek(currentPosition);

                // skip if an empty save slot
                if (levelNumber == 0xFFFFFFFF)
                {
                    continue;
                }

                uint clearState = gecko.peek(currentPosition + 0x4);
                bool scroll = Convert.ToBoolean(gecko.peek(currentPosition + 0x8));

                // add to the list
                levelSaveData.Add(new LevelData(levelNumber, clearState, scroll));

                // move to next save slot
                currentPosition += 0xC;
            }

            // load the list view
            ReloadListView();

            // load power eggs
            powerEggsBox.Value = Convert.ToInt32(gecko.peek(powerEggsAddress));

            // load upgrades
            heroShotBox.SelectedIndex = Convert.ToInt32(gecko.peek(heroShotAddress));
            inkTankBox.SelectedIndex = Convert.ToInt32(gecko.peek(inkTankAddress));
            splatBombBox.SelectedIndex = Convert.ToInt32(gecko.peek(splatBombAddress));

            // for these upgrades, 0xFFFFFFFF = locked
            uint burstBomb = gecko.peek(burstBombAddress);
            if (burstBomb == 0xFFFFFFFF)
            {
                burstBombBox.SelectedIndex = 0;
            }
            else
            {
                burstBombBox.SelectedIndex = Convert.ToInt32(burstBomb + 1);
            }

            uint seeker = gecko.peek(seekerAddress);
            if (seeker == 0xFFFFFFFF)
            {
                seekerBox.SelectedIndex = 0;
            }
            else
            {
                seekerBox.SelectedIndex = Convert.ToInt32(seeker + 1);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            TCPGecko gecko = ((Form1)this.Owner).Gecko;

            // poke save slots in the list into memory
            uint currentPosition = saveSlotsAddress;
            foreach (LevelData data in levelSaveData)
            {
                // poke values
                gecko.poke32(currentPosition, data.levelNumber);
                gecko.poke32(currentPosition + 0x4, data.clearState);
                gecko.poke32(currentPosition + 0x8, Convert.ToUInt32(data.scroll));

                // move to next save slot
                currentPosition += 0xC;
            }

            // fill in the rest of the slots with dummy data
            for (int i = levelSaveData.Count; i < 64; i++)
            {
                // poke values
                gecko.poke32(currentPosition, 0xFFFFFFFF);
                gecko.poke32(currentPosition + 0x4, 0x00000000);
                gecko.poke32(currentPosition + 0x8, 0x00000000);

                // move to next save slot
                currentPosition += 0xC;
            }

            // poke power eggs
            gecko.poke32(powerEggsAddress, Convert.ToUInt32(powerEggsBox.Value));

            // poke upgrades
            gecko.poke32(heroShotAddress, Convert.ToUInt32(heroShotBox.SelectedIndex));
            gecko.poke32(inkTankAddress, Convert.ToUInt32(inkTankBox.SelectedIndex));
            gecko.poke32(splatBombAddress, Convert.ToUInt32(splatBombBox.SelectedIndex));

            // for these upgrades, 0xFFFFFFFF = locked
            if (burstBombBox.SelectedIndex == 0)
            {
                gecko.poke32(burstBombAddress, 0xFFFFFFFF);
            }
            else
            {
                gecko.poke32(burstBombAddress, Convert.ToUInt32(burstBombBox.SelectedIndex - 1));
            }

            if (seekerBox.SelectedIndex == 0)
            {
                gecko.poke32(seekerAddress, 0xFFFFFFFF);
            }
            else
            {
                gecko.poke32(seekerAddress, Convert.ToUInt32(seekerBox.SelectedIndex - 1));
            }
        }

        private void clearEnvironmentButton_Click(object sender, EventArgs e)
        {
            TCPGecko gecko = ((Form1)this.Owner).Gecko;

            gecko.poke32(environmentFlagsAddress, 0x0);
            gecko.poke32(environmentFlagsAddress + 0x4, 0x0);
            gecko.poke32(environmentFlagsAddress + 0x8, 0x0);
            gecko.poke32(environmentFlagsAddress + 0xC, 0x0);
        }

        private void setEnvironmentButton_Click(object sender, EventArgs e)
        {
            TCPGecko gecko = ((Form1)this.Owner).Gecko;

            gecko.poke32(environmentFlagsAddress, 0x0);
            gecko.poke32(environmentFlagsAddress + 0x4, 0x001FFFFF);
            gecko.poke32(environmentFlagsAddress + 0x8, 0x0);
            gecko.poke32(environmentFlagsAddress + 0xC, 0x0003EFBE);
        }

        private void resetAllButton_Click(object sender, EventArgs e)
        {
            String dialogTitle = Properties.Strings.SINGLE_PLAYER_RESET_TITLE;
            String dialogString = Properties.Strings.SINGLE_PLAYER_RESET_TEXT;
            DialogResult result = MessageBox.Show(dialogString, dialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Reset environment flags
                this.clearEnvironmentButton_Click(null, null);

                // Reset levels
                levelSaveData = new List<LevelData>();
                ReloadListView();

                // reset power eggs
                powerEggsBox.Value = 0;

                // Reset upgrades
                heroShotBox.SelectedIndex = 0;
                inkTankBox.SelectedIndex = 0;
                splatBombBox.SelectedIndex = 0;
                burstBombBox.SelectedIndex = 0;
                seekerBox.SelectedIndex = 0;

                // Apply levels, upgrades, and power eggs
                this.OKButton_Click(null, null);

                // Reset single player flags in the Inkopolis progress bits
                Form1 mainForm = (Form1)this.Owner;
                uint progression = mainForm.Gecko.peek(ProgressBitsForm.progressBitsAddress + mainForm.diff);

                ProgressBitsForm.SetFlag(ref progression, 0x10, false); // octo valley intro
                ProgressBitsForm.SetFlag(ref progression, 0x80, false); // great zapfish returned
                ProgressBitsForm.SetFlag(ref progression, 0x100, false); // credits block available

                mainForm.Gecko.poke32(ProgressBitsForm.progressBitsAddress + mainForm.diff, progression);
            }
        }

        private void levelDataView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (levelDataView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenu.Show(Cursor.Position);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelData levelData = levelSaveData[levelDataView.SelectedIndices[0]];

            EditLevelDataForm editLevelDataForm = new EditLevelDataForm(levelData);
            editLevelDataForm.ShowDialog(this);

            ReloadListView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelData levelData = levelSaveData[levelDataView.SelectedIndices[0]];
            levelSaveData.Remove(levelData);

            ReloadListView();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EditLevelDataForm editLevelDataForm = new EditLevelDataForm();
            editLevelDataForm.ShowDialog(this);

            if (editLevelDataForm.levelData != null)
            {
                levelSaveData.Add(editLevelDataForm.levelData);
                ReloadListView();
            }
        }

        private void ReloadListView()
        {
            levelDataView.Items.Clear();

            foreach (LevelData data in levelSaveData)
            {
                // add to the list view
                String[] rowData = new String[]
                    {
                        GetLevelString(data.levelNumber),
                        GetClearStateString(data.clearState),
                        (data.scroll) ? Properties.Strings.YES : Properties.Strings.NO
                    };
                levelDataView.Items.Add(new ListViewItem(rowData));
            }
        }

        private String GetLevelString(uint levelNumber)
        {
            if (levelNumber == 0xFFFFFFFF) // placeholder level ID
            {
                // shouldn't happen, but just in case
                throw new Exception(Properties.Strings.INVALID_LEVEL_NUMBER + " (levelNumber = " + levelNumber + ")");
            }
            else if (levelNumber >= 0x65) // boss level numbers are 0x65 and up
            {
                switch (levelNumber)
                {
                    case 0x65:
                        return editFormResources.GetString("levelBox.Items");
                    case 0x66:
                        return editFormResources.GetString("levelBox.Items1");
                    case 0x67:
                        return editFormResources.GetString("levelBox.Items2");
                    case 0x68:
                        return editFormResources.GetString("levelBox.Items3");
                    case 0x69:
                        return editFormResources.GetString("levelBox.Items4");
                    default:
                        throw new Exception(Properties.Strings.INVALID_LEVEL_NUMBER + " (levelNumber = " + levelNumber + ")");
                }
            }
            else // regular level
            {
                return levelNumber.ToString();
            }
        }

        private String GetClearStateString(uint clearState)
        {
            switch (clearState)
            {
                case 0x0:
                    return editFormResources.GetString("clearStateBox.Items");
                case 0x2:
                    return editFormResources.GetString("clearStateBox.Items1");
                case 0x3:
                    return editFormResources.GetString("clearStateBox.Items2");
                default:
                    throw new Exception(Properties.Strings.INVALID_CLEAR_STATE + " (clearState = " + clearState + ")");
            }
        }

    }
}
