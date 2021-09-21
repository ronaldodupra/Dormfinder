using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using DormFinder.Web.Users.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Users.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IFileEntryRepository _fileEntryRepository;
        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IFileEntryRepository fileEntryRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _fileEntryRepository = fileEntryRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<string> GetImagePathById(int id)
        {
            var image = await _fileEntryRepository.GetFileById(id);

            return image.Path;
        }

        public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetUserById(id);

            _mapper.Map(updateUserDto, user);

            await _userRepository.SaveChanges();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<ActionResult<FileEntryDto>> UpdateUserImage(int id, IFormFile form, IFilesystem filesystem)
        {
            var randomId = DateTime.UtcNow.ToFileTime();
            var file = form;
            var extension = file.FileName.Split(".").Last();
            var key = $"{id}-{randomId}.{extension}";

            var target = $"Users/{id}/{key}";

            var location = await filesystem.Move(file, target);

            var user = await _userRepository.GetUserById(id);
            var attachment = new FileEntry(
                path: target,
                filename: key,
                mediaType: "image/jpeg",
                length: form.Length);

            user.OriginalImageId = attachment.Id;
            user.OriginalImage = attachment;

            await _userRepository.SaveChanges();

            return _mapper.Map<FileEntryDto>(attachment);
        }
    }
}
