using System.Collections.Generic;

namespace DormFinder.Web.Entities
{
    public class Utility : BaseEntity
    {
        public int Id { get; private set; }

        public int OrganizationId { get; set; }

        public string MeterNumber { get; set; }

        public double InitialReading { get; set; }

        public int UtilityTypeId { get; set; }

        public UtilityType UtilityType { get; set; }
    }
}
