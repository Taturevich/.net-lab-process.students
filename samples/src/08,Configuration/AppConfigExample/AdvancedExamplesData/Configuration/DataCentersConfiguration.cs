using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AppConfigExample.AdvancedExamplesData.Configuration
{
	public class DataCenterCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new DataCenterElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((DataCenterElement)element).Name;
		}
	}

	public class DataCenterElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true)]
		//[StringValidator(MinLength = 1)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("dataCenter", IsRequired = true)]
		//[IntegerValidator(MinValue = 1)]
		public int DataCenter
		{
			get { return (int)this["dataCenter"]; }
			set { this["dataCenter"] = value; }
		}
	}
}
