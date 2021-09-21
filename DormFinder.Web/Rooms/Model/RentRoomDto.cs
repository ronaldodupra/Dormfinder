using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Buildings.Models;

namespace DormFinder.Web.Rooms.Model
{
    public class RentRoomDto
    {
        public int Id { get; set; }
        public decimal BasicRent { get; set; }
        
        public string RoomName { get; set; }
        public ICollection<RoomPicDto> RoomPics { get; set; }
        public RentBuildingDto Building { get; set; }
        public class RentBuildingDto
        {
            public int Id { get; set; }
            public RentAddressDto Address { get; set; }
            public class RentAddressDto
            {
                public string City { get; set; }
                public string Province { get; set; }
            }
        }
        public class RoomPicDto
        {
            public bool isThumbnail { get; set; }
            public int FileEntryId { get; set; }
        }




    }
}
