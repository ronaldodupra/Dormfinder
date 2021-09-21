using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class RoomPic : BaseEntity
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int RoomId { get; set; }
        public int FileEntryId { get; set; } 
        public string Description { get; set; }
        public bool Viewable { get; set; }
        public bool isThumbnail { get; set; }
        public RoomPic(){
            isThumbnail = false;
            Viewable = true;
        }
        public FileEntry FileEntry { get; set; }
       
    }
}
