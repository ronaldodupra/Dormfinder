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
    public class PropertyRepository : Repository, IPropertyRepository
    {
        public PropertyRepository(DormFinderContext context) : base(context)
        {

        }
        public async Task<Room> GetProperty(int _id)
        {
            return await _context.Room
                .Include(x=>x.RoomInclusion)
                    .ThenInclude(x=>x.Inclusion)
                .Include(x=>x.RoomType)
                .Include(x=>x.RoomPics)
                .Include(g=>g.Building)
                    .ThenInclude(x => x.Address)
                .Include(x=>x.Building)
                    .ThenInclude(x=>x.BuildingPics)
                .Include(x=>x.Building)
                    .ThenInclude(x=>x.BuildingAmenities)
                        .ThenInclude(x=>x.Amenity)
                .Where(c => c.Id == _id).FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<Building>> SimilarProperties(int id) {
            return await _context.Buildings.Include(x => x.Address).ToListAsync();
        }
        public async Task<IEnumerable<Building>> SearchProperty(string location)
        {
            return await _context.Buildings.Include(x=>x.Rooms).ThenInclude(x=>x.RoomPics)
                .Include(x => x.Address).Include(x => x.BuildingType).Include(x => x.BuildingPics)
                .Where(c =>(c.Address.Province+" "+c.Address.City).Contains(location)).ToListAsync();
        }
    }
}
