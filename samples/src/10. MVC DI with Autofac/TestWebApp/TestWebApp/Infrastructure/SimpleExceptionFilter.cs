// <copyright file="SimpleExceptionFilter.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Infrastructure
{
    using System.Web.Mvc;

    public class SimpleExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Error");
        }
    }
}