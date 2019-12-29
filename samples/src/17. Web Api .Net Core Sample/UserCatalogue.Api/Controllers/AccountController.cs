using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserCatalogue.Api.Models;

namespace UserCatalogue.Api.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        /// <summary>
        /// The get token.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <remarks>The endpoint to get JWT</remarks>
        /// <response code="200">User signed in.</response>
        /// <response code="400">Wrong credentials.</response>
        /// <response code="500">Oops! Something went wrong</response>
        [Route("token")]
        [HttpPost]
        public async Task<object> GetToken([FromBody] UserModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            

            if (result.Succeeded)
            {
                var appUser = await _userManager.FindByNameAsync(model.Email);
                return await GenerateJwtToken(model.Email, appUser);
            }

            return BadRequest("INVALID_LOGIN_ATTEMPT");
        }

        [Route("register")]
        [HttpPost]
        public async Task<object> Register([FromBody] UserModel model)
        {
            var stringBuilder = new StringBuilder();

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };


            var isDefaultRoleExist = await _roleManager.RoleExistsAsync("User");

            if (!isDefaultRoleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, false);
                return await GenerateJwtToken(model.Email, user);
            }

            var errors = result.Errors?.Select(e => e.Description).ToArray();

            if (errors?.Any() is true)
            {
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine(error);
                }
            }

            return BadRequest(stringBuilder.ToString());
        }

        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };
            claims.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_configuration.GetValue<double>("JwtExpireDays"));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}