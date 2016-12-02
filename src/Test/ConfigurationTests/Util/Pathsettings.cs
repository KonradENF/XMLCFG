using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XC.Test.Configuration.Operation.Util
{
    class PathSettings
    {
        /// <summary>
        /// Absolute Path to Application-Folder
        /// </summary>
        public static readonly string AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static readonly string ConfigurationExamplePath = Path.Combine(new string[]
        {
            AssemblyPath,
            "Example"
        });

        public static readonly string ConfigurationExampleFirstFile = Path.Combine(new string[]
        {
            ConfigurationExamplePath,
            "First.xml"
        });

        public static readonly string ConfigurationExampleCreatingPagesFile = Path.Combine(new string[]
        {
            ConfigurationExamplePath,
            "CreatingPages.xml"
        });





    }
}
