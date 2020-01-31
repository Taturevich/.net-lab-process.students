// <copyright file="HomeController.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Controllers
{
    using System.Web.Mvc;

    using TestWebApp.Services;

    public class HomeController : Controller
    {
        private readonly IEventService serivce;

        public HomeController(IEventService serivce)
        {
            this.serivce = serivce;
        }

        public ActionResult Index(int id)
        {
            return new EmptyResult();
            ////return this.Content(this.serivce.GetEventById(id));
        }

        public ActionResult Event(int id)
        {
            return this.Content(this.serivce.GetEventById(id));
        }
    }
}