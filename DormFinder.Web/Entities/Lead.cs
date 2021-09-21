using DormFinder.Web.Entities.Identity;

namespace DormFinder.Web.Entities
{
    public class Lead : BaseEntity
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Message { get; set; }

        public int RoomId { get; set; }

        public string Status { get; set; }

        public Room Room { get; set; }

        public Contract Contract { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
