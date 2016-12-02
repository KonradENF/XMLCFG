using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XC.Configuration.Operation
{
    /// <summary>
    /// Reads and writes <see cref="ConfigurationExchange" /> to filesystem.
    /// </summary>
    public class ConfigurationSerializer
    {

        /// <summary>
        /// Write the Configuration, which is stored in <see cref="ConfigurationExchange" /> to the destination 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool WriteConfiguration(ConfigurationExchange configuration, string destination)
        {
            try
            {
                using (var stream = File.OpenWrite(destination))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(ConfigurationExchange));
                    ser.Serialize(stream, configuration);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// Load <see cref="ConfigurationExchange"/> from file.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Configuration or null</returns>
        public static ConfigurationExchange LoadConfiguration(string source)
        {
            if (!File.Exists(source))
            {
                return null;
            }

            try
            {
                using (var stream = File.OpenRead(source))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(ConfigurationExchange));
                    return (ConfigurationExchange)ser.Deserialize(stream);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return null;
        }
    }
}
