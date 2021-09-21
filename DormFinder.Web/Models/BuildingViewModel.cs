using System.Collections.Generic;

namespace DormFinder.Web.Models
{
    public class BuildingViewModel
    {
        public string Id { get; set; }

        public string Address { get; set; }

        public string[] NearBySchools { get; set; }

        public string[] Amenities { get; set; }

        public string Description { get; set; }

        public string[] Inclusions { get; set; }

        public bool AlertRentalEffectivityEndDate { get; set; }

        public bool AlertReservationExpirationDate { get; set; }

        public ICollection<RoomViewModel> Rooms { get; set; } = new List<RoomViewModel>();
    }
}
