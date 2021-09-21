using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Rooms.Model;

namespace DormFinder.Web.Rooms.Models
{
    public class CreateRoomDto
    {
       
        public string RoomName { get; set; }
        public decimal? Area { get; set; }
        public string Description { get; set; }
        public string RoomNumber { get; set; }
        public decimal? BasicRent { get; set; }
        public IEnumerable<int> RoomInclusions { get; set; }
        public ICollection<FileEntryDto> FileEntries { get; set; }
        public int BuildingId { get; set; }
        public int type { get; set; }
        public int? floorId { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public int? AdvanceRent { get; set; }
        public int? Occupant { get; set; }
        public class FileEntryDto
        {
            public int Id { get; set; }

            public string Filename { get; set; }

            public int Length { get; set; }

            public string MediaType { get; set; }
        }

    }
}
