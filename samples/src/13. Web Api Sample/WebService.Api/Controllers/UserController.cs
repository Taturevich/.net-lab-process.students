using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Swashbuckle.Swagger.Annotations;
using WebService.Api.Models;

namespace WebService.Api.Controllers
{
    [SwaggerResponse(HttpStatusCode.Unauthorized)]
    [Authorize]
    public class UserController : ApiController
    {
        private static readonly List<User> Users = new List<User>
        {
            new User { Id = 1, Name = "Bob" },
            new User { Id = 2, Name = "Dave" }
        };

        /// <summary>
        /// Gets existing users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(User[]))]
        public async Task<IHttpActionResult> GetUsers()
        {
            return await Task.FromResult(Ok(Users));
        }

        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Type = typeof(void))]
        [Authorize]
        public async Task<IHttpActionResult> AddUsers([FromBody]User user)
        {
            if (user is null)
            {
                return await Task.FromResult(BadRequest());
            }

            Users.Add(user);
            return new StatusCodeResult(HttpStatusCode.NoContent, Request);
        }
    }
}