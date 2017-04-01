using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Memory;
using SplatAIO.Logic.Singleplayer;
using SplatAIO.Properties;
using System;
using System.Windows.Forms;

namespace SplatAIO.UI.Singleplayer
{
    public partial class SinglePlayerForm : Form
    {
        private readonly SingleAssemblyComponentResourceManager _editFormResources =
            new SingleAssemblyComponentResourceManager(typeof(EditLevelDataForm));
        
        private LevelDataHax LevelDataHax { get; set; }
        private EnvironmentHax EnvironmentHax { get; set; }
        private UpgradesHax UpgradesHax { get; set; }

        public SinglePlayerForm()
        {
            InitializeComponent();
            LevelDataHax = new LevelDataHax(TCPGecko.Instance(), MemoryUtils.Offset);
            EnvironmentHax = new EnvironmentHax(TCPGecko.Instance(), MemoryUtils.Offset);
            UpgradesHax = new UpgradesHax(TCPGecko.Instance(), MemoryUtils.Offset);
        }

        private void SinglePlayerForm_Load(object sender, EventArgs e)
        {
            LevelDataHax.LoadLevelData();
            // load the list view
            ReloadListView();

            // load power eggs
            powerEggsBox.Value = UpgradesHax.GetPowerEggs();

            // load upgrades
            heroShotBox.SelectedIndex = Convert.ToInt32(UpgradesHax.GetHeroShot());
            inkTankBox.SelectedIndex = Convert.ToInt32(UpgradesHax.GetInkTank());
            splatBombBox.SelectedIndex = Convert.ToInt32(UpgradesHax.GetSplatBomb());

            // for these upgrades, 0xFFFFFFFF = locked
            var burstBomb = UpgradesHax.GetBurstBomb();
            burstBombBox.SelectedIndex = burstBomb == uint.MaxValue ? 0 : Convert.ToInt32(burstBomb + 1);

            var seeker = UpgradesHax.GetSeeker();
            seekerBox.SelectedIndex = seeker == uint.MaxValue ? 0 : Convert.ToInt32(seeker + 1);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            LevelDataHax.FillSaveSlots();
            // poke power eggs
            UpgradesHax.SetPowerEggs(Convert.ToUInt32(powerEggsBox.Value));
            // poke upgrades
            UpgradesHax.SetHeroShot(Convert.ToUInt32(heroShotBox.SelectedIndex));
            UpgradesHax.SetInkTank(Convert.ToUInt32(inkTankBox.SelectedIndex));
            UpgradesHax.SetSplatBomb(Convert.ToUInt32(splatBombBox.SelectedIndex));

            // for these upgrades, 0xFFFFFFFF = locked // uint.MaxValue = 0xFFFFFFFF
            UpgradesHax.SetBurstBomb(burstBombBox.SelectedIndex == 0
                ? uint.MaxValue
                : Convert.ToUInt32(burstBombBox.SelectedIndex - 1));
            UpgradesHax.SetSeeker(seekerBox.SelectedIndex == 0
                ? uint.MaxValue
                : Convert.ToUInt32(seekerBox.SelectedIndex - 1));
        }

        private void clearEnvironmentButton_Click(object sender, EventArgs e)
        {
            EnvironmentHax.ClearEnvironmentFlags();
        }

        private void setEnvironmentButton_Click(object sender, EventArgs e)
        {
            EnvironmentHax.SetAllEnvironmentFlags();
        }

        private void resetAllButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(Strings.SINGLE_PLAYER_RESET_TITLE, Strings.SINGLE_PLAYER_RESET_TEXT, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Reset environment flags
                clearEnvironmentButton_Click(null, null);

                // Reset levels
                LevelDataHax.ClearLevelData();
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
                var progression = TCPGecko.Instance().peek(ProgressBitsForm.progressBitsAddress + MemoryUtils.Offset);

                ProgressBitsForm.SetFlag(ref progression, 0x10, false); // octo valley intro
                ProgressBitsForm.SetFlag(ref progression, 0x80, false); // great zapfish returned
                ProgressBitsForm.SetFlag(ref progression, 0x100, false); // credits block available

                TCPGecko.Instance().poke32(ProgressBitsForm.progressBitsAddress + MemoryUtils.Offset, progression);
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
            new EditLevelDataForm(LevelDataHax, LevelDataHax.GetLevelData(levelDataView.SelectedIndices[0])).ShowDialog(this);

            ReloadListView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelDataHax.RemoveLevelData(levelDataView.SelectedIndices[0]);
            ReloadListView();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editLevelDataForm = new EditLevelDataForm(LevelDataHax);
            editLevelDataForm.ShowDialog(this);

            if (editLevelDataForm.LevelData != null)
            {
                LevelDataHax.AddLevelData(editLevelDataForm.LevelData);
                ReloadListView();
            }
        }

        private void ReloadListView()
        {
            levelDataView.Items.Clear();
            foreach (var data in LevelDataHax.LevelData)
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
                        return _editFormResources.GetString("levelBox.Items");
                    case 0x66:
                        return _editFormResources.GetString("levelBox.Items1");
                    case 0x67:
                        return _editFormResources.GetString("levelBox.Items2");
                    case 0x68:
                        return _editFormResources.GetString("levelBox.Items3");
                    case 0x69:
                        return _editFormResources.GetString("levelBox.Items4");
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
                    return _editFormResources.GetString("clearStateBox.Items");
                case 0x2:
                    return _editFormResources.GetString("clearStateBox.Items1");
                case 0x3:
                    return _editFormResources.GetString("clearStateBox.Items2");
                default:
                    throw new Exception(Strings.INVALID_CLEAR_STATE + " (clearState = " + clearState + ")");
            }
        }
    }
}