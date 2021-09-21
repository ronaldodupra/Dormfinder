using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IChargeTypeRepository
    {
        Task<PaginatedList<ChargeType>> GetChargeTypes(PageOptions options);
    }
}
