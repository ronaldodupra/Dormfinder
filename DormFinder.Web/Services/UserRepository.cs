using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
                .Include(u => u.Address)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<User>> GetAllByOrganization(int organizationId)
        {
            var userOrganizations = await _context.UserOrganizations
                .Where(t => t.OrganizationId == organizationId)
                .ToListAsync();

            var userOrganizationIds = userOrganizations.Select(t => t.UserId);

            return await _context.Users
                .Include(u => u.Address)
                .Where(u => userOrganizationIds.Contains(u.Id))
                .ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
