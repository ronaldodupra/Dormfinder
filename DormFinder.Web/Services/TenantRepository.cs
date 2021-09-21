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
    public class TenantRepository : Repository, ITenantRepository
    {
        public TenantRepository(DormFinderContext context)
            : base(context)
        {
        }

        public async Task Create(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task<Tenant> GetById(int id)
        {
            return await _context.Tenants
                .Include(t => t.User)
                .Include(t => t.Contract.Room.Building)
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<PaginatedList<Tenant>> List(PageOptions options, int orgId)
        {
            var query = _context.Tenants
                .Include(t => t.User)
                .Include(t => t.Room)
                .Where(t => t.OrganizationId == orgId);

            var total = await query.CountAsync();
            var tenants = await query.Page(options).ToListAsync();

            return new PaginatedList<Tenant>(tenants, total);
        }

        public async Task<IEnumerable<Tenant>> ListByRoom(int id)
        {
            return await _context.Tenants.Include(x => x.User).Include(x => x.Contract)
                .Where(t => t.RoomId == id)
                .ToListAsync();
        }
    }
}
