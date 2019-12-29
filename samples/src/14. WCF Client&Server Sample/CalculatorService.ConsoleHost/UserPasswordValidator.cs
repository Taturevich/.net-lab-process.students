using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace CalculatorService.ConsoleHost
{
    public class UserPasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "user" && password == "password")
            {
                Console.WriteLine("Authorized");
                return;
            }

            if (userName == "user2" && password == "password")
            {
                Console.WriteLine("Authorized");
                return;
            }

            if (userName == "user3" && password == "password")
            {
                Console.WriteLine("Authorized");
                return;
            }

            throw new SecurityTokenValidationException();
        }
    }
}