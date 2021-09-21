using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DormFinder.Web.Auth;
using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;

namespace DormFinder.Web.Services.Services
{
    public class UserTokenService
    {
        private readonly TokenService _tokenService;

        public UserTokenService(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public ClaimsPrincipal Decode(string encodedToken)
        {
            return _tokenService.Decode(encodedToken);
        }

        /// <summary>
        /// Create a token from a user.
        /// The token service does not ensure that user is to be given a token.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userOrganization"></param>
        /// <returns></returns>
        public string CreateAccessToken(User user, UserOrganization userOrganization)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(CustomClaimTypes.UserType, user.UserType)
            };

            if (userOrganization != null)
            {
                claims.Add(new Claim(CustomClaimTypes.CompanyId, userOrganization.OrganizationId.ToString()));
            }

            return _tokenService.Encode(
                timeToExpire: TimeSpan.FromHours(24),
                customClaims: claims);
        }

        public string CreateInvitationToken(User user, string role, string organization)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            return _tokenService.Encode(
                timeToExpire: TimeSpan.FromHours(168),
                customClaims: claims);
        }

        public string CreateResetPasswordToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            return _tokenService.Encode(
                timeToExpire: TimeSpan.FromMinutes(10),
                customClaims: claims);
        }
    }
}
