using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;

namespace Pets
{
    public class TokenValidator : UserNamePasswordValidator
    {
        /// <summary>When overridden in a derived class, validates the specified username and password.</summary>
        /// <param name="userName">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        public override void Validate(string userName, string password)
        {
            var jwtToken = userName;

            //// VALIDATE JWT
        }
    }
}