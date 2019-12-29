using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using AppConfigExample.AdvancedExamplesData.Configuration;

namespace AppConfigExample.AdvancedExamplesData
{
	/// <summary>
	/// Holds a Data Center's properties.
	/// </summary>
	public class DataCenter
	{
		public string Name { get; set; }
		public int Value { get; set; }

		/// <summary>
		/// Returns if this Data Center has a Name and Value greater than zero.
		/// </summary>
		public bool IsValid { get { return !string.IsNullOrWhiteSpace(Name) && Value > 0; } }
	}

	/// <summary>
	/// A collection of known Data Centers.
	/// </summary>
	public static class DataCenters
	{
		/// <summary>
		/// A list of known Connection Environments.
		/// </summary>
		public static IEnumerable<DataCenter> DataCentersList { get { foreach (var dataCenter in _dataCentersList) { yield return dataCenter; } } }
		private static readonly List<DataCenter> _dataCentersList = new List<DataCenter>();

		/// <summary>
		/// Constructor.
		/// </summary>
		static DataCenters()
		{
			// Grab the Data Centers listed in the App.config and add them to our list.
			var customSection = ConfigurationManager.GetSection(CustomConfigurationSection.SectionName) as CustomConfigurationSection;
			if (customSection != null)
			{
				foreach (DataCenterElement dataCenterElement in customSection.DataCenters)
				{
					var dataCenter = new DataCenter() { Name = dataCenterElement.Name, Value = dataCenterElement.DataCenter };
					AddDataCenter(dataCenter);
				}
			}
		}

		/// <summary>
		/// Adds the given DataCenter to the list of DataCenters.
		/// <para>NOTE: Null, duplicate, and Invalid values will not be added.</para>
		/// </summary>
		/// <param name="dataCenter">The DataCenter to add.</param>
		public static void AddDataCenter(DataCenter dataCenter)
		{
			if (dataCenter == null || !dataCenter.IsValid)
				return;

			if (!_dataCentersList.Contains(dataCenter))
				_dataCentersList.Add(dataCenter);
		}

		/// <summary>
		/// Removes the given DataCenter from the list of DataCenters.
		/// </summary>
		/// <param name="dataCenter">The DataCenter to remove.</param>
		public static void RemoveDataCenter(DataCenter dataCenter)
		{
			if (dataCenter == null)
				return;

			if (_dataCentersList.Contains(dataCenter))
				_dataCentersList.Remove(dataCenter);
		}
	}
}
