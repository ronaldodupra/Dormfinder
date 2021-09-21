using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Models
{
    public class UpdateBuildingPicModel
    {
        public string type { get; set; }
        public string roomId { get; set; }
        public string description { get; set; }
        public bool isViewable { get; set; }
    }
}
