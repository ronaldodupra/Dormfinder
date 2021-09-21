using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DormFinder.Web.Buildings.Models
{
    public class UpdateBuildingDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string BuildingType { get; set; }

        public ICollection<string> Amenities { get; set; }

        public ICollection<string> NearByEntries { get; set; }

        public ICollection<int> FloorEntries { get; set; }

        [Required]
        public AddressDto Address { get; set; }

        public class AddressDto
        {
            public string Province { get; set; }

            public string City { get; set; }

            public string AddressLine1 { get; set; }

            public string AddressLine2 { get; set; }

            public decimal? Latitude { get; set; }

            public decimal? Longitude { get; set; }
        }
    }
}
