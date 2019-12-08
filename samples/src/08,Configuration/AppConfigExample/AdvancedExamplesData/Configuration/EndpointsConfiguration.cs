using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AppConfigExample.AdvancedExamplesData.Configuration
{
	public class EndpointCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new EndpointElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((EndpointElement)element).Name;
		}
	}

	public class EndpointElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("address", IsRequired = true)]
		public string Address
		{
			get { return (string)this["address"]; }
			set { this["address"] = value; }
		}

		[ConfigurationProperty("useSSL", IsRequired = false, DefaultValue = false)]
		public bool UseSSL
		{
			get { return (bool)this["useSSL"]; }
			set { this["useSSL"] = value; }
		}

		[ConfigurationProperty("securityGroupsAllowedToSaveChanges", IsRequired = false)]
		public string SecurityGroupsAllowedToSaveChanges
		{
			get { return (string)this["securityGroupsAllowedToSaveChanges"]; }
			set { this["securityGroupsAllowedToSaveChanges"] = value; }
		}
	}
}
