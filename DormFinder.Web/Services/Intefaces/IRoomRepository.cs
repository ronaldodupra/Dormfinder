using System.Collections.Generic;
using System.Threading.Tasks;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Rooms.Models;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using static DormFinder.Web.Services.RoomRepository;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IRoomRepository
    {
        Task<PaginatedList<Room>> GetRooms(PageOptions options, int orgId);
        Task<IEnumerable<Room>> GetRoomList(int orgId);
        Task<IEnumerable<Room>> GetRoomsByFloors(string buildingId, string _floorId);
        Task<IEnumerable<Room>> RoomToRentList();
        Task<IEnumerable<Room>> SearchRent(string _location,int _minPrice,int maxPrice);
        Task<Room> GetByContract(string _contractId);
        Task<Room> GetRoom(int _id);
        Task Create(Room _room);
        Task RemoveRoom(string _id);
        Task<Utility> AddUtilities(string _id, Utility _utility);
        Task<bool> UpdateUtility(string _id, string _utilityId, Utility _utility);
        Task SaveChanges();
    }
}
