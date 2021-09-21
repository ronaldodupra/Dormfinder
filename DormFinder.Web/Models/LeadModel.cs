using System;
using DormFinder.Web.Rooms.Model;

namespace DormFinder.Web.Models
{
    public class LeadModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Message { get; set; }

        public int RoomId { get; set; }

        public string Status { get; set; }

        public RoomDto Room { get; set; }

        public ContractModel Contract { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }
    }

    public class AddLeadModel
    {
        public string Email { get; set; }

        public string Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Message { get; set; }

        public int RoomId { get; set; }
    }
}
