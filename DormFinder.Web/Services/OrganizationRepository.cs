using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class OrganizationRepository : Repository, IOrganizationRepository
    {
        public OrganizationRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task<Organization> CreateOrganizationAsync(Organization organization)
        {
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return organization;
        }

        public async Task<UserOrganization> CreateUserOrganizationAsync(UserOrganization userOrganization)
        {
            _context.UserOrganizations.Add(userOrganization);
            await _context.SaveChangesAsync();

            return userOrganization;
        }
    }
}
