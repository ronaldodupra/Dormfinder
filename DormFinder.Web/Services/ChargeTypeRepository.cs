using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Data;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services
{
    public class ChargeTypeRepository : Repository, IChargeTypeRepository
    {
        public ChargeTypeRepository(DormFinderContext context) : base(context)
        {

        }
        public async Task<PaginatedList<ChargeType>> GetChargeTypes(PageOptions options)
        {
            var query = _context.ChargeTypes
                .AsQueryable();


            var chargeTypes = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<ChargeType>(chargeTypes, total);
        }
    }
}
