using System;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Core.Emails;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Exceptions;
using DormFinder.Web.Models;
using DormFinder.Web.Models.Request;
using DormFinder.Web.Services;
using DormFinder.Web.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly AccountService _accountService;
        private readonly InvitationService _invitationService;

        public AccountController(
            IMapper mapper,
            UserManager<User> userManager,
            TokenService tokenService,
            AccountService accountService,
            InvitationService invitationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _accountService = accountService;
            _invitationService = invitationService;
        }

        [HttpGet]
        public async Task<ActionResult<UserModel>> GetInformation()
        {
            var user = await _accountService.GetInformation();

            if (user is null)
            {
                return BadRequest($"No user with the id `{user.Id}` exists.");
            }

            var userModel = UserModel.FromUser(user);

            return userModel;
        }

        // POST api/account/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> Register([FromBody] RegisterModel model)
        {
            var newUser = _mapper.Map<User>(model);
            newUser.UserName = model.Email;
            newUser.Status = "Pending";
            newUser.Address.City = model.City;
            newUser.UserType = model.UserType;

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            if(model.UserType == "Landlord")
            {
                await _accountService.CreateOrganization(newUser);
            }
            
            await _invitationService.Invite(newUser, "role", "organization");

            await _accountService.GenerateEmployeesImages(newUser);

            return _mapper.Map<UserModel>(newUser);
        }

        [HttpGet("tokens")]
        [AllowAnonymous]
        public async Task<ActionResult> Verify([FromQuery] string token)
        {
            var principal = _tokenService.Decode(token);
            var claims = new RegistrationClaims(principal);

            var user = await _userManager.FindByIdAsync(claims.UserId);

            if (user is null)
            {
                return BadRequest(new { Error = "Could't find a user." });
            }

            user.Status = "Verified";
            user.VerifiedAt = DateTime.Now;

            await _userManager.UpdateAsync(user);

            return Ok();
        }

        // POST api/account/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResult>> Login(
            [FromBody] LoginModel model,
            [FromServices] LoginService loginService)
        {
            try
            {
                var token = await loginService.LogIn(model.Email, model.Password);

                return new LoginResult { Token = token };
            }
            catch (LoginException ex)
            {
                return BadRequest(new { ErrorType = ex.Message });
            }
        }

        //FOR TESTING EMAIL SERVICE-----------------
        [HttpGet("send-email")]
        public async Task<ActionResult> Send([FromServices] EmailService service)
        {
            var email = new Email
            {
                Recipients = { "jcsalayo2@gmail.com" },
                Subject = "Test",
                Html = "<p>Hello</p>",
                Text = "Hello"
            };

            await service.Send(email);

            return Ok("Email sent");
        }

        public class LoginResult
        {
            public string Token { get; set; }
        }
    }
}
