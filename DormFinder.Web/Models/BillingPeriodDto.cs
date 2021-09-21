using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Models
{
    public class BillingPeriodDto
    {
        public int Id { get; set; }
        public DateTime BillingMonth { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateBillingPeriodDto
    {
        public DateTime BillingMonth { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
