using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class UtilityRepository : Repository, IUtilityRepository
    {
        public UtilityRepository(DormFinderContext context) : base(context)
        {

        }

        public async Task CreateReading(UtilityReading utility)
        {
            _context.UtilityReadings.Add(utility);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<Utility>> GetUtilities(PageOptions options, int orgId, int utilityType)
        {
            var query = _context.Utilities.
                Where(u => u.OrganizationId == orgId).
                Where(u => u.UtilityTypeId == utilityType).
                AsQueryable();

            var meters = await query.Page(options).ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<Utility>(meters, total);
        }

        public async Task<IEnumerable<UtilityReading>> GetReadingsCurrAndPrevMonth(int utilityId)
        {
            return await _context.UtilityReadings.
                Where(u => u.UtilityId == utilityId).
                Where(u => (u.CreatedAt.Month >= DateTime.Now.Month - 1 && u.CreatedAt.Year >= DateTime.Now.Year) ||
                        (u.CreatedAt.Month == 12 && DateTime.Now.Month == 1 && u.CreatedAt.Year == DateTime.Now.AddYears(-1).Year)).
                ToListAsync();
        }

        public async Task UpdateReading(UtilityReading utilityReading)
        {
            _context.UtilityReadings.Attach(utilityReading);
            _context.Entry(utilityReading).Property(x => x.Reading).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
