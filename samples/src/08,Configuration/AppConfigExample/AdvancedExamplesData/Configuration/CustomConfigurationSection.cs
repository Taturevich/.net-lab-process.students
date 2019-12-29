using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AppConfigExample.AdvancedExamplesData.Configuration
{
	public class CustomConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// The name of this section in the app.config.
		/// </summary>
		public const string SectionName = "CustomConfigurationSection";

		private const string DataCenterCollectionName = "DataCenters";
		private const string EndpointCollectionName = "Endpoints";
		private const string EnvironmentCollectionName = "Environments";

		[ConfigurationProperty(DataCenterCollectionName)]
		[ConfigurationCollection(typeof(DataCenterCollection), AddItemName = "add")]
		public DataCenterCollection DataCenters { get { return (DataCenterCollection)base[DataCenterCollectionName]; } }

		[ConfigurationProperty(EndpointCollectionName)]
		[ConfigurationCollection(typeof(EndpointCollection), AddItemName = "add")]
		public EndpointCollection Endpoints { get { return (EndpointCollection)base[EndpointCollectionName]; } }

		[ConfigurationProperty(EnvironmentCollectionName)]
		[ConfigurationCollection(typeof(EnvironmentCollection), AddItemName = "add")]
		public EnvironmentCollection Environments { get { return (EnvironmentCollection)base[EnvironmentCollectionName]; } }
	}
}
