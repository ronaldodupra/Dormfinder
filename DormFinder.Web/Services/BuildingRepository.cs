using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class BuildingRepository : Repository, IBuildingRepository
    {
        public BuildingRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task Create(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
        }

        public async Task<Building> GetById(int id)
        {
            return await _context.Buildings
                .Include(t => t.Address)
                .Include(t => t.BuildingNearbyPlaces)
                .Include(t => t.BuildingType)
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<Building>> List(PageOptions options, int orgId)
        {
            var query = _context.Buildings
                .Include(t => t.Address)
                .Include(t => t.Floors)
                .Where(t => t.IsActive)
                .Where(t => t.OrganizationId == orgId)
                .AsQueryable();

            query = options.Sort switch
            {
                "name" => query.OrderBy(t => t.Name, options.Direction),
                "address" => query.OrderBy(t => t.Address.City, options.Direction),
                _ => query
            };

            var buildings = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<Building>(buildings, total);
        }

        public Task RemoveBuilding(string _id)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<BuildingType>> TypeList()
        {
            var list = await _context.BuildingTypes.ToListAsync();
            return list;
        }

        public async Task RemoveNearByPlace(int id)
        {
            var nearbyPlace = _context.BuildingNearbyPlace.Where(x => x.BuildingId == id).ToList();
            _context.BuildingNearbyPlace.RemoveRange(nearbyPlace);
            _context.SaveChanges();
        }

    }
}
