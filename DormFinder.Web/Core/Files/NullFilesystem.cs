using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DormFinder.Web.Core.Files
{
    public class NullFilesystem : IFilesystem
    {
        public Task<Stream> Get(string location)
        {
            return Task.FromResult(Stream.Null);
        }

        public Task<string> Move(IFormFile file, string destFile)
        {
            return Task.FromResult(destFile);
        }

        public Task<string> Move(Stream stream, string destFile)
        {
            return Task.FromResult(destFile);
        }

        public Task Remove(string location)
        {
            return Task.CompletedTask;
        }
    }
}
