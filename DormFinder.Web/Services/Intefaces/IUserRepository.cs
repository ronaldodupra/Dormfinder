using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Entities.Identity;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);

        Task<ICollection<User>> GetAllByOrganization(int organizationId);

        Task SaveChanges();
    }
}
