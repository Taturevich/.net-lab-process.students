using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserCatalogue.Api.Infrastructure;

namespace UserCatalogue.Api.Stores
{
    public class CustomUserPasswordStore : IUserPasswordStore<IdentityUser>
    {
        public CustomUserPasswordStore(UserCatalogueContext context)
        {
            Context = context;
        }

        protected UserCatalogueContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var userToAdd = new User {Name = user.NormalizedUserName, Password = user.PasswordHash};
            Context.Users.Add(userToAdd);
            await Context.SaveChangesAsync(cancellationToken: cancellationToken);
            user.Id = userToAdd.Id.ToString();
            return IdentityResult.Success;
        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IdentityUser> IUserStore<IdentityUser>.FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<IdentityUser> IUserStore<IdentityUser>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = await Context.Users.FirstOrDefaultAsync(u => u.Name == normalizedUserName, cancellationToken: cancellationToken);
            return user is null ? null : new IdentityUser { Id = user.Id.ToString(), UserName = user.Name, NormalizedUserName = user.Name, PasswordHash = user.Password };
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user?.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}