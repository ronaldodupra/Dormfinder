using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DormFinder.Web.Services
{
    public class RegistrationClaims
    {
        public string UserId { get; private set; }

        public string EmailAddress { get; private set; }

        public RegistrationClaims(ClaimsPrincipal principal)
        {
            UserId = ReadClaim(principal, JwtRegisteredClaimNames.Sub);
            EmailAddress = ReadClaim(principal, JwtRegisteredClaimNames.Email);
        }

        public string ReadClaim(ClaimsPrincipal principal, string claimType)
        {
            var claim = principal.FindFirst(claimType);

            if (claim is null)
            {
                throw new Exception($"Claim `{claimType}` is missing from token");
            }

            return claim.Value;
        }
    }
}
