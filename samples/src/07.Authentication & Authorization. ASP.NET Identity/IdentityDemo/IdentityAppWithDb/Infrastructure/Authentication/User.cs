using Microsoft.AspNet.Identity;

namespace IdentityDemoApp.Infrastructure.Authentication
{
    public class User : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string SomeAdditionalField { get; set; }

        public string PasswordHash { get; set; }
    }
}