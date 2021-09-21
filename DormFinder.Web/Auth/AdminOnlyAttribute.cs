using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Auth
{
    public class AdminOnlyAttribute : AuthorizeAttribute
    {
        public const string PolicyPrefix = "AdminOnly";

        public AdminOnlyAttribute()
        {
            Policy = PolicyPrefix;
        }
    }
}
