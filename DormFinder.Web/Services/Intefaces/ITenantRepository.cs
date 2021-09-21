using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface ITenantRepository
    {
        Task<Tenant> GetById(int id);

        Task Create(Tenant tenant);

        Task<PaginatedList<Tenant>> List(PageOptions options, int orgId);

        Task<IEnumerable<Tenant>> ListByRoom(int Id);
    }
}
