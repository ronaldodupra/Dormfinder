using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DormFinder.Web.Buildings.Models.BuildingDto;

namespace DormFinder.Web.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? OriginalImageId { get; set; }

        public FileEntryDto OriginalImage { get; set; }

        public string UserType { get; set; }

        public string Status { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public int AddressId { get; set; }

        public AddressDto Address { get; set; }

        public bool Student { get; set; }

        public string School { get; set; }

        public string Course { get; set; }

        public string Gender { get; set; }
    }
}
