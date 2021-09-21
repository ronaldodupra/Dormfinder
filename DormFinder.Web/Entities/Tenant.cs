using DormFinder.Web.Entities.Identity;

namespace DormFinder.Web.Entities
{
    public class Tenant : BaseEntity
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public int RoomId { get; set; }

        public int ContractId { get; set; }

        public User User { get; set; }

        public Contract Contract { get; set; }

        public Room Room { get; set; }
    }
}
