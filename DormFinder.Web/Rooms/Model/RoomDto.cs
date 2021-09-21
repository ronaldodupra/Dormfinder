using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Rooms.Model
{
    public class RoomDto
    {   
        
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int BasicRent { get; set; }
        public int FloorId { get; set; }
        public string RoomNumber { get; set; }
        public int AdvanceRent { get; set; }
        public int Occupant { get; set; }
        public decimal SecurityDeposit { get; set; }
        public RoomTypeDto RoomType { get; set; }
        public decimal Area { get; set; }
        public ICollection<RoomInclusionDto> RoomInclusion { get; set; }
        public ICollection<RoomPicDto> RoomPics { get; set; }
        public BuildingDto Building { get; set; }

        public class RoomTypeDto
        {
            public int Id { get; set; }
            public string RoomTypeName { get; set; }
        }
        public class RoomInclusionDto
        {
            public int Id { get; set; }
            public InclusionDto Inclusion { get; set; }
            public class InclusionDto
            {
                public int Id { get; set; }
                public string InclusionName { get; set; }
            }
        }
        public class RoomPicDto
        {
            public int FileEntryId { get; set; }
            public bool isThumbnail { get; set; }
            public FileEntryDto FileEntry { get; set; }
            public class FileEntryDto
            {
                public int Id { get; set; }
                
            }
        }
    }
}
