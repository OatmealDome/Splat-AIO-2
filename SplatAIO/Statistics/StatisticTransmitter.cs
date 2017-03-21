using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatAIO.Statistics
{

    public class StatisticTransmitter
    {
        private static string url = "https://wiiucodes.tk/statistics_bg.php";
        private static string agent = "AIOStats/1.0";

        public static void WriteToSlot(int slotnum, decimal content)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", agent);

            try //just in case
            {
                client.DownloadString(url + "?id=2&slotnum=" + slotnum + "&value=" + content);
            }
            catch (ArgumentException e)
            {
                // ToDo logging
            }
            catch (WebException e)
            {
                // ToDo logging
            }
            catch (NotSupportedException e)
            {
                // ToDo logging
            }
        }

        public static bool WorkingConnection()
        {
            bool result = false;
            CultureInfo ci = CultureInfo.InstalledUICulture;

            WebClient client = new WebClient();
            client.Headers.Add("user-agent", agent);
            try
            {
                result = client.DownloadString(url + "?id=2&testing=true&os=" + Environment.OSVersion + "&lang=" + ci.EnglishName).Equals("working");
            }
            catch(ArgumentException e)
            {
                // ToDo logging
            }
            catch (WebException e)
            {
                // ToDo logging
            }
            catch (NotSupportedException e)
            {
                // ToDo logging
            }
            return result;
        }
    }
}
