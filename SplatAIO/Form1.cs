using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;

namespace SplatAIO {

    public partial class Form1 : Form
    {
        // Addresses (diff = 0x0)

        // Player Stuff
        private readonly uint rankAddress = 0x12CDC1A8;
        private readonly uint okaneAddress = 0x12CDC1A0;
        private readonly uint udeAddress = 0x12CDC1AC;
        private readonly uint maeAddress = 0x12CDC1B0;
        private readonly uint sazaeAddress = 0x12CDC1B4;
        private readonly uint genderAddress = 0x12CD1D90;
        private readonly uint eyesAddress = 0x12CD1D98;
        private readonly uint skinAddress = 0x12CD1D94;
        private readonly uint amiiboAddress = 0x12D1F130;
        private readonly uint minigamesAddress = 0x12CD1C40;

        // Octohax
        private readonly uint tnkSimpleOneAddress = 0x10506BC0;
        private readonly uint tnkSimpleTwoAddress = 0x105E62A0;
        private readonly uint player00Address = 0x105EF3A0;
        private readonly uint player00HlfAddress = 0x105EF3AC;
        private readonly uint rivalSquidAddress = 0x105EF3BC;
        private readonly uint tnkSimpleThreeAddress = 0x12BF4354;
        private readonly uint tnkSimpleFourAddress = 0x12BF43A0;
        private readonly uint tnkSimpleFiveAddress = 0x12BF43EC;

        // Sisterhax
        private readonly uint aoriAddress = 0x105EB5DC;
        private readonly uint hotaruAddress = 0x105EB5E8;

        // Gear
        private readonly uint weaponsAddress = 0x0;
        private readonly uint hatsAddress = 0x12CD7DA0;
        private readonly uint clothesAddress = 0x12CD4DA0;
        private readonly uint shoesAddress = 0x12CD1DA0;

        // Addresses END

        //general vars

        public int rank;
        public int okane;
        public int ude;
        public int mae;
        public int sazae;
        public int gender;
        public int eyes;
        public int skin;
        public uint figure;

        public readonly int ver = 120;

        public uint diff;
        public TCPGecko Gecko;

        public bool sendStats = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Checker checker = new Checker();
            if (checker.getdata() == 0 && checker.ver != ver)
            {
                checker.ShowDialog();
            }

            sendStats = Statistics.WorkingConnection();
        }

        private void connectBox_Click(object sender, EventArgs e)
        {
            Gecko = new TCPGecko(ipBox.Text, 7331);

            try
            {
                Gecko.Connect();
            }
            catch (ETCPGeckoException)
            {
                MessageBox.Show("Connection failed.\nTry making sure your IP is correct and that TCPGecko is not being blocked by firewalls.");
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("Invalid IP entry.");
            }

            if (Gecko.peek(0x12CDADA0) == 0x000003F2)
            {
                diff = 0x0;
            }
            else if (Gecko.peek(0x12CE2DA0) == 0x000003F2)
            {
                diff = 0x8000;
            }
            else if (Gecko.peek(0x12CE3DA0) == 0x000003F2)
            {
                diff = 0x9000;
            }
            else
            {
                MessageBox.Show("Could not find the Splattershot Jr. in memory. Try using TCPGecko from loadiine.ovh. If that does not work, then the AIO may need to be updated for a new version of Splatoon.");

                Gecko.Disconnect();
                return;
            }

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
            OKButton.Enabled = true;
            otherToolStripMenuItem.Enabled = true;
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
            OKButton.Enabled = false;
            otherToolStripMenuItem.Enabled = false;
        }

