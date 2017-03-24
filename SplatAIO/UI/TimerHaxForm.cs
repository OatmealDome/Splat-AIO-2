using SplatAIO.Logic.Gecko;
using System;
using System.Windows.Forms;

namespace SplatAIO.UI
{
    public partial class TimerHaxForm : Form
    {
        private readonly uint basePointer = 0x106E5814;
        private readonly uint offsetOne = 0x2A4;
        private readonly uint offsetTwo = 0x280;
        private readonly uint offsetTwoAmiibo = 0x2B4;

        private TCPGecko Gecko;
        private uint timerAddress;

        public TimerHaxForm(TCPGecko Gecko)
        {
            InitializeComponent();
            this.Gecko = Gecko;
            TimerLabel.Text = "Set timer to: " + timeFormat();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            hold();
            RecalculatePointer();

            if (!FreezeCheckBox.Checked)
            {
                Gecko.poke32(timerAddress, (uint)TimerBox.Value * 60);
            }
            else
            {
                Gecko.poke32(timerAddress, 0xFFFFFFFE);
            }

            release();
        }

        private void FreezeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimerBox.Enabled = !FreezeCheckBox.Checked;
        }

        private void RecalculatePointer()
        {
           if (ReconDojoRadioButton.Checked)
            {
                timerAddress = GetPointerVal(basePointer, offsetOne, offsetTwo);
            }
            else
            {
                timerAddress = GetPointerVal(basePointer, offsetOne, offsetTwoAmiibo);
            }
        }

        public uint GetPointerVal(uint basePointer, uint offset1, uint offset2)
        {
            try
            {
                uint pointerVal = Gecko.peek(Gecko.peek(basePointer) + offset1) + offset2;

                if (pointerVal > 0x1F000000 && pointerVal < 0x21000000)
                {
                    return pointerVal;
                }
                else
                {
                    return timerError();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return timerError();
            }
        }

        private uint timerError()
        {
            MessageBox.Show(Properties.Strings.INVALID_TIME_ADDR, "Timer Address Cannot Be Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //safe area to poke if error occurs
            return 0x10000004;
        }

        private void hold()
        {
            ControlsGroupBox.Enabled = ApplyButton.Enabled = false;
        }
        private void release()
        {
            ControlsGroupBox.Enabled = ApplyButton.Enabled = true;
        }

        private void TimerBox_ValueChanged(object sender, EventArgs e)
        {
            TimerLabel.Text = "Set timer to: " + timeFormat();
        }

        private string timeFormat()
        {
            uint min = (uint)TimerBox.Value / 60;
            uint sec = (uint)TimerBox.Value % 60;
            return min.ToString("00") + ":" + sec.ToString("00");
        }

    }
}
