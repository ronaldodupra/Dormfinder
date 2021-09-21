using System.Collections.Generic;
using System.Linq;

namespace DormFinder.Web.Entities
{
    public class Bedspace : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        public int Status { get; set; } 
        public bool IsActive { get; set; }
        public Bedspace(){
            Status = 1;
            IsActive = true;
        }


    }
}
