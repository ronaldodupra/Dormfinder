using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Auth;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using DormFinder.Web.Users.Model;
using DormFinder.Web.Users.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    //[AdminOnly]
    public class UserController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly UserService _userService;
        private readonly IFileEntryRepository _fileEntryRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UserController(ICurrentUser currentUser,
            UserService userService,
            IMapper mapper,
            ILogger<UserController> logger,
            IFileEntryRepository fileEntryRepository)
        {
            _currentUser = currentUser;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _fileEntryRepository = fileEntryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userService.GetUserById(_currentUser.Id);

            return _mapper.Map<UserDto>(user);
        }

        [HttpGet(("{id}/image"))]
        [AllowAnonymous]
        public async Task<ActionResult<Stream>> GetImage(int id, [FromServices] IFilesystem filesystem)
        {
            var path = await _userService.GetImagePathById(id);

            return await filesystem.Get(path);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUser(UpdateUserDto user)
        {
            _logger.LogInformation("Update User with id #{_currentUser.Id}", _currentUser.Id);

            return await _userService.UpdateUser(_currentUser.Id, user);
        }

        [HttpPost("update-image")]
        public async Task<ActionResult<FileEntryDto>> UpdateUserImage([FromForm] FileUploadAccountForm form, [FromServices] IFilesystem filesystem)
        {
            _logger.LogInformation("Update User image with id #{_currentUser.Id}", _currentUser.Id);

            return await _userService.UpdateUserImage(_currentUser.Id, form.File, filesystem);
        }

        public class FileUploadAccountForm
        {
            public IFormFile File { get; set; }

            public string Id { get; set; }
        }
    }
}
