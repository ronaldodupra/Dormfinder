using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services
{
    public interface IBedspaceRepository
    {
        Task<IEnumerable<Bedspace>> GetAll();

        Task<IEnumerable<Bedspace>> GetAllByRoom(int _roomId);

        Task<IEnumerable<Bedspace>> GetAllForUpdate(string _roomId, string _bedspaceId);

        Task<IEnumerable<Bedspace>> GetAllAvailable(string _roomId);

        Task<Bedspace> Get(string _id);

        Task<Bedspace> GetByContract(string _contractId);

        Task<Bedspace> UpdateBedspace(int _id, Bedspace _bedspace);

        Task AddBedspace(int _roomType,int _roomId);

        Task RemoveBedspace(int _id);

        Task<Bedspace> UpdateBedStatus(int _id, bool _status);

        Task UpdateBedspaceStatus(int _id, int _status);

    }
}
