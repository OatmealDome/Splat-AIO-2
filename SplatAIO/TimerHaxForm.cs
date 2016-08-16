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
    public partial class TimerHaxForm : Form
    {
        private int dojoTimerAddr;
        private int reconTimerAddr;
        private int amiiboTimerAddr;

        private TCPGecko gecko;

        public TimerHaxForm()
        {
            InitializeComponent();
        }

        private void TimerHaxFreezeButton_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.Owner;
            TCPGecko gecko = mainForm.Gecko;

            if (BattleDojoRadioButton.Checked)
            {
                dojoTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA218)) + 0x280;
                gecko.poke(Convert.ToUInt32(dojoTimerAddr), 0xFFFFFFFE);
            }
            else if (ReconRadioButton.Checked)
            {
                reconTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA144)) + 0x280;
                gecko.poke(Convert.ToUInt32(reconTimerAddr), 0xFFFFFFFE);
            }
            else if (AmiiboRadioButton.Checked)
            {
                amiiboTimerAddr = Convert.ToInt32(gecko.peek(0x1CAB5778)) + 0x2B4;
                gecko.poke(Convert.ToUInt32(amiiboTimerAddr), 0xFFFFFFFE);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.Owner;
            TCPGecko gecko = mainForm.Gecko;

            if (BattleDojoRadioButton.Checked)
            {
                dojoTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA218)) + 0x280;
                gecko.poke(Convert.ToUInt32(dojoTimerAddr), Convert.ToUInt32(TimerBox.Value * 60));
            }
            else if (ReconRadioButton.Checked)
            {
                reconTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA144)) + 0x280;
                gecko.poke(Convert.ToUInt32(reconTimerAddr), Convert.ToUInt32(TimerBox.Value * 60));
            }
            else if (AmiiboRadioButton.Checked)
            {
                amiiboTimerAddr = Convert.ToInt32(gecko.peek(0x1CAB5778)) + 0x2B4;
                gecko.poke(Convert.ToUInt32(amiiboTimerAddr), Convert.ToUInt32(TimerBox.Value * 60));
            }
        }

        private void FreezeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.Owner;
            TCPGecko gecko = mainForm.Gecko;
            if (FreezeCheckBox.Checked)
            {
                if (BattleDojoRadioButton.Checked)
                {
                    dojoTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA218)) + 0x280;
                    gecko.poke(Convert.ToUInt32(dojoTimerAddr), 0xFFFFFFFE);
                }
                else if (ReconRadioButton.Checked)
                {
                    reconTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA144)) + 0x280;
                    gecko.poke(Convert.ToUInt32(reconTimerAddr), 0xFFFFFFFE);
                }
                else if (AmiiboRadioButton.Checked)
                {
                    amiiboTimerAddr = Convert.ToInt32(gecko.peek(0x1CAB5778)) + 0x2B4;
                    gecko.poke(Convert.ToUInt32(amiiboTimerAddr), 0xFFFFFFFE);
                }
            }else if (!FreezeCheckBox.Checked)
            {
                if (BattleDojoRadioButton.Checked)
                {
                    dojoTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA218)) + 0x280;
                    gecko.poke(Convert.ToUInt32(dojoTimerAddr), Convert.ToUInt32(TimerBox.Value * 60));
                }
                else if (ReconRadioButton.Checked)
                {
                    reconTimerAddr = Convert.ToInt32(gecko.peek(0x1CAAA144)) + 0x280;
                    gecko.poke(Convert.ToUInt32(reconTimerAddr), Convert.ToUInt32(TimerBox.Value * 60));
                }
                else if (AmiiboRadioButton.Checked)
                {
                    amiiboTimerAddr = Convert.ToInt32(gecko.peek(0x1CAB5778)) + 0x2B4;
                    gecko.poke(Convert.ToUInt32(amiiboTimerAddr), Convert.ToUInt32(TimerBox.Value * 60));
                }
            }
        }
    }
}
