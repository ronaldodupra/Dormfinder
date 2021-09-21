using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IOrganizationRepository
    {
        Task<Organization> CreateOrganizationAsync(Organization organization);

        Task<UserOrganization> CreateUserOrganizationAsync(UserOrganization userOrganization);
    }
}
