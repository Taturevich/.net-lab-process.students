using IdentityDemoApp.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDemoApp.Core
{
    public interface IUserService
    {
        UserDto GetUserByName(string userName);

        UserDto GetUserById(string id);

        void AddUser(UserDto user);

        void UpdateUser(UserDto user);

        IEnumerable<string> GetUserRoles(string userName);
    }
}
