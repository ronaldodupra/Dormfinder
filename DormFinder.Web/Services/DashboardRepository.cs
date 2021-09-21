using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class DashboardRepository:Repository,IDashboardRepository
    {
        public DashboardRepository(DormFinderContext context):base(context)
        {

        }
        public async Task<IEnumerable<Building>> RoomChart(int orgId)
        {
            return await _context.Buildings
                .Include(x=>x.Rooms)
                    .ThenInclude(x=>x.Bedspaces)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Floor)
                .Include(x=>x.Floors)
                    .ThenInclude(x => x.Rooms).
                        ThenInclude(x => x.Bedspaces)
                .Where(x => x.OrganizationId == orgId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Building>> RoomChartFilter(string search, int orgId)
        {
            return await _context.Buildings
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Bedspaces)      
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Floor)
                .Include(x => x.Floors)
                    .ThenInclude(x => x.Rooms).
                        ThenInclude(x => x.Bedspaces)
                .Where(x=>x.Name.Contains(search))
                .Where(x => x.OrganizationId == orgId)
                .ToListAsync();
        }
    }
}
