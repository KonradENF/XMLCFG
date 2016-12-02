using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Test
/// </summary>
namespace XC.Configuration
{
    /// <summary>
    /// Smallest(atomic) object in configuration.
    /// </summary>
    public interface ConfigurationItemTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return the atomic type of ConfigurationItem <see cref="AttributeType"/></returns>
        AttributeType GetType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Returns the description of the <see cref="ConfigurationItemTemplate"/>. 
        /// </summary>
        /// <returns></returns>
        string GetDescription();
    }

    /// <inheritDoc/>
    public class ConfigurationItem : ConfigurationItemTemplate
    {
        /// <summary>
        /// Store the AttributeType
        /// </summary>
        private AttributeType type = AttributeType.Undefined;

        /// <summary>
        /// Store the name of the <see cref="ConfigurationItem"/> 
        /// </summary>
        private string name = string.Empty;

        /// <summary>
        /// Store the description of the <see cref="ConfigurationItem"/> 
        /// </summary>
        private string description = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public ConfigurationItem(AttributeType type, string name, string description)
        {
            this.type = type;
            this.name = name;
            this.description = description;
        }

        public ConfigurationItem()
        {

        }

        public string GetDescription()
        {
            return description;
        }


        public string GetName()
        {
            return name;
        }

        AttributeType ConfigurationItemTemplate.GetType()
        {
            return type;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConfigurationItemSimple : ConfigurationItem
    {

        public ConfigurationItemSimple(AttributeType type, string name, string description) : base(type, name, description)
        {
        }

        public ConfigurationItemSimple()
        {

        }
    }


    public class ConfigurationItemSimpleVar : ConfigurationItemSimple
    {
        public ConfigurationItemSimpleVar(string name, string description) : base(AttributeType.Var, name, description)
        {
        }
    }


    public class ConfigurationItemGroup : ConfigurationItem
    {
        private List<ConfigurationItem> children = new List<ConfigurationItem>();

        public ConfigurationItemGroup(string name, string description) : base(AttributeType.Group, name, description)
        {
        }

        public ConfigurationItemGroup()
        {

        }

        public void AddItem(ConfigurationItem item)
        {
            this.children.Add(item);
        }

        public void RemoveItem(ConfigurationItem item)
        {
            this.children.Remove(item);
        }
    }


    /// <summary>
    /// Supported Attribute-Types
    /// </summary>
    public enum AttributeType
    {
        /// <summary>
        /// Attribute is not initialized
        /// </summary>
        Undefined,

        /// <summary>
        /// Default "TextField"
        /// </summary>
        Var,
        /// <summary>
        /// Default Checkbox
        /// </summary>
        CheckBox,
        /// <summary>
        /// Only one element can be selected
        /// </summary>
        GroupBox,
        /// <summary>
        /// Group collect different Types
        /// </summary>
        Group,

    }
}
