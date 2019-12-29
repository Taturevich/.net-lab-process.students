using Autofac;
using Autofac.Integration.Mvc;
using IdentityDemoApp.Core;
using IdentityDemoApp.Infrastructure.Authentication;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemoApp.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CustomUserStore>().As<IUserStore<User, string>>();
            builder.RegisterType<UserManager<User, string>>().AsSelf();

            // just for demo purposes
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}