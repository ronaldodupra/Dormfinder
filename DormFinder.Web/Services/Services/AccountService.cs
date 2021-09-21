using System;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Auth;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services.Services
{
    public class AccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly TokenService _tokenService;
        private readonly DormFinderContext _dormFinderContext;
        private readonly GenerateDefaultImageService _generateDefaultImageService;
        private readonly IFilesystem _fileSystem;
        private readonly IOrganizationRepository _organizationRepository;

        public AccountService(UserManager<User> userManager,
            ICurrentUser currentUser,
            TokenService tokenService,
            DormFinderContext dormFinderContext,
            GenerateDefaultImageService generateDefaultImageService,
            IFilesystem filesystem,
            IOrganizationRepository organizationRepository)
        {
            _userManager = userManager;
            _currentUser = currentUser;
            _tokenService = tokenService;
            _dormFinderContext = dormFinderContext;
            _generateDefaultImageService = generateDefaultImageService;
            _fileSystem = filesystem;
            _organizationRepository = organizationRepository;
        }

        public async Task<User> GetInformation()
        {
            var user = await _userManager.FindByIdAsync(_currentUser.Id.ToString());

            return user;
        }

        public async Task GenerateEmployeesImages(User newUser)
        {
            //var user = await _dormFinderContext.Users.Where(x => x.Id == newUser.Id).FirstOrDefaultAsync();

            newUser.OriginalImage = await CreateOriginalImage(newUser);

            //foreach (var user in users)
            //{
            //    user.OriginalImage = await CreateOriginalImage(user);
            //}

            _dormFinderContext.Entry(newUser).State = EntityState.Modified;

            await _dormFinderContext.SaveChangesAsync();
        }

        private async Task<FileEntry> CreateOriginalImage(User user)
        {
            using var virtualFile = _generateDefaultImageService.Create(user);
            var path = $"Users/{user.Id}/{virtualFile.Filename}";

            await _fileSystem.Move(virtualFile.Stream, path);

            var file = new FileEntry(
                path: path,
                filename: virtualFile.Filename,
                mediaType: "image/jpeg",
                length: virtualFile.Size);

            //file.CreatedById = _currentUser.UserId;
            //file.UpdatedById = file.CreatedById;

            _dormFinderContext.FileEntries.Add(file);
            await _dormFinderContext.SaveChangesAsync();

            return file;
        }

        public async Task CreateOrganization(User user)
        {
            var newOrganization = new Organization
            {

            };

            await _organizationRepository.CreateOrganizationAsync(newOrganization);

            var newUserOrganization = new UserOrganization
            {
                UserId = user.Id,
                OrganizationId = newOrganization.Id
            };

            await _organizationRepository.CreateUserOrganizationAsync(newUserOrganization);

        }
    }
}
