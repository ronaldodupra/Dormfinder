using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Entities;
using DormFinder.Web.Rooms.Models;
using static DormFinder.Web.Rooms.Model.RoomDto;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IRoomInclusionRepository
    {
        Task CreateInclusion(int Id, int roomId);
        Task<IEnumerable<RoomInclusion>> GetRoomInclusion(int id);
        Task RemoveInclusion(int _id);
    }
}
