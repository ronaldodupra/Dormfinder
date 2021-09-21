using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly IFileEntryRepository _fileEntryRepository;
        private readonly IMapper _mapper;

        public FilesController(IFileEntryRepository fileEntryRepository, IMapper mapper)
        {
            _fileEntryRepository = fileEntryRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Stream>> Preview(int id, [FromServices] IFilesystem filesystem)
        {
            var fileEntry = await _fileEntryRepository.GetFileById(id);

            return await filesystem.Get(fileEntry.Path);
        }

        [HttpPost]
        public async Task<ActionResult<FileEntryDto>> Upload(
            [FromForm(Name = "file")] IFormFile formFile,
            [FromServices] IFilesystem filesystem)
        {
            try
            {
               
                var target = $"{formFile.FileName}";

                await filesystem.Move(formFile, target);

                var fileEntry = new FileEntry();
                fileEntry.Filename = formFile.FileName;
                fileEntry.MediaType = formFile.ContentType;
                fileEntry.Length = formFile.Length;
                fileEntry.Path = target;

                await _fileEntryRepository.Create(fileEntry);

                var dto = _mapper.Map<FileEntryDto>(fileEntry);

                return dto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
