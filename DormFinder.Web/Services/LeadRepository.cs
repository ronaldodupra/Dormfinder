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
    public class LeadRepository : Repository, ILeadRepository
    {
        public LeadRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task Create(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
        }

        public async Task<Lead> GetById(int id)
        {
            return await _context.Leads
                .Include(x=>x.Contract)
                    .ThenInclude(x => x.ContractCharge)
                        .ThenInclude(x => x.Charge)
                .Include(x=>x.Room)
                    .ThenInclude(x => x.Building)
                        .ThenInclude(x=>x.Address)
                .Include(x=>x.Room).ThenInclude(x=>x.RoomPics).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<PaginatedList<Lead>> List(PageOptions options, int orgId)
        {
            var query = _context.Leads.Include(x=>x.User).Include(x => x.Contract).Include(q => q.Room)
                .ThenInclude(x=>x.Building)
                .ThenInclude(x=>x.Address)
                .Where(x => x.OrganizationId == orgId)
                .AsQueryable();

            query = options.Sort switch
            {
                "received" => query.OrderBy(t => t.CreatedAt, options.Direction),
                "from" => query.OrderBy(t => t.FirstName + t.LastName, options.Direction),
                "property" => query.OrderBy(t => t.Room.Building.Address.AddressLine1 + t.Room.Building.Address.AddressLine2 + t.Room.Building.Address.City + t.Room.Building.Address.Province, options.Direction),
                "number" => query.OrderBy(t => t.Number, options.Direction),
                "status" => query.OrderBy(t => t.Status, options.Direction),
                _ => query
            };

            var leads = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<Lead>(leads, total);
        }

        public async Task<PaginatedList<Lead>> ListByUser(PageOptions options, int userId)
        {
            var query = _context.Leads.Include(x => x.User).Include(x => x.Contract).Include(q => q.Room)
               .ThenInclude(x => x.Building)
               .ThenInclude(x => x.Address)
               .Where(x => x.UserId == userId)
               .AsQueryable();

            query = options.Sort switch
            {
                "sent" => query.OrderBy(t => t.CreatedAt, options.Direction),
                "property" => query.OrderBy(t => t.Room.Building.Address.AddressLine1 + t.Room.Building.Address.AddressLine2 + t.Room.Building.Address.City + t.Room.Building.Address.Province, options.Direction),
                "status" => query.OrderBy(t => t.Status, options.Direction),
                _ => query
            };

            var leads = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<Lead>(leads, total);
        }
    }
}
