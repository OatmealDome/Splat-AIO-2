using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SplatAIO.Logic;
using SplatAIO.Properties;

namespace SplatAIO.UI
{
    public partial class SinglePlayerForm : Form
    {
        private readonly SingleAssemblyComponentResourceManager editFormResources =
            new SingleAssemblyComponentResourceManager(typeof(EditLevelDataForm));

        private uint burstBombAddress = 0x12CDC5D8;
        private uint environmentFlagsAddress = 0x12CDC5B8;
        private uint heroShotAddress = 0x12CDC5C8;
        private uint inkTankAddress = 0x12CDC5CC;
        public List<LevelData> levelSaveData = new List<LevelData>();
        private uint powerEggsAddress = 0x12CDC5E0;
        private uint saveSlotsAddress = 0x12CDC2B8;
        private uint seekerAddress = 0x12CDC5DC;
        private uint splatBombAddress = 0x12CDC5D4;

        public SinglePlayerForm()
        {
            InitializeComponent();
        }

        private void SinglePlayerForm_Load(object sender, EventArgs e)
        {
            var mainForm = (SplatAIOForm) Owner;
            var gecko = mainForm.Gecko;

            // apply diff to the addresses
            saveSlotsAddress += mainForm.Offset;
            environmentFlagsAddress += mainForm.Offset;
            heroShotAddress += mainForm.Offset;
            inkTankAddress += mainForm.Offset;
            splatBombAddress += mainForm.Offset;
            burstBombAddress += mainForm.Offset;
            seekerAddress += mainForm.Offset;
            powerEggsAddress += mainForm.Offset;

            // dump all single player save slots
            var rawLevelData = SplatAIOForm.DumpSaveSlots(gecko, 0, saveSlotsAddress, 768);

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
                levelSaveData.Add(new LevelData(levelNumber, clearState, scroll));

                // move to next slot
                j += 3;
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
            var burstBomb = gecko.peek(burstBombAddress);
            if (burstBomb == 0xFFFFFFFF)
                burstBombBox.SelectedIndex = 0;
            else
                burstBombBox.SelectedIndex = Convert.ToInt32(burstBomb + 1);

            var seeker = gecko.peek(seekerAddress);
            if (seeker == 0xFFFFFFFF)
                seekerBox.SelectedIndex = 0;
            else
                seekerBox.SelectedIndex = Convert.ToInt32(seeker + 1);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var gecko = ((SplatAIOForm) Owner).Gecko;

            // poke save slots in the list into memory
            var currentPosition = saveSlotsAddress;
            foreach (var data in levelSaveData)
            {
                // poke values
                gecko.poke32(currentPosition, data.LevelNumber);
                gecko.poke32(currentPosition + 0x4, data.ClearState);
                gecko.poke32(currentPosition + 0x8, Convert.ToUInt32(data.Scroll));

                // move to next save slot
                currentPosition += 0xC;
            }

            // fill in the rest of the slots with dummy data
            for (var i = levelSaveData.Count; i < 64; i++)
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
                gecko.poke32(burstBombAddress, 0xFFFFFFFF);
            else
                gecko.poke32(burstBombAddress, Convert.ToUInt32(burstBombBox.SelectedIndex - 1));

            if (seekerBox.SelectedIndex == 0)
                gecko.poke32(seekerAddress, 0xFFFFFFFF);
            else
                gecko.poke32(seekerAddress, Convert.ToUInt32(seekerBox.SelectedIndex - 1));
        }

        private void clearEnvironmentButton_Click(object sender, EventArgs e)
        {
            var gecko = ((SplatAIOForm) Owner).Gecko;

            gecko.poke32(environmentFlagsAddress, 0x0);
            gecko.poke32(environmentFlagsAddress + 0x4, 0x0);
            gecko.poke32(environmentFlagsAddress + 0x8, 0x0);
            gecko.poke32(environmentFlagsAddress + 0xC, 0x0);
        }

        private void setEnvironmentButton_Click(object sender, EventArgs e)
        {
            var gecko = ((SplatAIOForm) Owner).Gecko;

            gecko.poke32(environmentFlagsAddress, 0x0);
            gecko.poke32(environmentFlagsAddress + 0x4, 0x001FFFFF);
            gecko.poke32(environmentFlagsAddress + 0x8, 0x0);
            gecko.poke32(environmentFlagsAddress + 0xC, 0x0003EFBE);
        }

        private void resetAllButton_Click(object sender, EventArgs e)
        {
            var dialogTitle = Strings.SINGLE_PLAYER_RESET_TITLE;
            var dialogString = Strings.SINGLE_PLAYER_RESET_TEXT;
            var result = MessageBox.Show(dialogString, dialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Reset environment flags
                clearEnvironmentButton_Click(null, null);

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
                OKButton_Click(null, null);

                // Reset single player flags in the Inkopolis progress bits
                var mainForm = (SplatAIOForm) Owner;
                var progression = mainForm.Gecko.peek(ProgressBitsForm.progressBitsAddress + mainForm.Offset);

                ProgressBitsForm.SetFlag(ref progression, 0x10, false); // octo valley intro
                ProgressBitsForm.SetFlag(ref progression, 0x80, false); // great zapfish returned
                ProgressBitsForm.SetFlag(ref progression, 0x100, false); // credits block available

                mainForm.Gecko.poke32(ProgressBitsForm.progressBitsAddress + mainForm.Offset, progression);
            }
        }

        private void levelDataView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (levelDataView.FocusedItem.Bounds.Contains(e.Location))
                    contextMenu.Show(Cursor.Position);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var levelData = levelSaveData[levelDataView.SelectedIndices[0]];

            var editLevelDataForm = new EditLevelDataForm(levelData);
            editLevelDataForm.ShowDialog(this);

            ReloadListView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var levelData = levelSaveData[levelDataView.SelectedIndices[0]];
            levelSaveData.Remove(levelData);

            ReloadListView();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editLevelDataForm = new EditLevelDataForm();
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

            foreach (var data in levelSaveData)
            {
                // add to the list view
                string[] rowData =
                {
                    GetLevelString(data.LevelNumber),
                    GetClearStateString(data.ClearState),
                    data.Scroll ? Strings.YES : Strings.NO
                };
                levelDataView.Items.Add(new ListViewItem(rowData));
            }
        }

        private string GetLevelString(uint levelNumber)
        {
            if (levelNumber == 0xFFFFFFFF) // placeholder level ID
                throw new Exception(Strings.INVALID_LEVEL_NUMBER + " (levelNumber = " + levelNumber + ")");
            if (levelNumber >= 0x65) // boss level numbers are 0x65 and up
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
                        throw new Exception(Strings.INVALID_LEVEL_NUMBER + " (levelNumber = " + levelNumber + ")");
                }
            return levelNumber.ToString();
        }

        private string GetClearStateString(uint clearState)
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
                    throw new Exception(Strings.INVALID_CLEAR_STATE + " (clearState = " + clearState + ")");
            }
        }
    }
}