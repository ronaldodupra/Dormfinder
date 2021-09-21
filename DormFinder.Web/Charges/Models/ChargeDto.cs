using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.ChargeTypes.Models;

namespace DormFinder.Web.Charges.Models
{
    public class ChargeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public double DefaultCharge { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int BillingStatementOrder { get; set; }
        public bool IsVat { get; set; }
        public int ChargeTypeId { get; set; }
        public ChargeTypeDto ChargeType { get; set; }
    }
}
