using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class OptionsRepository : Repository, IOptionsRepository
    {
        public OptionsRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task<ICollection<City>> GetCities()
        {
            return await _context.Cities.OrderBy(t => t.Description).ToListAsync();
        }

        public async Task<ICollection<Province>> GetProvinces()
        {
            return await _context.Provinces.OrderBy(t => t.Description).ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAddress()
        {
            return await _context.Buildings.
                Join(_context.Address, building => building.AddressId, address => address.Id,
                (building, address) => new { address }).Select(x => x.address).ToListAsync();
        }
    }
}
