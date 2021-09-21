using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class UtilityReading : BaseEntity
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int UtilityId { get; set; }

        public Utility Utility { get; set; }

        public double Reading { get; set; }
    }
}
