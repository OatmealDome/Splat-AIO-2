using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SplatAIO
{
    [Serializable]
    public class Configuration
    {
        public int version;
        public String lastIp;
        public bool allowStatistics;

        private static XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
        public static Configuration currentConfig;
    
        public static void Load()
        {
            if (!File.Exists("Configuration.xml"))
            {
                AllowStatisticsForm allowStatisticsForm = new AllowStatisticsForm();
                allowStatisticsForm.ShowDialog();

                currentConfig = new Configuration();
                currentConfig.version = Form1.ver;
                currentConfig.lastIp = "";
                currentConfig.allowStatistics = allowStatisticsForm.allowCollection;

                Save();
            }
            else
            {
                using (FileStream stream = File.OpenRead("Configuration.xml"))
                {
                    currentConfig = (Configuration)serializer.Deserialize(stream);
                }
            }
        }

        public static void Save()
        {
            File.Delete("Configuration.xml");
            using (FileStream writer = File.OpenWrite("Configuration.xml"))
            {
                serializer.Serialize(writer, currentConfig);
            }
        }

    }
}
