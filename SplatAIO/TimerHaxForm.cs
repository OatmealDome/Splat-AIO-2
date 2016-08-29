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
        private readonly uint dojoAddress = 0x1CAAA218;
        private readonly uint dojoGeckiineAddress = 0x1CAA9D58;
        private readonly uint reconAddress = 0x1CAAA144;
        private readonly uint reconGeckiineAddress = 0x1CAA9C84;
        private readonly uint amiiboAddress = 0x1CAB5778;
        private readonly uint amiiboGeckiineAddress = 0x1CAB52B8;

        private TCPGecko gecko;
        private uint diff;
        private uint timerAddress;

        public TimerHaxForm(TCPGecko gecko, uint diff)
        {
            InitializeComponent();

            this.gecko = gecko;
            this.diff = diff;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            RecalculatePointer();

            if (!BattleDojoRadioButton.Checked && !ReconRadioButton.Checked && !AmiiboRadioButton.Checked)
            {
                MessageBox.Show(Properties.Strings.SELECT_TIMER_TYPE_TEXT);
                return;
            }

            if (!FreezeCheckBox.Checked)
            {
                gecko.poke32(timerAddress, Convert.ToUInt32(TimerBox.Value * 60));
            }
            else
            {
                gecko.poke32(timerAddress, 0xFFFFFFFE);
            }
        }

        private void FreezeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimerBox.Enabled = !FreezeCheckBox.Checked;
        }

        private void RecalculatePointer()
        {
            if (BattleDojoRadioButton.Checked)
            {
                // TODO: geckiine
                timerAddress = gecko.peek(dojoAddress + diff) + 0x280;
            }
            else if (ReconRadioButton.Checked)
            {
                timerAddress = GetPointerVal(reconAddress, reconGeckiineAddress, 0x1F000000, 0x20000000) + 0x280;
            }
            else if (AmiiboRadioButton.Checked)
            {
                timerAddress = GetPointerVal(amiiboAddress, amiiboGeckiineAddress, 0x20000000, 0x21000000) + 0x2B4;
            }
        }

        public uint GetPointerVal(uint regular, uint geckiine, uint rangeStart, uint rangeEnd)
        {
            uint pointerVal = gecko.peek(regular + diff);
            if (pointerVal < rangeStart || pointerVal > rangeEnd)
            {
                // pointer is invalid, fallback to geckiine pointer
                pointerVal = gecko.peek(geckiine);
            }

            return pointerVal;
        }

    }
}
