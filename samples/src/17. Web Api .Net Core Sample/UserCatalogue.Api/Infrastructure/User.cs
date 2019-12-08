using System.Collections.Generic;

namespace UserCatalogue.Api.Infrastructure
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}