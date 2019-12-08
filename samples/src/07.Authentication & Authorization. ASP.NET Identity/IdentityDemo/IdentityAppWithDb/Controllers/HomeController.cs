using IdentityDemoApp.Infrastructure.Authentication;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemoApp.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            var identity = (ClaimsIdentity)this.User.Identity;
            return View((object)identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminTest()
        {
            return View();
        }
    }
}