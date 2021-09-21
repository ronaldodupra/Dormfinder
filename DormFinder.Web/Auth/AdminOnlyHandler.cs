using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Auth
{
    public class AdminOnlyHandler : AuthorizationHandler<AdminOnlyRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AdminOnlyRequirement requirement)
        {
            if (context.User.HasClaim(t => t.Type == CustomClaimTypes.CompanyId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
