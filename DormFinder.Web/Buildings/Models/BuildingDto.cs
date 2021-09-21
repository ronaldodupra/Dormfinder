using System.Collections.Generic;

namespace DormFinder.Web.Buildings.Models
{
    public class BuildingDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AddressDto Address { get; set; }

        public string BuildingType { get; set; }
        public ICollection<FloorDto> Floors { get; set; }
        public ICollection<NearByPlacesDto> BuildingNearbyPlaces { get; set; }
        public class FloorDto
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
        public class AddressDto
        {
            public string Province { get; set; }

            public string City { get; set; }

            public string AddressLine1 { get; set; }

            public string AddressLine2 { get; set; }

            public decimal? Latitude { get; set; }

            public decimal? Longitude { get; set; }
        }
        public class NearByPlacesDto
        {
            public string Place { get; set; }
        }
    }
}
