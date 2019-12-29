using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace WebHost
{
    public class UserPasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "user" && password == "password")
            {
                return;
            }

            if (userName == "user2" && password == "password")
            {
                return;
            }

            if (userName == "user3" && password == "password")
            {
                return;
            }

            throw new SecurityTokenValidationException();
        }
    }
}