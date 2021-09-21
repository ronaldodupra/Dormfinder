using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Exceptions;
using DormFinder.Web.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class LoginService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly DormFinderContext _context;
        private readonly UserTokenService _tokenService;

        public LoginService(
            SignInManager<User> signInManager,
            DormFinderContext context,
            UserTokenService tokenService,
            UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> LogIn(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email==email);

            if (user is null)
            {
                throw LoginException.CredentialsMismatch();
            }

            var userOrganization = await _context
                .UserOrganizations
                .FirstOrDefaultAsync(t => t.UserId == user.Id);

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (!result.Succeeded)
            {
                throw LoginException.CredentialsMismatch();
            }

            var token = _tokenService.CreateAccessToken(user, userOrganization);

            return token;
        }
    }
}
