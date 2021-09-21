using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Auth
{
    public class AdminOnlyPolicyProvider : IAuthorizationPolicyProvider
    {
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
           Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() =>
            Task.FromResult<AuthorizationPolicy>(null);

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (string.Equals(policyName, AdminOnlyAttribute.PolicyPrefix))
            {
                var builder = new AuthorizationPolicyBuilder();
                builder.AddRequirements(new AdminOnlyRequirement());

                return Task.FromResult(builder.Build());
            }

            return Task.FromResult<AuthorizationPolicy>(null);
        }
    }
}
