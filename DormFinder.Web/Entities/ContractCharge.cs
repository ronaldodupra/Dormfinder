using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class ContractCharge
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int ChargeId { get; set; }
        public Charge Charge { get; set; }
    }
}
