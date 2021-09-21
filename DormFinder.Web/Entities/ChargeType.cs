using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Entities
{
    public class ChargeType : BaseEntity    
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal DefaultAmount { get; set; } 

        public bool IsVatable { get; set; }
    }
}
