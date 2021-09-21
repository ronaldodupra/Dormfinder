using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Models
{
    public class InquiryModel
    {
        public string FullName { get; set; }
        public string InquiryFullName { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string CreatedAt { get; set; }
        public string BuildingName { get; set; }
        public string Address { get; set; }
        public string RoomName { get; set; }
    }
}
