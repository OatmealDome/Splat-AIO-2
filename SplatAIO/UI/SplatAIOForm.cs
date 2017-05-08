using SplatAIO.Logic;
using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks;
using SplatAIO.Logic.Hacks.Octohax;
using SplatAIO.Logic.Hacks.ProgressHax;
using SplatAIO.Logic.Hacks.Singleplayer;
using SplatAIO.Logic.Hacks.Sisterhax;
using SplatAIO.Logic.Hacks.Unlock;
using SplatAIO.Logic.Hacks.Weapons;
using SplatAIO.Logic.Memory;
using SplatAIO.Properties;
using SplatAIO.Statistics;
using SplatAIO.UI.ProgressHax;
using SplatAIO.UI.Singleplayer;
using SplatAIO.UI.TimerHax;
using SplatAIO.UI.Weapons;
using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SplatAIO.UI
{
    public partial class SplatAIOForm : Form
    {
        private SplatAIOCore SplatAIOCore { get; set; }
        private GearUnlocker GearUnlocker { get; set; }
        private OctohaxLogic OctohaxLogic { get; set; }
        private SisterhaxLogic SisterhaxLogic { get; set; }
        private MinigamesUnlocker MinigamesUnlocker { get; set; }

        public SplatAIOForm()
        {
            InitializeComponent();
        }
                
        private bool SendStats { get; set; }

        private TCPGecko _gecko;

        private void Form1_Load(object sender, EventArgs e)
        {
            var checker = new Checker();
            if (checker.getdata() == 0 && checker.ver > GetCurrentVersion())
            {
                checker.ShowDialog();
            }

            Configuration.Load();
            ipBox.Text = Configuration.CurrentConfig.LastIp;

            Text += " (" + Assembly.GetExecutingAssembly().GetName().Version + ")";

            if (Configuration.CurrentConfig.AllowStatistics)
            {
                SendStats = StatisticTransmitter.WorkingConnection();
            }
            else
            {
                SendStats = false;
            }
        }

        private void connectBox_Click(object sender, EventArgs e)
        {
            _gecko = TCPGecko.Instance(ipBox.Text);

            try
            {
                _gecko.Connect();
            }
            catch (ETCPGeckoException)
            {
                MessageBox.Show(Strings.CONNECTION_FAILED_TEXT);
            }
            catch (SocketException)
            {
                MessageBox.Show(Strings.INVALID_IP_TEXT);
            }

            //offset difference checker
            var JRAddr = _gecko.peek(0x106E975C) + 0x92D8;
            if (_gecko.peek(JRAddr) == 0x000003F2)
            {
                MemoryUtils.Offset = JRAddr - 0x12CDADA0;
            }
            else
            {
                MessageBox.Show(Strings.FIND_DIFF_FAILED_TEXT);

                _gecko.Disconnect();
                return;
            }

            // do a version check using "ToHu" of "ToHuman"
            if (_gecko.peek((uint) OctohaxAddress.Player00 + 0x50) != 0x546F4875)
            {
                MessageBox.Show(Strings.VERSION_CHECK_FAILED_TEXT);

                _gecko.Disconnect();
                return;
            }

            Configuration.CurrentConfig.LastIp = ipBox.Text;
            Configuration.Save();

            connectBox.Enabled = false;
            disconnectBox.Enabled = true;

            load();
        }

        public void release()
        {
            rankBox.Enabled = true;
            ipBox.Enabled = false;
            kaneBox.Enabled = true;
            sazaeBox.Enabled = true;
            udeBox.Enabled = true;
            maeBox.Enabled = true;
            progressFlagsBox.Enabled = true;
            genderBox.Enabled = true;
            eyeBox.Enabled = true;
            skinBox.Enabled = true;
            amiiboBox.Enabled = true;
            ikaBox.Enabled = true;
            takoBox.Enabled = true;
            aoriBox.Enabled = true;
            hotaruBox.Enabled = true;
            swapBox.Enabled = true;
            normalBox.Enabled = true;
            gameButton.Enabled = true;
            bukiButton.Enabled = true;
            gearButton.Enabled = true;
            refreshButton.Enabled = true;
            OKButton.Enabled = true;
            menuStrip.Enabled = true;
            checkBox1.Enabled = true;
            autoRefreshTimer.Enabled = true;
        }

        public void hold()
        {
            rankBox.Enabled = false;
            ipBox.Enabled = true;
            kaneBox.Enabled = false;
            sazaeBox.Enabled = false;
            udeBox.Enabled = false;
            maeBox.Enabled = false;
            progressFlagsBox.Enabled = false;
            genderBox.Enabled = false;
            eyeBox.Enabled = false;
            skinBox.Enabled = false;
            amiiboBox.Enabled = false;
            ikaBox.Enabled = false;
            aoriBox.Enabled = false;
            hotaruBox.Enabled = false;
            takoBox.Enabled = false;
            swapBox.Enabled = false;
            normalBox.Enabled = false;
            gameButton.Enabled = false;
            bukiButton.Enabled = false;
            gearButton.Enabled = false;
            refreshButton.Enabled = false;
            OKButton.Enabled = false;
            menuStrip.Enabled = false;
            checkBox1.Enabled = false;
            autoRefreshTimer.Enabled = false;
        }

        public void load()
        {
            hold();

            SplatAIOCore = new SplatAIOCore(_gecko, MemoryUtils.Offset);
            GearUnlocker = new GearUnlocker(_gecko, MemoryUtils.Offset);
            MinigamesUnlocker = new MinigamesUnlocker(_gecko, MemoryUtils.Offset);
            OctohaxLogic = new OctohaxLogic(_gecko);
            SisterhaxLogic = new SisterhaxLogic(_gecko);

            SplatAIOCore.loadValues();

            try
            {
                rankBox.Value = SplatAIOCore.Rank;
            }
            catch (ArgumentOutOfRangeException)
            {
                var rankDisplay = fixStuff(Strings.BAD_RANK_1, SplatAIOCore.Rank, Strings.BAD_RANK_2, 0x12CDC1A8, 49, 50, 1);
                rankBox.Value = rankDisplay;
            }

            try
            {
                kaneBox.Value = SplatAIOCore.Okane;
            }
            catch (ArgumentOutOfRangeException)
            {
                var OkaneDisplay = fixStuff(Strings.BAD_OKANE_1, SplatAIOCore.Okane, Strings.BAD_OKANE_2, 0x12CDC1A0, 9999999,
                    9999999, 0);
                kaneBox.Value = OkaneDisplay;
            }

            try
            {
                maeBox.Value = SplatAIOCore.Mae;
            }
            catch (ArgumentOutOfRangeException)
            {
                var maeDisplay = fixStuff(Strings.BAD_MAE_1, SplatAIOCore.Mae, Strings.BAD_MAE_2, 0x12CDC1B0, 99, 99, 0);
                maeBox.Value = maeDisplay;
            }

            try
            {
                sazaeBox.Value = SplatAIOCore.Sazae;
            }
            catch (ArgumentOutOfRangeException)
            {
                var sazaeDisplay = fixStuff(Strings.BAD_SAZAE_1, SplatAIOCore.Sazae, Strings.BAD_SAZAE_2, 0x12CDC1B4, 999, 999, 0);
                sazaeBox.Value = sazaeDisplay;
            }

            try
            {
                udeBox.SelectedIndex = SplatAIOCore.Ude;
            }
            catch (ArgumentOutOfRangeException)
            {
                var udeDisplay = fixStuff(Strings.BAD_UDE_1, SplatAIOCore.Ude, Strings.BAD_UDE_2, 0x12CDC1AC, 10, 10, 0);
                udeBox.SelectedIndex = udeDisplay;
            }

            try
            {
                genderBox.SelectedIndex = SplatAIOCore.Gender;
            }
            catch (ArgumentOutOfRangeException)
            {
                genderBox.SelectedIndex = 0;
                SplatAIOCore.PokeGender(0);
            }

            if (SplatAIOCore.Amiibo == UInt32.MaxValue)
                amiiboBox.SelectedIndex = 0;
            else
                amiiboBox.SelectedIndex = Convert.ToInt32(SplatAIOCore.Amiibo + 1);

            eyeBox.SelectedIndex = SplatAIOCore.Eyes;
            skinBox.SelectedIndex = SplatAIOCore.Skin;
            release();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            load();
        }

        private void disconnectBox_Click(object sender, EventArgs e)
        {
            disconnectBox.Enabled = false;
            hold();
            _gecko.Disconnect();
            connectBox.Enabled = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            hold();

            if (SendStats)
            {
                if (kaneBox.Value != SplatAIOCore.Okane)
                {
                    StatisticTransmitter.WriteToSlot(0, Math.Abs(kaneBox.Value - SplatAIOCore.Okane));
                }
                if (rankBox.Value != SplatAIOCore.Rank)
                {
                    StatisticTransmitter.WriteToSlot(3, Math.Abs(rankBox.Value - SplatAIOCore.Rank));
                }
                if (sazaeBox.Value != SplatAIOCore.Sazae)
                {
                    StatisticTransmitter.WriteToSlot(1, Math.Abs(sazaeBox.Value - SplatAIOCore.Sazae));
                }
                if (eyeBox.SelectedIndex != SplatAIOCore.Eyes)
                {
                    StatisticTransmitter.WriteToSlot(5, 1);
                }
                if (genderBox.SelectedIndex != SplatAIOCore.Gender)
                {
                    StatisticTransmitter.WriteToSlot(4, 1);
                }
                if (skinBox.SelectedIndex != SplatAIOCore.Skin)
                {
                    StatisticTransmitter.WriteToSlot(6, 1);
                }
                if (udeBox.SelectedIndex != SplatAIOCore.Ude || maeBox.Value != SplatAIOCore.Mae)
                {
                    StatisticTransmitter.WriteToSlot(2, 1);
                }
            }

            SplatAIOCore.PokeRank(Convert.ToUInt32(rankBox.Value));
            SplatAIOCore.PokeOkane(Convert.ToUInt32(kaneBox.Value));
            SplatAIOCore.PokeUde(Convert.ToUInt32(udeBox.SelectedIndex));
            SplatAIOCore.PokeMae(Convert.ToUInt32(maeBox.Value));
            SplatAIOCore.PokeSazae(Convert.ToUInt32(sazaeBox.Value));
            SplatAIOCore.PokeGender(Convert.ToUInt32(genderBox.SelectedIndex));
            SplatAIOCore.PokeEyes(Convert.ToUInt32(eyeBox.SelectedIndex));
            SplatAIOCore.PokeSkin(Convert.ToUInt32(skinBox.SelectedIndex));
            PokeAmiibo();

            release();
        }

        public int fixStuff(string str1, int invalid, string str2, uint fixAddress, int newPokeVal, int newVal,
            int noVal)
        {
            var fix = MessageBox.Show(str1 + invalid + str2, Strings.INVALID, MessageBoxButtons.YesNo);
            if (fix == DialogResult.Yes)
            {
                _gecko.poke32(fixAddress + MemoryUtils.Offset, Convert.ToUInt32(newPokeVal));
                return newVal;
            }
            return noVal;
        }

        public void PokeAmiibo()
        {
            if (amiiboBox.SelectedIndex == 0) // none / nashi
            {
                SplatAIOCore.PokeAmiibo(UInt32.MaxValue);
            }
            else
            {
                SplatAIOCore.PokeAmiibo(Convert.ToUInt32(amiiboBox.SelectedIndex - 1));
                if (SendStats)
                {
                    StatisticTransmitter.WriteToSlot(7, 1);
                }
            }
        }
        

        private void progressFlagsBox_Click(object sender, EventArgs e)
        {
            new ProgressFlagsForm().ShowDialog(this);
        }

        private void ikaBox_Click(object sender, EventArgs e)
        {
            OctohaxLogic.switchToSquid();
        }

        private void takoBox_Click(object sender, EventArgs e)
        {
            OctohaxLogic.switchToOctopus();
        }

        private void aoriBox_Click(object sender, EventArgs e)
        {
            SisterhaxLogic.ChangeModels(SisterhaxMode.Aori);
        }

        private void hotaruBox_Click(object sender, EventArgs e)
        {
            SisterhaxLogic.ChangeModels(SisterhaxMode.Hotaru);
        }

        private void swapBox_Click(object sender, EventArgs e)
        {
            SisterhaxLogic.ChangeModels(SisterhaxMode.Swap);
        }

        private void normalBox_Click(object sender, EventArgs e)
        {
            SisterhaxLogic.ChangeModels(SisterhaxMode.Normal);
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            MinigamesUnlocker.UnlockMinigames();
        }

        private void bukiButton_Click(object sender, EventArgs e)
        {
            WeaponsHax.PokeWeapons(WeaponDatabase.Weapons, _gecko, MemoryUtils.Offset);
        }
        
        private void gearButton_Click_1(object sender, EventArgs e)
        {
            GearUnlocker.PokeHats();
            GearUnlocker.PokeClothes();
            GearUnlocker.PokeShoes();
        }

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SinglePlayerForm().ShowDialog(this);
        }

        private void timerHaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TimerHaxForm(_gecko).ShowDialog(this);
        }

        private void weaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WeaponsForm().ShowDialog(this);
        }        

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //autorefresh checkbox
        {
            autoRefreshTimer.Enabled = checkBox1.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e) //refresh on interval
        {
            if (autoRefreshTimer.Enabled)
            {
                load();
            }
        }

        public static int GetCurrentVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var builder = new StringBuilder(version.Length);

            for (var i = 0; i < version.Length; i++)
            {
                if (!version[i].Equals('.'))
                {
                    builder.Append(version[i]);
                }
            }
            return Convert.ToInt32(builder.ToString());
        }
    }
}