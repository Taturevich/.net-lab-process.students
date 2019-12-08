using IdentityDemoApp.Infrastructure.Authentication;
using IdentityDemoApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemoApp.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager _authenticationManager => HttpContext.GetOwinContext().Authentication;
        private UserManager<User, string> _userManager;

        public AccountController(UserManager<User, string> userManager)
        {
            _userManager = userManager;
            _userManager.PasswordValidator = new MinimumLengthValidator(1);
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindAsync(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View();
            }

            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignOut();
            _authenticationManager.SignIn(identity);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                SomeAdditionalField = model.SomeAdditionalField
            };

            var result = await this._userManager.CreateAsync(user, model.Password);

            return RedirectToAction("Login", "Account");
        }
    }
}