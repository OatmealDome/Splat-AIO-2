using System;
using System.Globalization;
using System.Net;

namespace SplatAIO.Statistics
{
    public class StatisticTransmitter
    {
        private const string Url = "https://wiiucodes.tk/statistics_bg.php";
        private const string Agent = "AIOStats/1.0";

        public static void WriteToSlot(int slotnum, decimal content)
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", Agent);

            try //just in case
            {
                client.DownloadString(Url + "?id=2&slotnum=" + slotnum + "&value=" + content);
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
            var result = false;
            var ci = CultureInfo.InstalledUICulture;

            var client = new WebClient();
            client.Headers.Add("user-agent", Agent);
            try
            {
#if !DEBUG
                result = client.DownloadString(Url + "?id=2&testing=true&os=" + Environment.OSVersion + "&lang=" +
                                          ci.EnglishName).Equals("working");
#endif
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
            return result;
        }
    }
}