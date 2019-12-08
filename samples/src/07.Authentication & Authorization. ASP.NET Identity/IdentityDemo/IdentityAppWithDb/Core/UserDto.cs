using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityDemoApp.Core
{
    public class UserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string SomeAdditionalField { get; set; }
    }
}