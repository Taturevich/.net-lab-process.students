// <copyright file="AppointmentController.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Controllers
{
    using System;
    using System.Web.Mvc;

    using TestWebApp.Models;

    public class AppointmentController : Controller
    {
        public ActionResult MakeBooking()
        {
            var model = new Appointment() { Date = DateTime.UtcNow };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult MakeBooking(Appointment appointment)
        {
            if (this.ModelState.IsValid)
            {
                return this.View("Completed", appointment);
            }

            return this.View(appointment);
        }
    }
}