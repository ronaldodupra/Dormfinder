using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class BillingPeriod : BaseEntity
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public DateTime BillingMonth { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
