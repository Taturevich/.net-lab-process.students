// <copyright file="ErrorController.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            this.Response.StatusCode = 500;
            return this.View("Error");
        }
    }
}