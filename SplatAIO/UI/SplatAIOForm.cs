using SplatAIO.Logic;
using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.Octohax;
using SplatAIO.Logic.Hacks.Sisterhax;
using SplatAIO.Logic.Hacks.Unlock;
using SplatAIO.Logic.Memory.Addresses;
using SplatAIO.Logic.Statistics;
using SplatAIO.Logic.Weapons;
using SplatAIO.Properties;
using SplatAIO.UI.Singleplayer;
using SplatAIO.UI.TimerHax;
using SplatAIO.UI.Weapons;
using System;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SplatAIO.UI
{
    public partial class SplatAIOForm : Form
    {
        private GearUnlocker GearUnlocker { get; set; }
        private OctohaxLogic OctohaxLogic { get; set; }
        private SisterhaxLogic SisterhaxLogic { get; set; }

        public SplatAIOForm()
        {
            InitializeComponent();
        }

        //general vars

        public int Rank { get; set; }
        public int Okane { get; set; }
        public int Ude { get; set; }
        public int Mae { get; set; }
        public int Sazae { get; set; }
        public int Gender { get; set; }
        public int Eyes { get; set; }
        public int Skin { get; set; }
        public uint Figure { get; set; }
        public uint Offset { get; set; }
        public TCPGecko Gecko { get; set; }
        public bool SendStats { get; set; }
        public bool AutoRefresh { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            var checker = new Checker();
            if (checker.getdata() == 0 && checker.ver > GetCurrentVersion())
                checker.ShowDialog();

            Configuration.Load();
            ipBox.Text = Configuration.CurrentConfig.LastIp;

            Text += " (" + Assembly.GetExecutingAssembly().GetName().Version + ")";

            if (Configuration.CurrentConfig.AllowStatistics)
                SendStats = StatisticTransmitter.WorkingConnection();
            else
                SendStats = false;
        }

        private void connectBox_Click(object sender, EventArgs e)
        {
            Gecko = new TCPGecko(ipBox.Text);

            try
            {
                Gecko.Connect();
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
            var JRAddr = Gecko.peek(0x106E975C) + 0x92D8;
            if (Gecko.peek(JRAddr) == 0x000003F2)
            {
                Offset = JRAddr - 0x12CDADA0;
            }
            else
            {
                MessageBox.Show(Strings.FIND_DIFF_FAILED_TEXT);

                Gecko.Disconnect();
                return;
            }

            // do a version check using "ToHu" of "ToHuman"
            if (Gecko.peek((uint) OctohaxAddress.Player00 + 0x50) != 0x546F4875)
            {
                MessageBox.Show(Strings.VERSION_CHECK_FAILED_TEXT);

                Gecko.Disconnect();
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

            GearUnlocker = new GearUnlocker(Gecko, Offset);
            OctohaxLogic = new OctohaxLogic(Gecko);
            SisterhaxLogic = new SisterhaxLogic(Gecko);
            Rank = Convert.ToInt32(Gecko.peek((uint) Player.Rank + Offset)) + 1;
            Okane = Convert.ToInt32(Gecko.peek((uint) Player.Okane + Offset));
            Ude = Convert.ToInt32(Gecko.peek((uint) Player.Ude + Offset));
            Mae = Convert.ToInt32(Gecko.peek((uint) Player.Mae + Offset));
            Sazae = Convert.ToInt32(Gecko.peek((uint) Player.Sazae + Offset));
            Gender = Convert.ToInt32(Gecko.peek((uint) Player.Gender + Offset));
            Eyes = Convert.ToInt32(Gecko.peek((uint) Player.Eyes + Offset));
            Skin = Convert.ToInt32(Gecko.peek((uint) Player.Skin + Offset));
            Figure = Gecko.peek((uint) Player.Amiibo + Offset);

            try
            {
                rankBox.Value = Rank;
            }
            catch (ArgumentOutOfRangeException)
            {
                var rankDisplay = fixStuff(Strings.BAD_RANK_1, Rank, Strings.BAD_RANK_2, 0x12CDC1A8, 49, 50, 1);
                rankBox.Value = rankDisplay;
            }

            try
            {
                kaneBox.Value = Okane;
            }
            catch (ArgumentOutOfRangeException)
            {
                var OkaneDisplay = fixStuff(Strings.BAD_OKANE_1, Okane, Strings.BAD_OKANE_2, 0x12CDC1A0, 9999999,
                    9999999, 0);
                kaneBox.Value = OkaneDisplay;
            }

            try
            {
                maeBox.Value = Mae;
            }
            catch (ArgumentOutOfRangeException)
            {
                var maeDisplay = fixStuff(Strings.BAD_MAE_1, Mae, Strings.BAD_MAE_2, 0x12CDC1B0, 99, 99, 0);
                maeBox.Value = maeDisplay;
            }

            try
            {
                sazaeBox.Value = Sazae;
            }
            catch (ArgumentOutOfRangeException)
            {
                var sazaeDisplay = fixStuff(Strings.BAD_SAZAE_1, Sazae, Strings.BAD_SAZAE_2, 0x12CDC1B4, 999, 999, 0);
                sazaeBox.Value = sazaeDisplay;
            }

            try
            {
                udeBox.SelectedIndex = Ude;
            }
            catch (ArgumentOutOfRangeException)
            {
                var udeDisplay = fixStuff(Strings.BAD_UDE_1, Ude, Strings.BAD_UDE_2, 0x12CDC1AC, 10, 10, 0);
                udeBox.SelectedIndex = udeDisplay;
            }

            try
            {
                genderBox.SelectedIndex = Gender;
            }
            catch (ArgumentOutOfRangeException)
            {
                genderBox.SelectedIndex = 0;
                Gecko.poke32((uint) Player.Gender, 0x00000000);
            }

            if (Figure == 0xFFFFFFFF)
                amiiboBox.SelectedIndex = 0;
            else
                amiiboBox.SelectedIndex = Convert.ToInt32(Figure + 1);

            eyeBox.SelectedIndex = Eyes;
            skinBox.SelectedIndex = Skin;
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
            Gecko.Disconnect();
            connectBox.Enabled = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            hold();

            if (SendStats)
            {
                if (kaneBox.Value != Okane)
                    StatisticTransmitter.WriteToSlot(0, Math.Abs(kaneBox.Value - Okane));
                if (rankBox.Value != Rank)
                    StatisticTransmitter.WriteToSlot(3, Math.Abs(rankBox.Value - Rank));
                if (sazaeBox.Value != Sazae)
                    StatisticTransmitter.WriteToSlot(1, Math.Abs(sazaeBox.Value - Sazae));
                if (eyeBox.SelectedIndex != Eyes)
                    StatisticTransmitter.WriteToSlot(5, 1);
                if (genderBox.SelectedIndex != Gender)
                    StatisticTransmitter.WriteToSlot(4, 1);
                if (skinBox.SelectedIndex != Skin)
                    StatisticTransmitter.WriteToSlot(6, 1);
                if (udeBox.SelectedIndex != Ude || maeBox.Value != Mae)
                    StatisticTransmitter.WriteToSlot(2, 1);
            }

            pokeRank((uint) Player.Rank + Offset); // rank
            Gecko.poke32((uint) Player.Okane + Offset, Convert.ToUInt32(kaneBox.Value)); // Okane
            Gecko.poke32((uint) Player.Ude + Offset, Convert.ToUInt32(udeBox.SelectedIndex)); // ude
            Gecko.poke32((uint) Player.Mae + Offset, Convert.ToUInt32(maeBox.Value)); // mae
            Gecko.poke32((uint) Player.Sazae + Offset, Convert.ToUInt32(sazaeBox.Value)); // sazae
            Gecko.poke32((uint) Player.Gender + Offset, Convert.ToUInt32(genderBox.SelectedIndex)); // gender
            Gecko.poke32((uint) Player.Eyes + Offset, Convert.ToUInt32(eyeBox.SelectedIndex)); // eyes
            Gecko.poke32((uint) Player.Skin + Offset, Convert.ToUInt32(skinBox.SelectedIndex)); // skin
            pokeAmiibo((uint) Player.Amiibo + Offset); // amiibo

            release();
        }

        public int fixStuff(string str1, int invalid, string str2, uint fixAddress, int newPokeVal, int newVal,
            int noVal)
        {
            var fix = MessageBox.Show(str1 + invalid + str2, Strings.INVALID, MessageBoxButtons.YesNo);
            if (fix == DialogResult.Yes)
            {
                Gecko.poke32(fixAddress + Offset, Convert.ToUInt32(newPokeVal));
                return newVal;
            }
            return noVal;
        }

        public void pokeRank(uint address)
        {
            var rank = Convert.ToUInt32(rankBox.Value);
            Gecko.poke32(address, rank - 1); // rank
            Gecko.poke32(address - 0x4, 0x00000000); // experience to 0

            // set progression bits appropriately
            var progression = Gecko.peek(ProgressBitsForm.progressBitsAddress + Offset);
            ProgressBitsForm.SetFlag(ref progression, 0x100000, rank >= 20);
                // rank cap flag, remove if rank < 20, set if rank >= 20
            ProgressBitsForm.SetFlag(ref progression, 0x800, rank >= 10);
                // gachi unlocked flag, remove if rank < 10, set if rank >= 10
            Gecko.poke32(ProgressBitsForm.progressBitsAddress, progression);
        }

        public void pokeAmiibo(uint address)
        {
            if (amiiboBox.SelectedIndex == 0) // none / nashi
            {
                Gecko.poke32(address, 0xFFFFFFFF);
            }
            else
            {
                Gecko.poke32(address, Convert.ToUInt32(amiiboBox.SelectedIndex - 1));
                if (SendStats)
                    StatisticTransmitter.WriteToSlot(7, 1);
            }
        }
        

        private void progressFlagsBox_Click(object sender, EventArgs e)
        {
            new ProgressBitsForm().ShowDialog(this);
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
            SisterhaxLogic.changeModels(SisterhaxMode.Aori);
        }

        private void hotaruBox_Click(object sender, EventArgs e)
        {
            SisterhaxLogic.changeModels(SisterhaxMode.Hotaru);
        }

        private void swapBox_Click(object sender, EventArgs e)
        {
            SisterhaxLogic.changeModels(SisterhaxMode.Swap);
        }

        private void normalBox_Click(object sender, EventArgs e)
        {
            SisterhaxLogic.changeModels(SisterhaxMode.Normal);
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            Gecko.poke32((uint) Player.Minigames + Offset, 0x000F0000);
        }

        private void bukiButton_Click(object sender, EventArgs e)
        {
            WeaponsForm.PokeWeapons(WeaponDatabase.Weapons, Gecko, Offset);
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
            new TimerHaxForm(Gecko).ShowDialog(this);
        }

        private void weaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var weaponsForm = new WeaponsForm(Gecko, Offset);
            weaponsForm.ShowDialog(this);
        }

        public static uint[] DumpSaveSlots(TCPGecko gecko, uint diff, uint start, uint size)
        {
            using (var memoryStream = new MemoryStream())
            {
                // dump all save slots
                gecko.Dump(start + diff, start + diff + size, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                // convert to a uint array
                var saveSlots = new uint[size / 4];
                for (var i = 0; i < saveSlots.Length; i++)
                {
                    var buffer = new byte[4];
                    memoryStream.Read(buffer, 0, 4);
                    saveSlots[i] = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
                }

                return saveSlots;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //autorefresh checkbox
        {
            if (checkBox1.Checked)
            {
                AutoRefresh = true;
                autoRefreshTimer.Enabled = true;
            }
            else
            {
                AutoRefresh = false;
                autoRefreshTimer.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //refresh on interval
        {
            if (AutoRefresh)
                load();
        }

        public static int GetCurrentVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var builder = new StringBuilder(version.Length);

            for (var i = 0; i < version.Length; i++)
                if (!version[i].Equals('.'))
                    builder.Append(version[i]);

            return Convert.ToInt32(builder.ToString());
        }
    }
}