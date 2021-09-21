using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Billings.Utilities.Model
{
    public class UtilityReadingDto
    {
        public int? Id { get; set; }

        public int UtilityId { get; set; }

        public string MeterNumber { get; set; }

        public double? PreviousReading { get; set; }

        public double? CurrentReading { get; set; }
    }
}
