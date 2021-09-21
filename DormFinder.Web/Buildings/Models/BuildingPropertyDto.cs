using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DormFinder.Web.Buildings.Models.BuildingDto;

namespace DormFinder.Web.Buildings.Models
{
    public class BuildingPropertyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BuildingTypeDto buildingType { get; set; }
        public string NearBySchool { get; set; }
        public string Location { get; set; }
        public PropertAddressDto Address { get; set; }
        public ICollection<RoomDto> Rooms { get; set; }
        public class RoomDto {
            public int id { get; set; }
            public string RoomName { get; set; }
            public decimal BasicRent { get; set; }

            public ICollection<RoomPicDto> RoomPics { get; set; }
            public class RoomPicDto
            {
                public int FileEntryId { get; set; }
            }

        }

        public class PropertAddressDto
        {
            public string province { get; set; }
            public string city { get; set; }
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }
       
        public class BuildingTypeDto
        {
            public string Name { get; set; }
        }
    }
}
