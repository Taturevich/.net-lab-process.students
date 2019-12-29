using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace CalculatorService.ConsoleHost
{
    public class AuthorizationPolicy : IAuthorizationPolicy
    {
        private static readonly Dictionary<string, List<string>> UserRoles = new Dictionary<string, List<string>>();

        static AuthorizationPolicy()
        {
            UserRoles.Add("user", new List<string> { "User" });
            UserRoles.Add("user2", new List<string> { "Admin", "Manager" });
            UserRoles.Add("user3", new List<string> { "Manager" });
        }

        public ClaimSet Issuer => ClaimSet.System;

        public string Id => Guid.NewGuid().ToString();

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            var identity = (evaluationContext.Properties["Identities"] as List<IIdentity>)?.Single();
            var claimsIdentity = identity is null ? new ClaimsIdentity() : new ClaimsIdentity(identity);
            if (identity != null)
            {
                UserRoles.TryGetValue(identity.Name, out var roles);
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        claimsIdentity.AddClaim(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, role));
                    }
                }
            }

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            evaluationContext.Properties["Principal"] = claimsPrincipal;

            Thread.CurrentPrincipal = claimsPrincipal;
            return true;
        }
    }
}