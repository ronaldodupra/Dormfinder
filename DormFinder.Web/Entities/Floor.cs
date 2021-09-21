using System.Collections.Generic;

namespace DormFinder.Web.Entities
{
    public class Floor
    {
        public int Id { get; private set; }
        public int OrganizationId { get; set; }
        public int BuildingId { get; set; }
        public string Description { get; set; }
        public ICollection<Room> Rooms { get; set; }

        //public List<ObjectId> RoomIds { get; set; } = new List<ObjectId>();
    }
}
