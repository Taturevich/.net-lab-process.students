using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WebService.Api.Core
{
    public class UserSotre : IUserStore<UserModel>, IUserPasswordStore<UserModel>
    {
        public static readonly List<UserModel> Users = new List<UserModel>
        {
            new UserModel { Id = 1.ToString(), UserName = "Bob12345" },
            new UserModel { Id = 2.ToString(), UserName = "Dave12345" },
            new UserModel { Id = 3.ToString(), UserName = "John12345" },
        };

        public void Dispose()
        {
        }

        public Task CreateAsync(UserModel user)
        {
            Users.Add(user);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(UserModel user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(UserModel user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserModel> FindByIdAsync(string userId)
        {
            return Task.FromResult(Users.SingleOrDefault(x => x.Id == userId));
        }

        public Task<UserModel> FindByNameAsync(string userName)
        {
            var user = Users.SingleOrDefault(x => x.UserName == userName);
            return Task.FromResult(user);
        }

        public Task SetPasswordHashAsync(UserModel user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(UserModel user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(UserModel user)
        {
            return Task.FromResult(true);
        }
    }
}