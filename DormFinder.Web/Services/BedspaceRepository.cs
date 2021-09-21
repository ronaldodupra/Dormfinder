using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DormFinder.Web.Services
{
    public class BedspaceRepository : Repository, IBedspaceRepository
    {
        public BedspaceRepository(DormFinderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Bedspace>> GetAll()
        {
            throw new System.NotImplementedException();
            //return await _context.Bedspaces.Find(bedspace => bedspace.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Bedspace>> GetAllByRoom(int _roomId)
        {
            return await _context.Bedspaces.Where(c => c.RoomId == _roomId).ToListAsync();       
        }

        public async Task AddBedspace(int roomType,int _roomId)
        {   
            var bedspaceType=_context.RoomTypes.Find(roomType);
            for (int i = 1; i <= bedspaceType.AllowedPerson; i++)
            {
                var bedspace = new Bedspace()
                {
                    RoomId = _roomId,
                    Description = "Bedspace " +i,
                };
                _context.Bedspaces.Add(bedspace);
                _context.SaveChanges();
            }
        }

        public async Task<Bedspace> UpdateBedspace(int _id, Bedspace _bedspace)
        {
            var bedspace = _context.Bedspaces.Find(_id);
            bedspace.Description = _bedspace.Description;
            _context.SaveChanges();
            return bedspace;
        }

        public async Task RemoveBedspace(int _id)
        {
            var removeBedspace = _context.Bedspaces.Where(x => x.RoomId == _id).ToList();
            _context.Bedspaces.RemoveRange(removeBedspace);
            _context.SaveChanges();
        }

        public async Task<Bedspace> Get(string _id)
        {
            throw new System.NotImplementedException();
            //return await _context.Bedspaces.Find(bedspace => bedspace.InternalId == ObjectId.Parse(_id) && bedspace.IsActive)
            //.FirstOrDefaultAsync();
        }

        public async Task<Bedspace> GetByContract(string _contractId)
        {
            throw new System.NotImplementedException();
            //var bedspaceId = _context.Contracts.Find(contract => contract.InternalId == ObjectId.Parse(_contractId)).FirstOrDefault().Bedspace.internalId;
            //var filter = Builders<Bedspace>.Filter.Eq(bedspace => bedspace.InternalId, ObjectId.Parse(bedspaceId));
            //return await _context.Bedspaces.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Bedspace>> GetAllAvailable(string _roomId)
        {
            throw new System.NotImplementedException();
            //var selectedRoom = await _context.Rooms.Find(room => room.InternalId == ObjectId.Parse(_roomId))
            //.FirstOrDefaultAsync();
            //var filteredBedspaces = Builders<Bedspace>.Filter.And(Builders<Bedspace>.Filter.In(bedspace => bedspace.InternalId, selectedRoom.BedspaceIds),
            //Builders<Bedspace>.Filter.Eq(bedspace => bedspace.IsActive, true), Builders<Bedspace>.Filter.Eq(bedspace => bedspace.Status, "available"));
            //return await _context.Bedspaces.Find(filteredBedspaces).ToListAsync();
        }

        public async Task<IEnumerable<Bedspace>> GetAllForUpdate(string _roomId, string _bedspaceId)
        {
            throw new System.NotImplementedException();
            //var selectedRoom = await _context.Rooms.Find(room => room.InternalId == ObjectId.Parse(_roomId))
            //.FirstOrDefaultAsync();
            //var filteredBedspaces = Builders<Bedspace>.Filter.And(Builders<Bedspace>.Filter.In(bedspace => bedspace.InternalId, selectedRoom.BedspaceIds),
            //Builders<Bedspace>.Filter.Eq(bedspace => bedspace.IsActive, true),
            //Builders<Bedspace>.Filter.Or(Builders<Bedspace>.Filter.Eq(bedspace => bedspace.Status, "available"), Builders<Bedspace>.Filter.Eq(bedspace => bedspace.InternalId, ObjectId.Parse(_bedspaceId)))
            //);
            //return await _context.Bedspaces.Find(filteredBedspaces).ToListAsync();
        }
        public async Task<Bedspace> UpdateBedStatus(int bedId,bool status)
        {
            var updateStatus = _context.Bedspaces.Find(bedId);
            updateStatus.IsActive = status;
            _context.SaveChanges();
            return updateStatus;
        }
        public async Task UpdateBedspaceStatus(int _id, int _status)
        {
            var updateStatus = _context.Bedspaces.Find(_id);
            updateStatus.Status = _status;
            _context.SaveChanges();
        }
    }
}
