using System;
using System.IO;
using Microsoft.SqlServer.Dac;

namespace DacPacTry
{
    internal class Program
    {
        public static void Main()
        {
            const string dacPacName = "TicketManagement.dacpac";
            const string connectionString = "Server=localhost;Database=TicketManagement;trusted_connection=true";
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", dacPacName));
            var dacPack = new DacServices(connectionString);
            var dacOptions = new DacDeployOptions {CreateNewDatabase = true};
            using (var dp = DacPackage.Load(path))
            {
                dacPack.Deploy(dp, @"TicketManagement", true, dacOptions);
            }
        }
    }
}
