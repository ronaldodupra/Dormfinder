using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class BuildingNearbyPlace
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string Place { get; set; }
    }
}
