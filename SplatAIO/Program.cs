using SplatAIO.UI;
using System;
using System.Windows.Forms;

namespace SplatAIO
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // for debugging purposes
/*#if DEBUG
            CultureInfo japaneseCulture = new CultureInfo("ja-JP");
            Thread.CurrentThread.CurrentCulture = japaneseCulture;
            Thread.CurrentThread.CurrentUICulture = japaneseCulture;
            CultureInfo.DefaultThreadCurrentCulture = japaneseCulture;
            CultureInfo.DefaultThreadCurrentUICulture = japaneseCulture
#endif*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplatAIOForm());
        }
    }
}