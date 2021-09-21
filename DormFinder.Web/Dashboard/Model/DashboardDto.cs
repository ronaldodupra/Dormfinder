using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Dashboard.Model
{
    public class DashboardDto
    {
        public string Name { get; set; }
        public ICollection<FloorDto> Floors { get;set; }
        public ICollection<RoomDto> Rooms { get; set; }
        public class RoomDto
        {
            public string RoomName { get; set; }
            public int FloorId { get; set; }
            public ICollection<BedspaceDto> Bedspaces { get; set; }
            public FloorDtos Floor { get; set; }
            public class FloorDtos
            {
                public string description { get; set; }
            }
            public class BedspaceDto
            {
                public int isActive { get; set; }
                public int status { get; set; }
            }
        }
        public class FloorDto {
            public string description { get; set; }
            public ICollection<RoomFloorDto> Rooms { get; set; }
            public class RoomFloorDto
            {
                public string RoomName { get; set; }
                public ICollection<BedspaceFloorDto> Bedspaces { get; set; }
                public class BedspaceFloorDto
                {
                    public int isActive { get; set; }
                    public int status { get; set; }
                }
            }
        }

        
    }
}
