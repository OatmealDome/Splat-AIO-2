using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // for debugging purposes
            /*CultureInfo japaneseCulture = new CultureInfo("ja-JP");
            Thread.CurrentThread.CurrentCulture = japaneseCulture;
            Thread.CurrentThread.CurrentUICulture = japaneseCulture;
            CultureInfo.DefaultThreadCurrentCulture = japaneseCulture;
            CultureInfo.DefaultThreadCurrentUICulture = japaneseCulture;*/

            // Generate the weapon database on start up
            WeaponDatabase.NoOperation();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
