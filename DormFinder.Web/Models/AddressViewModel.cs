using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Models
{
    public class AddressViewModel
    {
        public string AddressName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int Count { get; set; }

    }
}
