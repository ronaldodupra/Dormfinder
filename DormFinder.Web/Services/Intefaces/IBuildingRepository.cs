using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services
{
    public interface IBuildingRepository
    {
        Task<PaginatedList<Building>> List(PageOptions options, int orgId);

        Task<List<BuildingType>> TypeList();

        Task<Building> GetById(int id);

        Task Create(Building building);

        Task RemoveBuilding(string _id);

        Task RemoveNearByPlace(int _id);

        [Obsolete("Replace this with UOW pattern")]
        Task SaveChanges();

    }
}
