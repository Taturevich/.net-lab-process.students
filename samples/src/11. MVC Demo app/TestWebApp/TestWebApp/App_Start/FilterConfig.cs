// <copyright file="FilterConfig.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.App_Start
{
    using System.Web.Mvc;

    using TestWebApp.Infrastructure;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SimpleExceptionFilter());
        }
    }
}