using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IPropertyRepository
    {
        Task<Room> GetProperty(int id);
        Task<IEnumerable<Building>> SearchProperty(string location);
        Task<IEnumerable<Building>> SimilarProperties(int id);
    }
}
