using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace WebService.Api.Core
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var repo = new AuthRepository())
            {
                if (string.IsNullOrWhiteSpace(context.UserName) || string.IsNullOrWhiteSpace(context.Password))
                {
                    context.SetError("invalid_grant", "The user name or password is empty.");
                    return;
                }

                var user = await repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
        }
    }
}