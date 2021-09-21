using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Data;
using DormFinder.Web.Services.Intefaces;

namespace DormFinder.Web.Services
{
    public class RoomPicRepository:Repository,IRoomPicRepository
    {
        private readonly IFilesystem _filesystem;
        public RoomPicRepository(DormFinderContext context, IFilesystem filesystem)
            : base(context)
        {
            _filesystem = filesystem;
        }
        public async Task Remove(int id)
        {
           var roomPic= _context.RoomPics.Where(x => x.FileEntryId == id).FirstOrDefault();
           var file = _context.FileEntries.Find(id);
            _context.Remove(file);
            _context.Remove(roomPic);
            _context.SaveChanges();

            _filesystem.Remove(file.Filename);
        }
        public async Task SetUpThumbNail(int _roomId, int fileEntryId)
        {
            var removeThumbnail = _context.RoomPics.Where(c => c.RoomId == _roomId).ToList();
            removeThumbnail.ForEach(x => x.isThumbnail = false);
            _context.SaveChanges();


            var update = _context.RoomPics.Where(x => x.FileEntryId == fileEntryId).FirstOrDefault();
            update.isThumbnail = true;
            _context.SaveChanges();
        }
    }
}
