using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Extensions;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class RoomRepository : Repository, IRoomRepository
    {
        public RoomRepository(DormFinderContext context)
            : base(context)
        {
        }

        public async Task Create(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        public Task<Utility> AddUtilities(string _id, Utility _utility)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Room> GetByContract(string _contractId)
        {
            throw new System.NotImplementedException();
            //var roomId = _context.Contracts.Find(contract => contract.InternalId == ObjectId.Parse(_contractId)).FirstOrDefault().Unit.internalId;
            //var filter = Builders<Room>.Filter.Eq(room => room.InternalId, ObjectId.Parse(roomId));
            //return await _context.Rooms.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Room> GetRoom(int _id)
        {
            return await _context.Room
                .Include(t => t.Building)
                .Include(t => t.RoomType)
                .Include(x => x.RoomInclusion)
                    .ThenInclude(e => e.Inclusion)
                .Include(x => x.RoomPics)
                    .ThenInclude(x => x.FileEntry)
                .Where(t => t.Id == _id)
                .FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<Room>> GetRooms(PageOptions options, int orgId)
        {
            var query = _context.Room
                .Include(x => x.RoomType).Include(x => x.Building)
                .Include(x => x.RoomInclusion).ThenInclude(e => e.Inclusion)
                .Include(x => x.RoomPics).ThenInclude(t => t.FileEntry)
                .Where(x => x.OrganizationId == orgId)
                .AsQueryable();

            query = options.Sort switch
            {
                "name" => query.OrderBy(t => t.RoomName, options.Direction),
                "description" => query.OrderBy(t => t.Description, options.Direction),
                "price" => query.OrderBy(t => t.BasicRent, options.Direction),
                "inclusion" => query.OrderBy(t => t.RoomInclusion.First().Inclusion.InclusionName, options.Direction),
                "roomType" => query.OrderBy(t => t.RoomType.RoomTypeName, options.Direction),
                _ => query
            };

            var rooms = await query
                .Page(options)
                .ToListAsync();

            var total = await query.CountAsync();

            return new PaginatedList<Room>(rooms, total);
        }

        public async Task<IEnumerable<Room>> GetRoomList(int orgId)
        {
            return await _context.Room.Include(r => r.Building)
                .Where(r => r.IsActive == true)
                .Where(r => r.OrganizationId == orgId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Room>> RoomToRentList()
        {
            var Rent = _context.Room.Include(x => x.RoomPics).Include(x => x.Building).ThenInclude(e => e.Address).ToList();
            return Rent;
        }

        public async Task<IEnumerable<Room>> SearchRent(string location, int minPrice, int maxPrice)
        {
            var Rent = _context.Room.Include(x => x.RoomPics).Include(x => x.Building).ThenInclude(e => e.Address);
            List<Room> search;
            if (maxPrice == 0 && location == "null")
            {
                search = Rent.Where(x => x.BasicRent >= minPrice).ToList();
            } else if (maxPrice==0 && location !="null") {

                search = Rent.Where(x => x.BasicRent >= minPrice &&
                   (x.Building.Address.Province + " " + x.Building.Address.City).Contains(location)).ToList();

            } else if (location == "null" && maxPrice != 0)
            {
                search = Rent.Where(x => x.BasicRent <= maxPrice && x.BasicRent >= minPrice).ToList();
            }
            else
            {
                search = Rent.Where(x => x.BasicRent <= maxPrice && x.BasicRent >= minPrice &&
                (x.Building.Address.Province + " " + x.Building.Address.City).Contains(location)).ToList();
            }
            return search;
        }

        public async Task<IEnumerable<Room>> GetRoomsByFloors(string _buildingId, string _floorId)
        {
            throw new System.NotImplementedException();
            //var filter = Builders<Building>.Filter.Eq(building => building.InternalId, ObjectId.Parse(_buildingId));
            ////Get Current Floors
            //var selectedFloor = _context.Buildings.
            //Find(filter).FirstOrDefault().
            //Floors.Where(floor => floor.InternalId == ObjectId.Parse(_floorId)).FirstOrDefault();
            //var selectedRooms = Builders<Room>.Filter.And(Builders<Room>.Filter.In(room => room.InternalId, selectedFloor.RoomIds),
            //Builders<Room>.Filter.Eq(room => room.IsActive, true));
            //return await _context.Rooms.Find(selectedRooms).ToListAsync();
        }

        public Task RemoveRoom(string _id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUtility(string _id, string _utilityId, Utility _utility)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        //Update Water Meter and Electricty Meter
    }
}
