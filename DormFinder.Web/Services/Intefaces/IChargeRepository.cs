using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IChargeRepository
    {
        Task<PaginatedList<Charge>> GetCharges(PageOptions options, int orgId);

        Task<IEnumerable<Charge>> GetChargesByCompany(string _companyId);

        Task<IEnumerable<Charge>> GetChargesByContract();

        Task<Charge> GetById(int _id);

        Task Create(Charge _charge);

        Task<bool> UpdateCharge(int _id, Charge _charge);

        Task RemoveCharge(string _id);

        Task ChangeOrder(List<ChargeOrder> _chargeOrders);
        Task SaveChanges();
    }
}
