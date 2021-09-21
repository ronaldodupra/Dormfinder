using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Rooms.Models;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;
using static DormFinder.Web.Rooms.Model.RoomDto;

namespace DormFinder.Web.Services
{
    public class RoomInclusionRepository:Repository, IRoomInclusionRepository
    {
        public RoomInclusionRepository(DormFinderContext context) : base(context)
        {

        }
        public async Task CreateInclusion(int id, int roomId)
        {
            var roomInclusion = new RoomInclusion
            {
                InclusionId = id,
                roomId = roomId,

            };
            _context.RoomInclusions.Add(roomInclusion);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<RoomInclusion>> GetRoomInclusion(int id)
        {
            var roomInclusion = _context.RoomInclusions.Include(x => x.Inclusion).Where(x=>x.roomId==id).ToList();

            return roomInclusion;
        }
        public async Task RemoveInclusion(int _id)
        {
            var roomInclusion = _context.RoomInclusions.Where(x => x.roomId == _id).ToList();
            _context.RoomInclusions.RemoveRange(roomInclusion);
            _context.SaveChanges();
        }
    }
}
