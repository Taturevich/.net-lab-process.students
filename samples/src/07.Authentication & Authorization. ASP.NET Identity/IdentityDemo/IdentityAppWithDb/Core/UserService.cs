using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityDemoApp.Core
{
    public class UserService : IUserService
    {
        private readonly List<UserDto> users = new List<UserDto>();

        public void AddUser(UserDto user)
        {
            users.Add(user);
        }

        public UserDto GetUserByName(string userName)
        {
            return users.FirstOrDefault(x => x.UserName == userName);
        }

        public UserDto GetUserById(string id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateUser(UserDto user)
        {
            if (users.Any(x => x.Id == user.Id))
            {
                users.RemoveAll(x => x.Id == user.Id);
                users.Add(user);
            }
        }

        // for demo purposes
        public IEnumerable<string> GetUserRoles(string userName)
        {
            if (userName == "admin")
            {
                return new[] { "Admin", "User" };
            }

            return new[] { "User" };
        }
    }
}