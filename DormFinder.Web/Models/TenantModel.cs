using System;

namespace DormFinder.Web.Models
{
    public class TenantDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public ContractDto Contract { get; set; }

        public RoomDto Room { get; set; }

        public BuildingDto Building { get; set; }

        public class UserDto
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string Address { get; set; }
        }

        public class BuildingDto
        {
            public string Name { get; set; }
        }

        public class RoomDto
        {
            public string RoomName { get; set; }
        }

        public class ContractDto
        {
            public DateTime StartDate { get; set; }

            public decimal BasicRent { get; set; }

            public decimal SecurityDeposit { get; set; }
        }
    }

    public class CreateTenantDto
    {
        public int RoomId { get; set; }

        public int ContractId { get; set; }

        public int UserId { get; set; }
    }

    public class TenantContractDto
    {
        public int Id { get; set; }

        public TenantDto.UserDto User { get; set; }

        public ContractDto Contract { get; set; }

        public class ContractDto
        {
            public decimal SecurityDeposit { get; set; }
        }
    }
}
