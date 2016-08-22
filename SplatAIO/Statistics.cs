using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO
{

    class Statistics
    {
        private static string url = "https://wiiucodes.tk/statistics_bg.php";
        private static string agent = "AIOStats/1.0";

        public static void WriteToSlot(int slotnum, decimal content)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", agent);

            try //just in case
            {
                string reply = client.DownloadString(url + "?id=2&slotnum=" + slotnum + "&value=" + content);
            }
            catch
            {

            }
        }

        public static bool WorkingConnection()
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;

            WebClient client = new WebClient();
            client.Headers.Add("user-agent", agent);

            try
            {
                string reply = client.DownloadString(url + "?id=2&testing=true&os=" +  Environment.OSVersion + "&lang=" + ci.EnglishName);

                if (reply == "working")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
