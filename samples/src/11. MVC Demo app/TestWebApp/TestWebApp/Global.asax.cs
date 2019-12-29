// <copyright file="Global.asax.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TestWebApp
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using TestWebApp.App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ResolverConfig.RegisterResolver();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
