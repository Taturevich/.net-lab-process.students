using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AppConfigExample.AdvancedExamplesData.Configuration
{
	public class EnvironmentCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new EnvironmentElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((EnvironmentElement)element).Environment;
		}
	}

	public class EnvironmentElement : ConfigurationElement
	{
		[ConfigurationProperty("environment", IsRequired = true)]
		public string Environment
		{
			get { return (string)this["environment"]; }
			set { this["environment"] = value; }
		}
	}
}
