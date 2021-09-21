using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class RoomTypeRepository : Repository, IRoomTypeRepository
    {
        public RoomTypeRepository(DormFinderContext context) : base(context)
        {
        }
        public async Task<IEnumerable<RoomType>> GetRoomType()
        {
            return await _context.RoomTypes.ToListAsync();
        }
        
    }
}
