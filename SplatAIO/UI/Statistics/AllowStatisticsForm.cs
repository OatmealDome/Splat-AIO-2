using System;
using System.Windows.Forms;

namespace SplatAIO.UI.Statistics
{
    public partial class AllowStatisticsForm : Form
    {
        public bool allowCollection;

        public AllowStatisticsForm()
        {
            InitializeComponent();
            ControlBox = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            allowCollection = allowCheckBox.Checked;

            Close();
        }
    }
}