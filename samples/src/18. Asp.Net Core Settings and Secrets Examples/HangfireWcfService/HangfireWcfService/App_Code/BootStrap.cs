using System;
using System.Diagnostics;
using System.Threading;
using Hangfire;

namespace HangfireWcfService
{
    public class BootStrap
    {
        public static void AppInitialize()
        {
            // put connection to your database here
            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Data Source=localhost;Initial Catalog=Hangfire;Integrated Security=True;");
            new Thread(() => 
            {
                using (new BackgroundJobServer())
                {
                    Debug.WriteLine("Hangfire Server started. Press ENTER to exit...");
                    BackgroundJob.Enqueue(() => Debug.WriteLine("New job was added"));
                    Console.ReadLine();
                }
            }).Start();
        }
    }
}
