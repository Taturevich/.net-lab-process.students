using Microsoft.AspNet.Identity;

namespace WebService.Api.Core
{
    public class UserModel : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}