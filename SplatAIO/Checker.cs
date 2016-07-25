using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using static System.Convert;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO
{
    public partial class Checker : Form
    {
        public Form1 main;
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
                ver = ToInt32(vers.DownloadString("https://seresaa.github.io/AIO2/version.txt"));
                return 0;

            }
            catch
            {
                return 1;
            }

            
        }

        private void Update_Load(object sender, EventArgs e)
        {
            updateBox.Text = vers.DownloadString("https://seresaa.github.io/AIO2/changelog.txt");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/seresaa/Splat-AIO-2/releases/latest");
        }
    }
}
