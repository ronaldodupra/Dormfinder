using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services
{
    public interface IOptionsRepository
    {
        Task<ICollection<City>> GetCities();

        Task<ICollection<Province>> GetProvinces();

        Task<IEnumerable<Address>> GetAddress();
    }
}
