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
    public partial class ProgressBitsForm : Form
    {
        private readonly uint progressBitsAddress = 0x12CD1C24;
        private uint progression;

        public ProgressBitsForm()
        {
            InitializeComponent();
        }

        private void ProgressBitsForm_Load(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.Owner;
            progression = mainForm.Gecko.peek(progressBitsAddress);

            tutorialBox.Checked = (progression & 0x1) != 0;
            splatfestBox.Checked = (progression & 0x2) != 0;
            rankedNewsBox.Checked = ((progression & 0x4) != 0);
            lobbyBox.Checked = (progression & 0x8) != 0;
            heroSuitBox.Checked = (progression & 0x10) != 0;
            greatZapfishBox.Checked = (progression & 0x80) != 0;
            cuttlefishPostGameBox.Checked = (progression & 0x100) != 0;
            rankedUnlockedBox.Checked = (progression & 0x800) != 0;
            rankShownBox.Checked = (progression & 0x1000) != 0;
            snailsShownBox.Checked = (progression & 0x10000) != 0;
            levelCapRaisedBox.Checked = (progression & 0x100000) != 0;
            warningBox.Checked = (progression & 0x200000) != 0;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.Owner;

            if (tutorialBox.Checked)
                progression |= 0x1;

            if (splatfestBox.Checked)
                progression |= 0x2;

            if (rankedNewsBox.Checked)
                progression |= 0x4;

            if (lobbyBox.Checked)
                progression |= 0x8;

            if (heroSuitBox.Checked)
                progression |= 0x10;

            if (greatZapfishBox.Checked)
                progression |= 0x80;

            if (cuttlefishPostGameBox.Checked)
                progression |= 0x100;

            if (rankedUnlockedBox.Checked)
                progression |= 0x800;

            if (rankShownBox.Checked)
                progression |= 0x1000;

            if (snailsShownBox.Checked)
                progression |= 0x10000;

            if (levelCapRaisedBox.Checked)
                progression |= 0x100000;

            if (warningBox.Checked)
                progression |= 0x200000;

            Console.WriteLine("progression: " + progression);
            mainForm.Gecko.poke32(progressBitsAddress, progression);
        }

    }
}
