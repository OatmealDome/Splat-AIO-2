using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO.Statistics
{
    public partial class AllowStatisticsForm : Form
    {
        public bool allowCollection;

        public AllowStatisticsForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            allowCollection = allowCheckBox.Checked;

            this.Close();
        }

    }
}
