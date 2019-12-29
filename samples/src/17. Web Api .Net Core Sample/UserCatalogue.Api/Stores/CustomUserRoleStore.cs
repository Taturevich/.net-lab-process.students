using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserCatalogue.Api.Infrastructure;

namespace UserCatalogue.Api.Stores
{
    public class CustomUserRoleStore : CustomUserPasswordStore, IUserRoleStore<IdentityUser>
    {
        public CustomUserRoleStore(UserCatalogueContext context)
            : base(context)
        {
        }

        public async Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var userId = int.Parse(user.Id);
            var role = await Context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, cancellationToken: cancellationToken);
            Context.UserRoles.Add(new UserRole { UserId = userId, RoleId = role.Id });
            await Context.SaveChangesAsync(cancellationToken);
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var userId = int.Parse(user.Id);

            var result = from userRole in Context.UserRoles
                         join role in Context.Roles on userRole.RoleId equals role.Id
                         where userRole.UserId == userId
                         select role.Name;

            return await result.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var userId = int.Parse(user.Id);
            var role = await Context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, cancellationToken: cancellationToken);
            var isUserInRole = await Context.UserRoles.AnyAsync(userRole => userRole.UserId == userId && userRole.RoleId == role.Id, cancellationToken: cancellationToken);
            return isUserInRole;
        }

        public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}