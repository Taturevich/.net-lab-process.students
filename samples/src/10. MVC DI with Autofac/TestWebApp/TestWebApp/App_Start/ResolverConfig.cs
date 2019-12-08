// <copyright file="ResolverConfig.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.App_Start
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Autofac;
    using Autofac.Integration.Mvc;

    public static class ResolverConfig
    {
        /// <summary>
        /// The register resolver.
        /// </summary>
        public static void RegisterResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterInstance(RouteTable.Routes).As<IEnumerable<RouteBase>>();
            builder.RegisterModule<AppModule>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}