using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Rooms.Model
{
    public class RoomPropertyDto
    {
        public string RoomName { get; set; }
        public string Description { get; set; }
        public decimal BasicRent { get; set; }
        public decimal Area { get; set; }
        public string RoomNumber { get; set; }
        public ICollection<RoomInclusionDto> RoomInclusion { get; set; }
        public class RoomInclusionDto
        {
            public InclusionDto Inclusion { get; set; }
            public class InclusionDto { 
                public string InclusionName { get; set; }
            }
        }
        public RoomTypeDto RoomType { get; set; }
        public class RoomTypeDto
        {
            public string RoomTypeName { get; set; }
        }
        public BuildingDto Building{ get; set; } 
        public class BuildingDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string NearBySchool { get; set; }
            public PropertAddressDto Address { get; set; }
            public ICollection<BuildingAmenitiesDto> BuildingAmenities { get; set; }
            public class BuildingAmenitiesDto
            {
                public AmenityDto Amenity { get; set; }
                public class AmenityDto
                {
                    public string Description { get; set; }
                }
            }
            public ICollection<BuildingPicDto> BuildingPics { get; set; }
            public class BuildingPicDto { 
                public int FileEntryId { get; set; }
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
            
        }
        public ICollection<RoomPicDto> RoomPics { get; set; }
        public class RoomPicDto
        {
            public int fileEntryId { get; set; }
            public bool isThumbnail { get; set; }
        } 
    }
}
