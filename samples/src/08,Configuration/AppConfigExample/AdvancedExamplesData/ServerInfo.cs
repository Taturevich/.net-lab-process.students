using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppConfigExample.AdvancedExamplesData
{
	/// <summary>
	/// Info about the server to talk to.
	/// This is used by the Endpoint class.
	/// </summary>
	public class ServerInfo
	{
		/// <summary>
		/// The address of the server.
		/// </summary>
		public string Address;

		/// <summary>
		/// Whether SSL should be used when talking to the server or not.
		/// </summary>
		public bool UseSsl;

		/// <summary>
		/// The Active Directory Security Groups that are allowed to save changes back to the server.
		/// If null or empty we assume that all users are allowed to save changes.
		/// </summary>
		public List<string> SecurityGroupsAllowedToSaveChanges;

		/// <summary>
		/// Explicit constructor.
		/// </summary>
		/// <param name="address">The address of the server.</param>
		/// <param name="useSsl">Whether SSL should be used when talking to the server or not.</param>
		/// <param name="securityGroupsAllowedToSaveChanges">List of security groups that should be allowed to save changes.</param>
		public ServerInfo(string address = "", bool useSsl = false, List<string> securityGroupsAllowedToSaveChanges = null)
		{
			Address = address;
			UseSsl = useSsl;
			SecurityGroupsAllowedToSaveChanges = securityGroupsAllowedToSaveChanges;
		}

		/// <summary>
		/// Returns true if this instance is empty, false otherwise.
		/// </summary>
		public bool IsEmpty { get { return this.Equals(_empty); } }

		/// <summary>
		/// Gets an empty ConnectionManagerServerInfo instance.
		/// </summary>
		public static ServerInfo Empty { get { return _empty; } }
		private static readonly ServerInfo _empty = new ServerInfo();
	}
}
