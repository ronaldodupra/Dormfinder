using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DormFinder.Web.Buildings.Models.BuildingDto;

namespace DormFinder.Web.Users.Model
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressDto Address { get; set; }

        public bool Student { get; set; }

        public string School { get; set; }

        public string Course { get; set; }

        public string Gender { get; set; }
    }
}
