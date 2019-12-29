using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using IdentityDemoApp.Core;

namespace IdentityDemoApp.Infrastructure.Authentication
{
    public class CustomUserStore : IUserClaimStore<User>, IUserPasswordStore<User>
    {
        private IUserService _userService; 

        public CustomUserStore(IUserService userService)
        {
            _userService = userService;
        }

        public Task AddClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User user)
        {
            var userDto = DtoFromUser(user);
            userDto.Id = Guid.NewGuid().ToString();
            _userService.AddUser(userDto);
            return Task.FromResult(0);
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<User> FindByIdAsync(string userId)
        {
            var userDto = _userService.GetUserById(userId);
            var result = userDto != null ? UserFromDto(userDto) : null;
            return Task.FromResult(result);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var userDto = _userService.GetUserByName(userName);
            var result = userDto != null ? UserFromDto(userDto) : null;
            return Task.FromResult(result);
        }

        public Task<IList<Claim>> GetClaimsAsync(User user)
        {
            // here you should go for roles to role's storage and return this in claims like in the code below
            // after this this roles will be available in User.Identity.Role

            var roles = this._userService.GetUserRoles(user.UserName);
            IList<Claim> claims = new List<Claim>();
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Instead of IPrinciple extension
            // You can fin how to get claims in the Home/Index action
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            return Task.FromResult(claims);

        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            var userDto = _userService.GetUserById(user.Id);
            return Task.FromResult(userDto.PasswordHash != null);
        }

        public Task RemoveClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(User user)
        {
            // implement this if you want to update user data
            // for password changing will be used SetPasswordHashAsync method via UserManager.ChangePassword
            throw new NotImplementedException();
        }

        // just for demo purposes
        private User UserFromDto(UserDto user)
        {
            return new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                SomeAdditionalField = user.SomeAdditionalField,
                PasswordHash = user.PasswordHash
            };
        }

        // just for demo purposes
        private UserDto DtoFromUser(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                SomeAdditionalField = user.SomeAdditionalField,
                PasswordHash = user.PasswordHash
            };
        }
    }
}