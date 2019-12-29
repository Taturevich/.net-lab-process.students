using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WebService.Api.Models;

namespace WebService.Api.Core
{
    public class AuthRepository : IDisposable
    {
        private UserManager<UserModel> _userManager;

        public AuthRepository()
        {
            _userManager = new UserManager<UserModel>(new UserSotre());
        }

        public async Task<IdentityResult> RegisterUser(UserAuthModel userModel)
        {
            var user = new UserModel
            {
                UserName = userModel.Login
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<UserModel> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}