using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<Building>> RoomChart(int orgId);
        Task<IEnumerable<Building>> RoomChartFilter(string _search, int orgId);
    }
}
