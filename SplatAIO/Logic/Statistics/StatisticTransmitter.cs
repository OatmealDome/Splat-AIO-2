using System;
using System.Globalization;
using System.Net;

namespace SplatAIO.Logic.Statistics
{
    public class StatisticTransmitter
    {
        private static readonly string url = "https://wiiucodes.tk/statistics_bg.php";
        private static readonly string agent = "AIOStats/1.0";

        public static void WriteToSlot(int slotnum, decimal content)
        {
            var client = new WebClient();
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
            var result = false;
            var ci = CultureInfo.InstalledUICulture;

            var client = new WebClient();
            client.Headers.Add("user-agent", agent);
            try
            {
                result =
                    client.DownloadString(url + "?id=2&testing=true&os=" + Environment.OSVersion + "&lang=" +
                                          ci.EnglishName).Equals("working");
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