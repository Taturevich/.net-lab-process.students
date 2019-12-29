using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using AppConfigExample.AdvancedExamplesData.Configuration;

namespace AppConfigExample.AdvancedExamplesData
{
	/// <summary>
	/// Holds an Endpoint's properties.
	/// </summary>
	public class Endpoint
	{
		/// <summary>
		/// The Name of this Endpoint.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The Server Info used to connect to the Endpoint.
		/// </summary>
		public ServerInfo ServerInfo { get; set; }

		/// <summary>
		/// Returns true if this instance does not contain a valid Address, false otherwise.
		/// </summary>
		public bool IsEmpty { get { return string.IsNullOrEmpty(Name) && ServerInfo.IsEmpty; } }
	}

	/// <summary>
	/// A collection of known Endpoints.
	/// </summary>
	public static class Endpoints
	{
		/// <summary>
		/// A list of known Connection Environments.
		/// </summary>
		public static IEnumerable<Endpoint> EndpointsList { get { foreach (var endpoint in _endpointsList) { yield return endpoint; } } }
		private static readonly List<Endpoint> _endpointsList = new List<Endpoint>();

		/// <summary>
		/// Constructor.
		/// </summary>
		static Endpoints()
		{
			// Grab the Endpoints listed in the App.config and add them to our list.
			var customSection = ConfigurationManager.GetSection(CustomConfigurationSection.SectionName) as CustomConfigurationSection;
			if (customSection != null)
			{
				foreach (EndpointElement endpointElement in customSection.Endpoints)
				{
					var endpoint = new Endpoint() { Name = endpointElement.Name, ServerInfo = new ServerInfo() { Address = endpointElement.Address, UseSsl = endpointElement.UseSSL, SecurityGroupsAllowedToSaveChanges = endpointElement.SecurityGroupsAllowedToSaveChanges.Split(',').Where(e => !string.IsNullOrWhiteSpace(e)).ToList() } };
					AddEndpoint(endpoint);
				}
			}
		}

		/// <summary>
		/// Adds the given Endpoint to the list of Endpoints.
		/// <para>NOTE: Null, duplicate, and Invalid values will not be added.</para>
		/// </summary>
		/// <param name="endpoint">The Endpoint to add.</param>
		public static void AddEndpoint(Endpoint endpoint)
		{
			if (endpoint == null)
				return;

			if (!_endpointsList.Contains(endpoint))
				_endpointsList.Add(endpoint);
		}

		/// <summary>
		/// Removes the given Endpoint from the list of Endpoints.
		/// </summary>
		/// <param name="endpoint">The Endpoint to remove.</param>
		public static void RemoveEndpoint(Endpoint endpoint)
		{
			if (endpoint == null)
				return;

			if (_endpointsList.Contains(endpoint))
				_endpointsList.Remove(endpoint);
		}
	}
}
