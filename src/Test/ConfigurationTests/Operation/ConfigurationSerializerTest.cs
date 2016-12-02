using Microsoft.VisualStudio.TestTools.UnitTesting;
using XC.Configuration.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XC.Test.Configuration.Operation.Util;
using System.IO;

namespace XC.Configuration.Operation.Tests
{
    /// <summary>
    /// Some basisc tests of writing Configuration
    /// </summary>
    [TestClass()]
    public class ConfigurationSerializerTest
    {
        /// <summary>
        /// Store path for the FirstExampleFolder
        /// </summary>
        public readonly string FirstExampleFolder = PathSettings.ConfigurationExamplePath;

        /// <summary>
        /// Stores path for the first Test-Configuration
        /// </summary>
        public readonly string WritingEmptyConfigurationPath = PathSettings.ConfigurationExampleFirstFile;

        /// <summary>
        /// Store path for the creating-Pages-example
        /// </summary>
        public readonly string CreatingPagesPath = PathSettings.ConfigurationExampleCreatingPagesFile;

        /// <summary>
        /// Creating Test-Folder if the does not exist.
        /// Delete existing Files.
        /// </summary>
        [TestInitialize]
        public void TestPrepare()
        {
            if (!Directory.Exists(FirstExampleFolder))
            {
                Directory.CreateDirectory(FirstExampleFolder);
            }

            string[] cleanUpList = new string[] { WritingEmptyConfigurationPath, CreatingPagesPath };

            foreach (string cleanup in cleanUpList)
            {
                if (File.Exists(cleanup))
                {
                    File.Delete(cleanup);
                }
            }

        }

        /// <summary>
        /// Removes created files
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            string[] cleanUpList = new string[] { WritingEmptyConfigurationPath, CreatingPagesPath };

            foreach (string cleanup in cleanUpList)
            {
                if (File.Exists(cleanup))
                {
                    File.Delete(cleanup);
                }
            }
        }

        /// <summary>
        /// First Test
        /// </summary>
        [TestMethod()]
        public void WriteConfigurationFirstTest()
        {
            WriteEmptyStandardConfiguration();
        }


        /// <summary>
        /// Creating Pages
        /// </summary>
        [TestMethod()]
        public void WritingPagesTest()
        {
            WriteEmptyPages(10);
        }

        private void WriteEmptyPages(int pageCount)
        {
            Assert.IsTrue(!File.Exists(CreatingPagesPath), "File " + CreatingPagesPath + " is allready there.");

            ConfigurationGlobal global = new ConfigurationGlobal();

            for (int i = 0; i < pageCount; i++)
            {
                global.AddPage(new ConfigurationItemGroup());
            }


            ConfigurationExchange output = new ConfigurationExchange(global);

            bool writeConfiguration = ConfigurationSerializer.WriteConfiguration(output, CreatingPagesPath);
            Assert.IsTrue(writeConfiguration, "Configuration: " + CreatingPagesPath + " could not be written.");

            Assert.IsTrue(File.Exists(CreatingPagesPath), "File " + CreatingPagesPath + " was serialized but is not there.");
        }

        /// <summary>
        /// Loads empty Configuration
        ///     1. Write Empty Configuration
        ///     2. Loads saved Configuration
        /// </summary>
        [TestMethod()]
        public void LoadingConfigurationBasic()
        {
            WriteEmptyStandardConfiguration();

            Assert.IsTrue(File.Exists(WritingEmptyConfigurationPath), "File " + WritingEmptyConfigurationPath + " is not there.");

            ConfigurationExchange configuration = ConfigurationSerializer.LoadConfiguration(WritingEmptyConfigurationPath);

            Assert.IsNotNull(configuration, "No Configuration: " + WritingEmptyConfigurationPath + " was loaded");
        }

        private void WriteEmptyStandardConfiguration()
        {
            ConfigurationGlobal global = new ConfigurationGlobal();
            ConfigurationExchange output = new ConfigurationExchange(global);

            bool writeConfiguration = ConfigurationSerializer.WriteConfiguration(output, WritingEmptyConfigurationPath);
            Assert.IsTrue(writeConfiguration, "Configuration: " + WritingEmptyConfigurationPath + " could not be written.");

            Assert.IsTrue(File.Exists(WritingEmptyConfigurationPath), "File " + WritingEmptyConfigurationPath + " was serialized but is not there.");
        }

        /// <summary>
        /// First write 10 Empty pages and then load them.
        /// </summary>
        [TestMethod()]
        public void WriteAndLoadEmptyPage()
        {
            int pageCount = 10;
            WriteEmptyPages(pageCount);


            ConfigurationExchange configuration = ConfigurationSerializer.LoadConfiguration(CreatingPagesPath);

            Assert.IsNotNull(configuration, "Configuration "+ WritingEmptyConfigurationPath+" could not be loaded");
            Assert.IsTrue(configuration.Pages.Count == pageCount, "Not enough pages are loaded" + configuration.Pages.Count +" != "+ pageCount);

        }

    }
}