        public void load()
        {
            hold();

            rank = ToInt32(Gecko.peek(rankAddress + diff)) + 1;
            okane = ToInt32(Gecko.peek(okaneAddress + diff));
            ude = ToInt32(Gecko.peek(udeAddress + diff));
            mae = ToInt32(Gecko.peek(maeAddress + diff));
            sazae = ToInt32(Gecko.peek(sazaeAddress + diff));
            gender = ToInt32(Gecko.peek(genderAddress + diff));
            eyes = ToInt32(Gecko.peek(eyesAddress + diff));
            skin = ToInt32(Gecko.peek(skinAddress + diff));
            figure = Gecko.peek(amiiboAddress + diff);

            try
            {
                rankBox.Value = rank;
            }
            catch (ArgumentOutOfRangeException)
            {
                int rankDisplay = fixStuff(Properties.Strings.BAD_RANK_1, rank, Properties.Strings.BAD_RANK_2, 0x12CDC1A8, 49, 50, 1);
                rankBox.Value = rankDisplay;
            }

            try
            {
                kaneBox.Value = okane;
            }
            catch (ArgumentOutOfRangeException)
            {
                int okaneDisplay = fixStuff(Properties.Strings.BAD_OKANE_1, okane, Properties.Strings.BAD_OKANE_2, 0x12CDC1A0, 9999999, 9999999, 0);
                kaneBox.Value = okaneDisplay;
            }

            try
            {
                maeBox.Value = mae;
            }
            catch (ArgumentOutOfRangeException)
            {
                int maeDisplay = fixStuff(Properties.Strings.BAD_MAE_1, mae, Properties.Strings.BAD_MAE_2, 0x12CDC1B0, 99, 99, 0);
                maeBox.Value = maeDisplay;
            }

            try
            {
                sazaeBox.Value = sazae;
            }
            catch (ArgumentOutOfRangeException)
            {
                int sazaeDisplay = fixStuff(Properties.Strings.BAD_SAZAE_1, sazae, Properties.Strings.BAD_SAZAE_2, 0x12CDC1B4, 999, 999, 0);
                sazaeBox.Value = sazaeDisplay;
            }

            try
            {
                udeBox.SelectedIndex = ude;
            }
            catch (ArgumentOutOfRangeException)
            {
                int udeDisplay = fixStuff(Properties.Strings.BAD_UDE_1, ude, Properties.Strings.BAD_UDE_2, 0x12CDC1AC, 10, 10, 0);
                udeBox.SelectedIndex = udeDisplay;
            }

            try
            {
                genderBox.SelectedIndex = gender;
            }
            catch (ArgumentOutOfRangeException)
            {
                genderBox.SelectedIndex = 0;
                Gecko.poke32(genderAddress, 0x00000000);
            }

            if (figure == 0xFFFFFFFF)
            {
                amiiboBox.SelectedIndex = 0;
            }
            else
            {
                amiiboBox.SelectedIndex = ToInt32(figure + 1);
            }

            eyeBox.SelectedIndex = eyes;
            skinBox.SelectedIndex = skin;
            release();
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

            if (sendStats)
            {
                if(kaneBox.Value != okane)
                {
                    Statistics.WriteToSlot(0, Math.Abs((kaneBox.Value - okane)));
                }
                if (rankBox.Value != rank)
                {
                    Statistics.WriteToSlot(3, Math.Abs((rankBox.Value - rank)));
                }
                if (sazaeBox.Value != sazae)
                {
                    Statistics.WriteToSlot(1, Math.Abs((sazaeBox.Value - sazae)));
                }
                if (eyeBox.SelectedIndex != eyes)
                {
                    Statistics.WriteToSlot(5, 1);
                }
                if (genderBox.SelectedIndex != gender)
                {
                    Statistics.WriteToSlot(4, 1);
                }
                if (skinBox.SelectedIndex != skin)
                {
                    Statistics.WriteToSlot(6, 1);
                }
                if (udeBox.SelectedIndex != ude||maeBox.Value != mae)
                {
                    Statistics.WriteToSlot(2, 1);
                }
            }

            pokeRank(rankAddress + diff); // rank
            Gecko.poke32(okaneAddress + diff, ToUInt32(kaneBox.Value)); // okane
            Gecko.poke32(udeAddress + diff, ToUInt32(udeBox.SelectedIndex)); // ude
            Gecko.poke32(maeAddress + diff, ToUInt32(maeBox.Value)); // mae
            Gecko.poke32(sazaeAddress + diff, ToUInt32(sazaeBox.Value)); // sazae
            Gecko.poke32(genderAddress + diff, ToUInt32(genderBox.SelectedIndex)); // gender
            Gecko.poke32(eyesAddress + diff, ToUInt32(eyeBox.SelectedIndex)); // eyes
            Gecko.poke32(skinAddress + diff, ToUInt32(skinBox.SelectedIndex)); // skin
            pokeAmiibo(amiiboAddress + diff); // amiibo

            release();
        }

