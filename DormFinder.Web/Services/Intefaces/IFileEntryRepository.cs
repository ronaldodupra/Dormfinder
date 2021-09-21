using System.Threading.Tasks;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IFileEntryRepository
    {
        Task<FileEntry> GetFileById(int id);

        Task Create(FileEntry fileEntry);
    }
}
