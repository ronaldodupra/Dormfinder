using System.Collections.Generic;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public string RoomNumber { get; set; }
        public decimal? Price { get; set; }
        public string RoomTypeName { get; set; }
        public int AllowedPerson { get; set; }
        public decimal? Area { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Inclusions { get; set; }
        public ICollection<BedspaceViewModel> Bedspaces {get; set;} = new List<BedspaceViewModel>();
    }
}
