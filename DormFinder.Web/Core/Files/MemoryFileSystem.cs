using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DormFinder.Web.Core.Files
{
    /// <summary>
    /// This is only for testing. Do not use in production.
    /// </summary>
    public class MemoryFileSystem : IFilesystem
    {
        private readonly Dictionary<string, Stream> _files;

        public MemoryFileSystem()
        {
            _files = new Dictionary<string, Stream>();
        }

        public Task<Stream> Get(string location)
        {
            return Task.FromResult(_files[location]);
        }

        public async Task<string> Move(IFormFile file, string target)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            _files[target] = memoryStream;

            return target;
        }

        public async Task<string> Move(Stream stream, string target)
        {
            var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            _files[target] = memoryStream;

            return target;
        }

        public Task Remove(string location)
        {
            _files.Remove(location);

            return Task.CompletedTask;
        }
    }
}
