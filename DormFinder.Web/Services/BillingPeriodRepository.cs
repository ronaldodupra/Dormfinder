using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using DormFinder.Web.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class BillingPeriodRepository:Repository,IBillingPeriodRepository
    {
        public BillingPeriodRepository(DormFinderContext context) : base(context)
        {

        }
        public async Task Create(BillingPeriod billingPeriod)
        {
            _context.BillingPeriod.Add(billingPeriod);
            await _context.SaveChangesAsync();
        }
        public async Task<BillingPeriod> GetById(int Id)
        {
            return _context.BillingPeriod.Find(Id);
        }
        public async Task<PaginatedList<BillingPeriod>> List(PageOptions options,int Id)
        {
            var query = _context.BillingPeriod.Where(x=>x.OrganizationId==Id).AsQueryable();
              
            query = options.Sort switch
            {
                "billingMonth" => query.OrderBy(t => t.BillingMonth.ToString(), options.Direction),
                "beginDate" => query.OrderBy(t => t.BeginDate.ToString(), options.Direction),
                "endDate" => query.OrderBy(t => t.EndDate.ToString(), options.Direction),
                _ => query
            };

            var buildings = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<BillingPeriod>(buildings, total);
        }
        public async Task Update(BillingPeriod billingPeriod,int Id)
        {
            var update = _context.BillingPeriod.Find(Id);
            update.BeginDate = billingPeriod.BeginDate;
            update.EndDate = billingPeriod.EndDate;
            update.BillingMonth = billingPeriod.BillingMonth;
            
            await _context.SaveChangesAsync();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
