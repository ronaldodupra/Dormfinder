using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DormFinder.Web.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DormFinder.Web.Controllers
{
    [ApiController]
    public class ExternalSigninController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        public ExternalSigninController(UserManager<User> userManager, 
            SignInManager<User> signInManage,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManage;
            _logger = logger;
        }

        [HttpPost("ExternalLogin")]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "ExternalSignin", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet("ExternalLoginCallback")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                //return View(nameof(Login));
                return Ok();
            }
            
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                //Error
                //return RedirectToAction(nameof(Login));
                return Ok();
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                // Update any authentication tokens if login succeeded
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);

                _logger.LogInformation(5, "User logged in with {Name} provider.", info.LoginProvider);
                return Redirect("http://localhost:4200/");
            }
            if (result.RequiresTwoFactor)
            {
                //return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl });
                return Ok();
            }
            if (result.IsLockedOut)
            {
                //return View("Lockout");
                return Ok();
            }
            else
            {
                var userAccount = _userManager.FindByEmailAsync(info.Principal.FindFirstValue(ClaimTypes.Email));

                var user = userAccount.Result;

                if (user == null)
                {
                    user = new User
                    {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        LastName = info.Principal.FindFirstValue(ClaimTypes.Surname),
                        FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                        UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                        Status = "Verified",
                        VerifiedAt = DateTime.Now
                    };

                    var createResult = await _userManager.CreateAsync(user);

                    if (!createResult.Succeeded)
                    {
                        return BadRequest(createResult.Errors);
                    }
                }                

                await _userManager.AddLoginAsync(user, info);

                await _signInManager.SignInAsync(user, isPersistent: false);

                return Redirect("http://localhost:4200/");
            }
        }
    }
}
