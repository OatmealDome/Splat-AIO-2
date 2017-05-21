using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Hacks.TimeHax;
using SplatAIO.Properties;
using System;
using System.Windows.Forms;

namespace SplatAIO.UI.TimerHax
{
    public partial class TimerHaxForm : Form
    {
        public TimerHaxForm(TCPGecko Gecko)
        {
            InitializeComponent();
            InitializeTimerHax(Gecko);
        }

        public TimerHaxLogic TimerHaxLogic { get; private set; }

        public void InitializeTimerHax(TCPGecko Gecko)
        {
            TimerHaxLogic = new TimerHaxLogic(Gecko);
            if (TimerHaxLogic.RecalculatePointer())
            {
                try
                {
                    TimerBox.Value = TimerHaxLogic.GetTimer();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    // ToDo log
                }
            }
            TimerLabel.Text = "Set timer to: " + FormatTime();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            hold();
            if (TimerHaxLogic.RecalculatePointer(ReconDojoRadioButton.Checked))
            {
                TimerHaxLogic.SetTimer(!FreezeCheckBox.Checked ? (uint) TimerBox.Value * 60 : uint.MaxValue);
                release();
            }
            else
            {
                ShowTimerError();
            }
        }

        private void FreezeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimerBox.Enabled = !FreezeCheckBox.Checked;
        }

        private void ShowTimerError()
        {
            MessageBox.Show(Strings.INVALID_TIME_ADDR, "Timer Address Cannot Be Found", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
            TimerLabel.Text = "Set timer to: " + FormatTime();
        }

        private string FormatTime()
        {
            var min = (uint) TimerBox.Value / 60;
            var sec = (uint) TimerBox.Value % 60;
            return min.ToString("00") + ":" + sec.ToString("00");
        }
    }
}