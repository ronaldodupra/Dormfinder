using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IBillingPeriodRepository
    {
        Task Create(BillingPeriod _billingPeriod);
        Task<BillingPeriod> GetById(int _Id);
        Task<PaginatedList<BillingPeriod>> List(PageOptions _pageOptions,int _id);
        Task Update(BillingPeriod _billingPeriod, int _id);
        Task SaveChanges();
    }
}
