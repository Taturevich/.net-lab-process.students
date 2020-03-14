using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserModel user)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", user.Login),
                new KeyValuePair<string, string>("password", user.Password)
            });
            var result = await httpClient.PostAsync("users/register", formContent);
            if (result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync();
                HttpContext.Response.Cookies.Append("secret_jwt_key", token, new CookieOptions 
                { 
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });

                return Ok();
            }

            return Forbid();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserModel user)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", user.Login),
                new KeyValuePair<string, string>("password", user.Password)
            });
            var result = await httpClient.PostAsync("users/login", formContent);
            if (result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync();
                HttpContext.Response.Cookies.Append("secret_jwt_key", token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });

                return Ok();
            }

            return Forbid();
        }
    }
}