        public int fixStuff(string str1, int invalid, string str2, uint fixAddress, int newPokeVal, int newVal, int noVal)
        {
            DialogResult fix = MessageBox.Show(str1 + invalid + str2, Properties.Strings.INVALID, MessageBoxButtons.YesNo);
            if (fix == DialogResult.Yes)
            {
                Gecko.poke32(fixAddress + diff, ToUInt32(newPokeVal));
                return newVal;
            }
            else
            {
                return noVal;
            }
        }

        public void pokeRank(uint address)
        {
            uint rank = ToUInt32(rankBox.Value);
            Gecko.poke32(address, rank - 1); // rank
            Gecko.poke32(address - 0x4, 0x00000000); // experience to 0

            // we need to set the rank cap progression bit appropriately
            uint progression = Gecko.peek(ProgressBitsForm.progressBitsAddress + diff);
            ProgressBitsForm.SetFlag(ref progression, 0x100000, rank >= 20); // remove if rank < 20, set if rank >= 20
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
                Gecko.poke32(address, ToUInt32(amiiboBox.SelectedIndex - 1));
                if (sendStats)
                {
                    Statistics.WriteToSlot(7, 1);
                }
            }
        }

        public void octohax(bool octopus)
        {
            // Tnk_Simple 1
            Gecko.poke32(tnkSimpleOneAddress, 0x546E6B5F);
            Gecko.poke32(tnkSimpleOneAddress + 0x4, 0x53696D70);
            Gecko.poke32(tnkSimpleOneAddress + 0x8, 0x6C650000);

            // Tnk_Simple 2
            Gecko.poke32(tnkSimpleTwoAddress, 0x546E6B5F);
            Gecko.poke32(tnkSimpleTwoAddress + 0x4, 0x53696D70);
            Gecko.poke32(tnkSimpleTwoAddress + 0x8, 0x6C650000);

            // Player00
            Gecko.poke32(player00Address, 0x52697661);
            Gecko.poke32(player00Address + 0x4, 0x6C303000);

            // Player00_Hlf
            Gecko.poke32(player00HlfAddress, 0x52697661);
            Gecko.poke32(player00HlfAddress + 0x4, 0x6C30305F);
            Gecko.poke32(player00HlfAddress + 0x8, 0x486C6600);

            // Rival_Squid
            if (octopus)
            {
                Gecko.poke32(rivalSquidAddress, 0x52697661);
                Gecko.poke32(rivalSquidAddress + 0x4, 0x6C5F5371);
                Gecko.poke32(rivalSquidAddress + 0x8, 0x75696400);
            }
            else
            {
                Gecko.poke32(rivalSquidAddress, 0x506C6179);
                Gecko.poke32(rivalSquidAddress + 0x4, 0x65725F53);
                Gecko.poke32(rivalSquidAddress + 0x8, 0x71756964);
            }

            // Tnk_Simple 3
            Gecko.poke32(tnkSimpleThreeAddress, 0x546E6B5F);
            Gecko.poke32(tnkSimpleThreeAddress + 0x4, 0x53696D70);
            Gecko.poke32(tnkSimpleThreeAddress + 0x8, 0x6C650000);

            // Tnk_Simple 4
            Gecko.poke32(tnkSimpleFourAddress, 0x546E6B5F);
            Gecko.poke32(tnkSimpleFourAddress + 0x4, 0x53696D70);
            Gecko.poke32(tnkSimpleFourAddress + 0x8, 0x6C650000);

            // Tnk_Simple 5
            Gecko.poke32(tnkSimpleFiveAddress, 0x546E6B5F);
            Gecko.poke32(tnkSimpleFiveAddress + 0x4, 0x53696D70);
            Gecko.poke32(tnkSimpleFiveAddress + 0x8, 0x6C650000);

            if (sendStats)
            {
                Statistics.WriteToSlot(9, 1);
            }
        }

        public void sisterhax(string mode)
        {
            switch(mode)
            {
                case "aori":
                    Gecko.poke32(aoriAddress, 0x4E70635F);
                    Gecko.poke32(aoriAddress + 4, 0x49646F6C);
                    Gecko.poke32(aoriAddress + 8, 0x41000000);

                    Gecko.poke32(hotaruAddress, 0x4E70635F);
                    Gecko.poke32(hotaruAddress + 4, 0x49646F6C);
                    Gecko.poke32(hotaruAddress + 8, 0x41000000);
                    break;

                case "hotaru":
                    Gecko.poke32(aoriAddress, 0x4E70635F);
                    Gecko.poke32(aoriAddress + 4, 0x49646F6C);
                    Gecko.poke32(aoriAddress + 8, 0x42000000);

                    Gecko.poke32(hotaruAddress, 0x4E70635F);
                    Gecko.poke32(hotaruAddress + 4, 0x49646F6C);
                    Gecko.poke32(hotaruAddress + 8, 0x42000000);
                    break;

                case "swap":
                    Gecko.poke32(aoriAddress, 0x4E70635F);
                    Gecko.poke32(aoriAddress + 4, 0x49646F6C);
                    Gecko.poke32(aoriAddress + 8, 0x42000000);

                    Gecko.poke32(hotaruAddress, 0x4E70635F);
                    Gecko.poke32(hotaruAddress + 4, 0x49646F6C);
                    Gecko.poke32(hotaruAddress + 8, 0x41000000);
                    break;

                case "normal":
                    Gecko.poke32(aoriAddress, 0x4E70635F);
                    Gecko.poke32(aoriAddress + 4, 0x49646F6C);
                    Gecko.poke32(aoriAddress + 8, 0x41000000);

                    Gecko.poke32(hotaruAddress, 0x4E70635F);
                    Gecko.poke32(hotaruAddress + 4, 0x49646F6C);
                    Gecko.poke32(hotaruAddress + 8, 0x42000000);
                    break;
            }

            if (sendStats)
            {
                Statistics.WriteToSlot(8, 1);
            }
        }
        public void weaponhax(uint specialdiff)
        {
            Gecko.poke32(0x12CDADC8 + diff + specialdiff, 0x000003E8);
            Gecko.poke32(0x12CDADF0 + diff + specialdiff, 0x000003E9);
            Gecko.poke32(0x12CDAE18 + diff + specialdiff, 0x000003F3);
            Gecko.poke32(0x12CDAE40 + diff + specialdiff, 0x000003FC);
            Gecko.poke32(0x12CDAE68 + diff + specialdiff, 0x000003FD);
            Gecko.poke32(0x12CDAE90 + diff + specialdiff, 0x00000406);
            Gecko.poke32(0x12CDAEB8 + diff + specialdiff, 0x00000407);
            Gecko.poke32(0x12CDAEE0 + diff + specialdiff, 0x00000410);
            Gecko.poke32(0x12CDAF08 + diff + specialdiff, 0x00000411);
            Gecko.poke32(0x12CDAF30 + diff + specialdiff, 0x00000415);
            Gecko.poke32(0x12CDAF58 + diff + specialdiff, 0x00000416);
            Gecko.poke32(0x12CDAF80 + diff + specialdiff, 0x0000041A);
            Gecko.poke32(0x12CDAFA8 + diff + specialdiff, 0x0000041B);
            Gecko.poke32(0x12CDAFD0 + diff + specialdiff, 0x00000424);
            Gecko.poke32(0x12CDAFF8 + diff + specialdiff, 0x00000425);
            Gecko.poke32(0x12CDB020 + diff + specialdiff, 0x0000042E);
            Gecko.poke32(0x12CDB048 + diff + specialdiff, 0x0000042F);
            Gecko.poke32(0x12CDB070 + diff + specialdiff, 0x00000438);
            Gecko.poke32(0x12CDB098 + diff + specialdiff, 0x00000439);
            Gecko.poke32(0x12CDB0C0 + diff + specialdiff, 0x00000442);
            Gecko.poke32(0x12CDB0E8 + diff + specialdiff, 0x00000443);
            Gecko.poke32(0x12CDB110 + diff + specialdiff, 0x0000044C);
            Gecko.poke32(0x12CDB138 + diff + specialdiff, 0x0000044D);
            Gecko.poke32(0x12CDB160 + diff + specialdiff, 0x00000456);
            Gecko.poke32(0x12CDB188 + diff + specialdiff, 0x00000457);
            Gecko.poke32(0x12CDB1B0 + diff + specialdiff, 0x00000460);
            Gecko.poke32(0x12CDB1D8 + diff + specialdiff, 0x00000461);
            Gecko.poke32(0x12CDB200 + diff + specialdiff, 0x0000046A);
            Gecko.poke32(0x12CDB228 + diff + specialdiff, 0x0000046B);
            Gecko.poke32(0x12CDB250 + diff + specialdiff, 0x00000474);
            Gecko.poke32(0x12CDB278 + diff + specialdiff, 0x00000475);
            Gecko.poke32(0x12CDB2A0 + diff + specialdiff, 0x0000047E);
            Gecko.poke32(0x12CDB2C8 + diff + specialdiff, 0x0000047F);
            Gecko.poke32(0x12CDB2F0 + diff + specialdiff, 0x00000488);
            Gecko.poke32(0x12CDB318 + diff + specialdiff, 0x00000489);
            Gecko.poke32(0x12CDB340 + diff + specialdiff, 0x00000492);
            Gecko.poke32(0x12CDB368 + diff + specialdiff, 0x00000493);
            Gecko.poke32(0x12CDB390 + diff + specialdiff, 0x000007D0);
            Gecko.poke32(0x12CDB3B8 + diff + specialdiff, 0x000007D1);
            Gecko.poke32(0x12CDB3E0 + diff + specialdiff, 0x000007DA);
            Gecko.poke32(0x12CDB408 + diff + specialdiff, 0x000007DB);
            Gecko.poke32(0x12CDB430 + diff + specialdiff, 0x000007DF);
            Gecko.poke32(0x12CDB458 + diff + specialdiff, 0x000007E4);
            Gecko.poke32(0x12CDB480 + diff + specialdiff, 0x000007E5);
            Gecko.poke32(0x12CDB4A8 + diff + specialdiff, 0x000007EE);
            Gecko.poke32(0x12CDB4D0 + diff + specialdiff, 0x000007EF);
            Gecko.poke32(0x12CDB4F8 + diff + specialdiff, 0x000007F8);
            Gecko.poke32(0x12CDB520 + diff + specialdiff, 0x000007F9);
            Gecko.poke32(0x12CDB548 + diff + specialdiff, 0x00000BB8);
            Gecko.poke32(0x12CDB570 + diff + specialdiff, 0x00000BB9);
            Gecko.poke32(0x12CDB598 + diff + specialdiff, 0x00000BC2);
            Gecko.poke32(0x12CDB5C0 + diff + specialdiff, 0x00000BC3);
            Gecko.poke32(0x12CDB5E8 + diff + specialdiff, 0x00000BCC);
            Gecko.poke32(0x12CDB610 + diff + specialdiff, 0x00000BCD);
            Gecko.poke32(0x12CDB638 + diff + specialdiff, 0x00000FA0);
            Gecko.poke32(0x12CDB660 + diff + specialdiff, 0x00000FA1);
            Gecko.poke32(0x12CDB688 + diff + specialdiff, 0x00000FAA);
            Gecko.poke32(0x12CDB6B0 + diff + specialdiff, 0x00000FAB);
            Gecko.poke32(0x12CDB6D8 + diff + specialdiff, 0x00000FAF);
            Gecko.poke32(0x12CDB700 + diff + specialdiff, 0x00000FB4);
            Gecko.poke32(0x12CDB728 + diff + specialdiff, 0x00000FB5);
            Gecko.poke32(0x12CDB750 + diff + specialdiff, 0x00000FBE);
            Gecko.poke32(0x12CDB778 + diff + specialdiff, 0x00000FBF);
            Gecko.poke32(0x12CDB7A0 + diff + specialdiff, 0x00000FC8);
            Gecko.poke32(0x12CDB7C8 + diff + specialdiff, 0x00000FC9);
            Gecko.poke32(0x12CDB7F0 + diff + specialdiff, 0x00000FD2);
            Gecko.poke32(0x12CDB818 + diff + specialdiff, 0x00000FD3);
            Gecko.poke32(0x12CDB840 + diff + specialdiff, 0x00001388);
            Gecko.poke32(0x12CDB868 + diff + specialdiff, 0x00001389);
            Gecko.poke32(0x12CDB890 + diff + specialdiff, 0x00001392);
            Gecko.poke32(0x12CDB8B8 + diff + specialdiff, 0x00001393);
            Gecko.poke32(0x12CDB8E0 + diff + specialdiff, 0x0000139C);
            Gecko.poke32(0x12CDB908 + diff + specialdiff, 0x0000139D);
            Gecko.poke32(0x12CDB930 + diff + specialdiff, 0x00000412);
            Gecko.poke32(0x12CDB958 + diff + specialdiff, 0x00000430);
            Gecko.poke32(0x12CDB980 + diff + specialdiff, 0x000007E6);
            Gecko.poke32(0x12CDB9A8 + diff + specialdiff, 0x000007F0);
            Gecko.poke32(0x12CDB9D0 + diff + specialdiff, 0x00000BBA);
            Gecko.poke32(0x12CDB9F8 + diff + specialdiff, 0x00000FA2);
            Gecko.poke32(0x12CDBA20 + diff + specialdiff, 0x00000FD4);
            Gecko.poke32(0x12CDBA48 + diff + specialdiff, 0x0000138A);
            Gecko.poke32(0x12CDBA70 + diff + specialdiff, 0x000003EA);
            Gecko.poke32(0x12CDBA98 + diff + specialdiff, 0x00000426);
            Gecko.poke32(0x12CDBAC0 + diff + specialdiff, 0x0000046C);
            Gecko.poke32(0x12CDBAE8 + diff + specialdiff, 0x00000494);
            Gecko.poke32(0x12CDBB10 + diff + specialdiff, 0x000007DC);
            Gecko.poke32(0x12CDBB38 + diff + specialdiff, 0x00000FAC);
            Gecko.poke32(0x12CDBB60 + diff + specialdiff, 0x00000FB6);
            Gecko.poke32(0x12CDBB88 + diff + specialdiff, 0x00001394);
            Gecko.poke32(0x12CDBBB0 + diff + specialdiff, 0x00000408);
        }

        private void progressFlagsBox_Click(object sender, EventArgs e)
        {
            ProgressBitsForm progressBitsForm = new ProgressBitsForm();
            progressBitsForm.ShowDialog(this);
        }

        private void ikaBox_Click(object sender, EventArgs e)
        {
            octohax(false);
        }

        private void takoBox_Click(object sender, EventArgs e)
        {
            octohax(true);
        }

        private void aoriBox_Click(object sender, EventArgs e)
        {
            sisterhax("aori");
        }

        private void hotaruBox_Click(object sender, EventArgs e)
        {
            sisterhax("hotaru");
        }

        private void swapBox_Click(object sender, EventArgs e)
        {
            sisterhax("swap");
        }

        private void normalBox_Click(object sender, EventArgs e)
        {
            sisterhax("normal");
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            Gecko.poke32(minigamesAddress + diff, 0x000F0000);
        }

        private void bukiButton_Click(object sender, EventArgs e)
        {
            weaponhax(0x0);
        }

        private readonly Dictionary<uint, uint[]> hats = new Dictionary<uint, uint[]>()
        {
            { 0x00000001, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x000003e8, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003e9, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x000003ea, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x000003eb, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003ec, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003ed, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003ee, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x000003ef, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000003f0, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000003f1, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000003f2, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000003f3, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x000003f4, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000003f6, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x000007d0, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000007d1, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x000007d2, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000007d3, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000007d4, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x000007d5, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x00000bb8, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00000bb9, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00000bba, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00000bbb, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00000bbc, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00000bbd, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00000bbe, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00000bbf, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bc0, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00000bc1, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00000bc2, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00000fa0, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00000fa1, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00000fa2, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00000fa3, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00000fa4, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00000fa5, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x00000fa6, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x00000fa7, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001388, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001389, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x0000138a, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001770, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x00001771, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00001772, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00001b58, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x00001b5a, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001b5b, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001b5c, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x00001b5d, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x00001f40, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001f41, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001f42, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00001f43, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00002329, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x0000232a, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x0000232b, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x0000232c, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x0000232d, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x000003f5, new uint[] { 0x00000005, 0x00000006, 0x0000000C } },
            { 0x0000232e, new uint[] { 0x0000000A, 0x0000000C, 0x00000003 } },
            { 0x000061a8, new uint[] { 0x00000006, 0x00000004, 0x00000005 } },
            { 0x000061a9, new uint[] { 0x00000000, 0x00000001, 0x00000005 } },
            { 0x000061aa, new uint[] { 0x00000001, 0x00000001, 0x0000000B } },
            { 0x00006978, new uint[] { 0x00000002, 0x00000005, 0x00000006 } },
            { 0x0000697c, new uint[] { 0x00000007, 0x00000007, 0x00000008 } },
            { 0x00006d60, new uint[] { 0x0000000C, 0x0000000C, 0x00000003 } },
            { 0x000003f7, new uint[] { 0x00000000, 0x00000001, 0x00000005 } },
            { 0x000003f8, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
        };

        private readonly Dictionary<uint, uint[]> clothes = new Dictionary<uint, uint[]>()
        {
            { 0x00000001, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x000003e8, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x000003e9, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x000003eb, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x000003ec, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x000003ed, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x000003ee, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x000003ef, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000003f0, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000003f1, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003f2, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x000003f3, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003f4, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003f5, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x000003f6, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x000003f7, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x000003f8, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x000003f9, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x000003fa, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000003fb, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000003fc, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x000003fd, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x000003fe, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x000003ff, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00000402, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00000403, new uint[] { 0x00000009, 0x00000009, 0x00000009 } },
            { 0x00000405, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x000007d0, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000007d1, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000007d2, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x000007d3, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000007d4, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000007d5, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000007d6, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x000007d7, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x000007d8, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x000007d9, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x000007da, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x000007db, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000007dc, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00000bb8, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00000bb9, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00000bba, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00000bbb, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00000bbc, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x00000bbd, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00000bbe, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000bbf, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bc0, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000bc1, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00000fa0, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00000fa1, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000fa2, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000fa3, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00000fa4, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00000fa5, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x00000fa6, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000fa7, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000fa8, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00001388, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x0000138a, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x0000138b, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x0000138c, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x0000138d, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x0000138e, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x0000138f, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001390, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x00001391, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00001392, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001393, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001394, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001395, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001396, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00001397, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00001398, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00001770, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x00001771, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x00001b58, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00001b59, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00001b5a, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00001b5b, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00001b5c, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00001b5d, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00001b5e, new uint[] { 0x00000000, 0x00000000, 0x00000000 } },
            { 0x00001f40, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001f41, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00001f42, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00001f43, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00001f44, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x00001f45, new uint[] { 0x00000008, 0x00000008, 0x00000008 } },
            { 0x00001f46, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00001f47, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00001f48, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00001f49, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00001f4a, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001f4b, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001f4c, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00001f4d, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00001f4e, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00001f4f, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00002328, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00002329, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x0000232a, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x0000232b, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x0000232c, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x0000232d, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00002710, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00002711, new uint[] { 0x00000003, 0x00000003, 0x00000003 } },
            { 0x00002712, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x00000400, new uint[] { 0x00000006, 0x00000005, 0x00000005 } },
            { 0x00000401, new uint[] { 0x0000000A, 0x0000000C, 0x00000001 } },
            { 0x00001772, new uint[] { 0x00000000, 0x00000005, 0x00000001 } },
            { 0x00001f50, new uint[] { 0x00000004, 0x0000000C, 0x0000000B } },
            { 0x000061a8, new uint[] { 0x0000000B, 0x0000000A, 0x0000000C } },
            { 0x000061a9, new uint[] { 0x00000007, 0x00000008, 0x00000008 } },
            { 0x000061aa, new uint[] { 0x00000009, 0x00000001, 0x0000000C } },
            { 0x00000404, new uint[] { 0x0000000C, 0x0000000C, 0x00000009 } },
            { 0x00006978, new uint[] { 0x0000000B, 0x0000000C, 0x0000000A } },
            { 0x0000697c, new uint[] { 0x00000008, 0x00000003, 0x00000006 } },
            { 0x00006d60, new uint[] { 0x0000000C, 0x00000003, 0x0000000C } },
            { 0x00002713, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } }
        };

        private readonly Dictionary<uint, uint[]> shoes = new Dictionary<uint, uint[]>()
        {
            { 0x00000001, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000003e8, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000003e9, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000003ea, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000003eb, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000003ec, new uint[] { 0x0000000A, 0x0000000A, 0x0000000A } },
            { 0x000003ed, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000003ee, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000003ef, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000003f0, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000003f1, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000003f2, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x000003f3, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x000007d0, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000007d1, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000007d2, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000007d3, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000007d4, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000007d5, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x000007d6, new uint[] { 0x0000000B, 0x0000000B, 0x0000000B } },
            { 0x000007d8, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x000007d9, new uint[] { 0x00000002, 0x00000002, 0x00000002 } },
            { 0x00000bb8, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bb9, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000bba, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bbb, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000bbc, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bbd, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bbe, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bbf, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000bc0, new uint[] { 0x00000007, 0x00000007, 0x00000007 } },
            { 0x00000bc1, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00000fa0, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00000fa1, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00000fa2, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00000fa3, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00001388, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00001389, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x0000138a, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00001770, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001771, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001772, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001773, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001774, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00001775, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x00001776, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001777, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001778, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001779, new uint[] { 0x00000001, 0x00000001, 0x00000001 } },
            { 0x0000177a, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x0000177b, new uint[] { 0x00000004, 0x00000004, 0x00000004 } },
            { 0x00001b58, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00001b59, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00001b5a, new uint[] { 0x00000006, 0x00000006, 0x00000006 } },
            { 0x00001f40, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001f41, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001f42, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001f43, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00001f44, new uint[] { 0x00000005, 0x00000005, 0x00000005 } },
            { 0x00000fa6, new uint[] { 0x00000000, 0x00000001, 0x00000007 } },
            { 0x000007d7, new uint[] { 0x0000000A, 0x00000008, 0x00000007 } },
            { 0x000061a8, new uint[] { 0x0000000B, 0x0000000C, 0x0000000C } },
            { 0x000061a9, new uint[] { 0x00000007, 0x00000004, 0x00000002 } },
            { 0x000061aa, new uint[] { 0x0000000C, 0x00000007, 0x00000009 } },
            { 0x00006978, new uint[] { 0x00000002, 0x00000004, 0x00000009 } },
            { 0x0000697c, new uint[] { 0x00000005, 0x00000003, 0x00000006 } },
            { 0x00006d60, new uint[] { 0x0000000C, 0x00000009, 0x00000007 } }
        };

        private void PokeGear(uint baseAddress, Dictionary<uint, uint[]> gear)
        {
            // Sort the Dictionary's keys so that starter gear will appear first
            List<uint> sortedKeys = gear.Keys.ToList();
            sortedKeys.Sort();

            foreach (uint objectId in sortedKeys)
            {
                uint[] abilities = gear[objectId];

                // Poke the memory addresses
                Gecko.poke(baseAddress, objectId); // objectId
                Gecko.poke(baseAddress + 0x00000004, 0x00000004); // level
                Gecko.poke(baseAddress + 0x00000008, 0x00000004); // slots
                Gecko.poke(baseAddress + 0x0000000C, abilities[0]); // slot 1
                Gecko.poke(baseAddress + 0x00000010, abilities[1]); // slot 2
                Gecko.poke(baseAddress + 0x00000014, abilities[2]); // slot 3
                Gecko.poke(baseAddress + 0x00000024, 0x00000024); // date
                Gecko.poke(baseAddress + 0x00000028, 0x00010000); // new flag

                // Move to next gear slot in the inventory
                baseAddress += 0x00000030;

                // debug
                // Console.WriteLine("poked (objectId = " + objectId + ", new baseAddress = " + baseAddress + ")");
            }

            if (sendStats)
            {
                Statistics.WriteToSlot(10, 1);
            }
        }

        private void gearButton_Click_1(object sender, EventArgs e)
        {
            PokeGear(hatsAddress + diff, hats);
            PokeGear(clothesAddress + diff, clothes);
            PokeGear(shoesAddress + diff, shoes);
        }

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinglePlayerForm singlePlayerForm = new SinglePlayerForm();
            singlePlayerForm.ShowDialog(this);
        }

        private void timerHaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerHaxForm timerHaxForm = new TimerHaxForm();
            timerHaxForm.ShowDialog(this);
        }
    }
}
