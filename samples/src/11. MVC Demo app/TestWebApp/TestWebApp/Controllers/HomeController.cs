// <copyright file="HomeController.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Controllers
{
    using System.Web.Mvc;

    using TestWebApp.Models;
    using TestWebApp.Services;

    public class HomeController : Controller
    {
        private readonly IEventService serivce;

        public HomeController(IEventService serivce)
        {
            this.serivce = serivce;
        }

        public ActionResult Index()
        {
            var model = new Person() { FirstName = "John", LastName = "Doe", Role = Role.Admin, IsApproved = true };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Person([Bind(Exclude = "IsApproved, Role")] Person person)
        {
            return this.View(person);
        }

        public ActionResult Event(int id)
        {
            return this.Content(this.serivce.GetEventById(id));
        }
    }
}