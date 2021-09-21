using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.ChargeTypes.Models
{
    public class ChargeTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double DefaultAmount { get; set; }
        public bool IsVatable { get; set; }
    }
}
