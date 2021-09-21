using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface ILeadRepository
    {
        Task<Lead> GetById(int id);

        Task Create(Lead lead);

        Task<PaginatedList<Lead>> List(PageOptions options, int orgId);


        Task<PaginatedList<Lead>> ListByUser(PageOptions options, int user);
    }
}
