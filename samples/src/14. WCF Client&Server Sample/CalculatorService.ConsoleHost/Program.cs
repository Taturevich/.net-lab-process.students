using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CalculatorService.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Core.CalculatorService));
            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;
            host.Authorization.ExternalAuthorizationPolicies = new ReadOnlyCollection<IAuthorizationPolicy>(new List<IAuthorizationPolicy> { new AuthorizationPolicy() });
            host.Open();
            Console.WriteLine("Service started");
            Console.ReadLine();
            host.Close();
        }
    }
}
