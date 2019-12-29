using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserCatalogue.Api.Infrastructure;

namespace UserCatalogue.Api.Stores
{
    public class CustomRoleStore : IRoleStore<IdentityRole>
    {
        private readonly UserCatalogueContext _context;

        public CustomRoleStore(UserCatalogueContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            _context.Roles.Add(new Role { Name = role.NormalizedName });
            await _context.SaveChangesAsync(cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }

        public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id);
        }

        public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        Task<IdentityRole> IRoleStore<IdentityRole>.FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<IdentityRole> IRoleStore<IdentityRole>.FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(u => u.Name == normalizedRoleName, cancellationToken: cancellationToken);
            return role is null ? null : new IdentityRole { Name = role.Name, NormalizedName = role.Name };
        }
    }
}