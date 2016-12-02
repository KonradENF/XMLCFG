using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XC.Configuration
{
    [Serializable]
    public class ConfigurationGlobal
    {

        private List<ConfigurationItemGroup> content = new List<ConfigurationItemGroup>();

        /// <summary>
        /// 
        /// </summary>
        public ConfigurationGlobal()
        {
            
        }

        /// <summary>
        /// Adds a ConfigurationItemGroup <see cref="ConfigurationItemGroup"/> 
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Returns page</returns>
        public ConfigurationItemGroup AddPage(ConfigurationItemGroup page)
        {
            this.content.Add(page);
            return page;
        }

        public IList<ConfigurationItemGroup> GetPages()
        {
            return content.AsReadOnly();
        }


    }
}
