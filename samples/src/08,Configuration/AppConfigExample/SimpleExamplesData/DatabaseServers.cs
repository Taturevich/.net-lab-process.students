using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AppConfigExample.SimpleExamplesData
{
	/// <summary>
	/// A collection of known Database Servers.
	/// </summary>
	public static class DatabaseServers
	{
		/// <summary>
		/// List of known Connection Database Servers.
		/// </summary>
		public static IEnumerable<string> DatabaseServersList { get { foreach (var server in _databaseServersList) { yield return server; } } }
		private static readonly List<string> _databaseServersList = new List<string>();

		/// <summary>
		/// Constructor.
		/// </summary>
		static DatabaseServers()
		{
			// Grab the Database Servers listed in the App.config and add them to our list.
			var databaseServers = ConfigurationManager.GetSection("DatabaseServers") as NameValueCollection;
			if (databaseServers != null)
			{
				foreach (string databaseServerKey in databaseServers.AllKeys)
				{
					AddDatabaseServer(databaseServers[databaseServerKey]);

					// If we wanted to, we could also store the Key string as the user-friendly name of the database server with something like:
					// AddDatabaseServer(databaseServerKey, databaseServers[databaseServerKey]);
					// We would just need to modify the DatabaseServersList to be a Dictionary or other structure that can hold 2 string values rather than a List<string>.
				}
			}
		}

		/// <summary>
		/// Adds the given Database Server to the list of Database Servers.
		/// <para>NOTE: Null and duplicate values will not be added.</para>
		/// </summary>
		/// <param name="databaseServer">The Database Server to add.</param>
		public static void AddDatabaseServer(string databaseServer)
		{
			if (databaseServer == null)
				return;

			if (!_databaseServersList.Contains(databaseServer))
				_databaseServersList.Add(databaseServer);
		}

		/// <summary>
		/// Removes the given Database Server from the list of Database Servers.
		/// </summary>
		/// <param name="databaseServer">The Database Server to remove.</param>
		public static void RemoveDatabaseServer(string databaseServer)
		{
			if (databaseServer == null)
				return;

			if (_databaseServersList.Contains(databaseServer))
				_databaseServersList.Remove(databaseServer);
		}
	}
}
