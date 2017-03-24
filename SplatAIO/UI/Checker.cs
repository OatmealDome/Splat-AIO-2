using System;
using System.Net;
using System.Windows.Forms;

namespace SplatAIO.UI
{
    public partial class Checker : Form
    {
        public int ver;
        public string data;
        public WebClient vers = new WebClient();
        public Checker()
        {
            InitializeComponent();
        }


        public int getdata()
        { 
            try
            {
                ver = Convert.ToInt32(vers.DownloadString("https://oatmealdome.github.io/AIO2/version.txt"));
                return 0;

            }
            catch
            {
                return 1;
            }
        }

        private void Update_Load(object sender, EventArgs e)
        {
            String changelog = vers.DownloadString("https://oatmealdome.github.io/AIO2/changelog.txt").Replace("\n", Environment.NewLine);
            updateBox.Text = changelog;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/OatmealDome/Splat-AIO-2/releases/latest");
            Close();
        }
    }
}
