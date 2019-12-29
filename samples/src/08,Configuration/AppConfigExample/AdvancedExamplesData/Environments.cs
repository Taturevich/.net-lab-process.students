using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using AppConfigExample.AdvancedExamplesData.Configuration;

namespace AppConfigExample.AdvancedExamplesData
{
	/// <summary>
	/// A collection of known Connection Environments.
	/// </summary>
	public static class Environments
	{
		/// <summary>
		/// A list of known Connection Environments.
		/// </summary>
		public static IEnumerable<string> EnvironmentsList { get { foreach (var environment in _environmentsList) { yield return environment; } } }
		private static readonly List<string> _environmentsList = new List<string>();

		/// <summary>
		/// Constructor.
		/// </summary>
		static Environments()
		{
			// Grab the Environments listed in the App.config and add them to our list.
			var customSection = ConfigurationManager.GetSection(CustomConfigurationSection.SectionName) as CustomConfigurationSection;
			if (customSection != null)
			{
				foreach (EnvironmentElement environmentElement in customSection.Environments)
				{
					AddEnvironment(environmentElement.Environment);
				}
			}
		}

		/// <summary>
		/// Adds the given Environment to the list of Environments.
		/// <para>NOTE: Null and duplicate values will not be added.</para>
		/// </summary>
		/// <param name="environment">The Environment to add.</param>
		public static void AddEnvironment(string environment)
		{
			if (environment == null)
				return;

			if (!_environmentsList.Contains(environment))
				_environmentsList.Add(environment);
		}

		/// <summary>
		/// Removes the given Environment from the list of Environments.
		/// </summary>
		/// <param name="environment">The Environment to remove.</param>
		public static void RemoveEnvironment(string environment)
		{
			if (environment == null)
				return;

			if (_environmentsList.Contains(environment))
				_environmentsList.Remove(environment);
		}
	}
}
