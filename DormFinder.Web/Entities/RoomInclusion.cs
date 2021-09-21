using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class RoomInclusion
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int roomId { get; set; }
        public int InclusionId { get; set; }
        public Inclusion Inclusion { get; set; }




    }
}
