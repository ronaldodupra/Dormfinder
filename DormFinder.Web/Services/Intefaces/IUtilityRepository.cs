using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IUtilityRepository
    {
        Task<IEnumerable<UtilityReading>> GetReadingsCurrAndPrevMonth(int utilityId);
        Task CreateReading(UtilityReading utilityReadings);
        Task UpdateReading(UtilityReading utilityReadings);
        Task<PaginatedList<Utility>> GetUtilities(PageOptions pageOptions, int orgId, int utilityType);
    }
}
