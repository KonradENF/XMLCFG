using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XC.Configuration.Operation
{
    [Serializable]
    [XmlRoot(ElementName = "Configuration")]
    public class ConfigurationExchange
    {

        [XmlElement(ElementName = "Page")]
        public List<ConfigurationItemGroup> Pages
        {
            get;set;
        }

        public ConfigurationExchange()
        {

        }

        public ConfigurationExchange(ConfigurationGlobal global)
        {
            Pages = new List<ConfigurationItemGroup>();

            foreach(ConfigurationItemGroup item in global.GetPages())
            {
                Pages.Add(item);
            }
        }
    }
}
