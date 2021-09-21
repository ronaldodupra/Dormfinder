using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class BuildingAmenity : BaseEntity
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int BuildingId { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
