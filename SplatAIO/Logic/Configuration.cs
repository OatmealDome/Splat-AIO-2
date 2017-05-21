using SplatAIO.UI;
using SplatAIO.UI.Statistics;
using System;
using System.IO;
using System.Xml.Serialization;

namespace SplatAIO.Logic
{
    [Serializable]
    public class Configuration
    {
        private const string CONFIG_FILE = "Configuration.xml";

        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
        public static Configuration CurrentConfig { get; private set; }

        public int Version { get; set; }
        public string LastIp { get; set; }
        public bool AllowStatistics { get; set; }

        public static void Load()
        {
            if (!File.Exists(CONFIG_FILE))
            {
                var allowStatisticsForm = new AllowStatisticsForm();
                allowStatisticsForm.ShowDialog();

                CurrentConfig = new Configuration();
                CurrentConfig.Version = SplatAIOForm.GetCurrentVersion();
                CurrentConfig.LastIp = "";
                CurrentConfig.AllowStatistics = allowStatisticsForm.allowCollection;

                Save();
            }
            else
            {
                using (var stream = File.OpenRead(CONFIG_FILE))
                {
                    CurrentConfig = (Configuration) serializer.Deserialize(stream);
                }
            }
        }

        public static void Save()
        {
            File.Delete(CONFIG_FILE);
            using (var writer = File.OpenWrite(CONFIG_FILE))
            {
                serializer.Serialize(writer, CurrentConfig);
            }
        }
    }
}