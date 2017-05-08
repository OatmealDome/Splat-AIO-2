using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.ProgressHax;
using SplatAIO.Logic.Memory;
using System;
using System.Windows.Forms;

namespace SplatAIO.UI.ProgressHax
{
    public partial class ProgressFlagsForm : Form
    {        
        private ProgressFlags ProgressFlags { get; set; }

        public ProgressFlagsForm()
        {
            InitializeComponent();
            ProgressFlags = new ProgressFlags(TCPGecko.Instance(), MemoryUtils.Offset);
        }

        private void ProgressBitsForm_Load(object sender, EventArgs e)
        {
            tutorialBox.Checked = ProgressFlags.Tutorial;
            splatfestBox.Checked = ProgressFlags.Splatfest;
            rankedNewsBox.Checked = ProgressFlags.RankedNews;
            lobbyBox.Checked = ProgressFlags.Lobby;
            heroSuitBox.Checked = ProgressFlags.HeroSuit;
            greatZapfishBox.Checked = ProgressFlags.GreatZapfish;
            cuttlefishPostGameBox.Checked = ProgressFlags.CuttlefishPostGame;
            rankedUnlockedBox.Checked = ProgressFlags.RankedNews;
            rankShownBox.Checked = ProgressFlags.RankShown;
            snailsShownBox.Checked = ProgressFlags.SnailsShown;
            levelCapRaisedBox.Checked = ProgressFlags.LevelCapRaised;
            warningBox.Checked = ProgressFlags.Warning;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ProgressFlags.Tutorial = tutorialBox.Checked;
            ProgressFlags.Splatfest = splatfestBox.Checked;
            ProgressFlags.RankedNews = rankedNewsBox.Checked;
            ProgressFlags.Lobby = lobbyBox.Checked;
            ProgressFlags.HeroSuit = heroSuitBox.Checked;
            ProgressFlags.GreatZapfish = greatZapfishBox.Checked;
            ProgressFlags.CuttlefishPostGame = cuttlefishPostGameBox.Checked;
            ProgressFlags.RankedNews = rankedUnlockedBox.Checked;
            ProgressFlags.RankShown = rankShownBox.Checked;
            ProgressFlags.SnailsShown = snailsShownBox.Checked;
            ProgressFlags.LevelCapRaised = levelCapRaisedBox.Checked;
            ProgressFlags.Warning = warningBox.Checked;

            ProgressFlags.Apply();
        }
    }
}