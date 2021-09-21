using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Auth
{
    public class AdminOnlyRequirement : IAuthorizationRequirement
    {
    }
}
