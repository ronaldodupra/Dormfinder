using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace DormFinder.Web.Auth
{
    public class CurrentUser : ICurrentUser
    {
        public int Id { get; private set; }

        public int? OrganizationId { get; private set; }

        public CurrentUser(IHttpContextAccessor accessor)
        {
            ReadClaims(accessor?.HttpContext?.User);
        }

        private void ReadClaims(ClaimsPrincipal user)
        {
            if (user is null)
            {
                return;
            }

            ReadUserId(user);
            ReadOrganizationId(user);
        }

        private void ReadUserId(ClaimsPrincipal principal)
        {
            var value = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            Id = value is null ? 0 : int.Parse(value);
        }

        private void ReadOrganizationId(ClaimsPrincipal principal)
        {
            var value = principal.FindFirstValue(CustomClaimTypes.CompanyId);

            OrganizationId = int.TryParse(value, out var result) ? result : (int?)null;
        }
    }
}
