using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;

namespace DormFinder.Web.Services
{
    public class FileEntryRepository : Repository, IFileEntryRepository
    {
        public FileEntryRepository(DormFinderContext context)
            : base(context)
        {
        }

        public async Task Create(FileEntry fileEntry)
        {
            _context.FileEntries.Add(fileEntry);
            await _context.SaveChangesAsync();
        }

        public async Task<FileEntry> GetFileById(int id)
        {
            return await _context.FileEntries.FindAsync(id);
        }
    }
}
