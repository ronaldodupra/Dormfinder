using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DormFinder.Web.Entities
{
    public class Room : BaseEntity
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string RoomName { get; set; }

        public decimal? Area { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public int BedSpaceIds { get; set; }

        public int? FloorId { get; set; }

        public bool IsActive { get; set; }

        public int BuildingId { get; set; }

        public string RoomNumber { get; set; }

        public decimal? BasicRent { get; set; }

        public decimal SecurityDeposit { get; set; }

        public int AdvanceRent { get; set; }

        public int Occupant { get; set; }

        public RoomType RoomType { get; set; }

        public Building Building { get; set; }

        public Floor Floor { get; set; }

        public ICollection<RoomInclusion> RoomInclusion { get; set; }

        public ICollection<RoomPic> RoomPics { get; set; }

        public ICollection<Bedspace> Bedspaces { get; set; }

        public Room()
        {
            IsActive = true;
            RoomInclusion = new Collection<RoomInclusion>();
            RoomPics = new Collection<RoomPic>();
            Bedspaces = new Collection<Bedspace>();
        }

        public void AddInclusion(int inclusionId)
        {
            var inclusion = new RoomInclusion();
            inclusion.InclusionId = inclusionId;
            inclusion.roomId = Id;

            RoomInclusion.Add(inclusion);
        }

        public void AddRoomPic(int fileEntryId)
        {
            var roomPic = new RoomPic();
            roomPic.RoomId = Id;
            roomPic.FileEntryId = fileEntryId;

            RoomPics.Add(roomPic);
        }

        public void addRoomPicAsThumbnail(int fileEntryId)
        {
            var roomPic = new RoomPic();
            roomPic.RoomId = Id;
            roomPic.FileEntryId = fileEntryId;
            roomPic.isThumbnail = true;

            RoomPics.Add(roomPic);
        }
    }
}
