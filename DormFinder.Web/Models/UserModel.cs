using DormFinder.Web.Entities.Identity;

namespace DormFinder.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressDto Address { get; set; }

        public static UserModel FromUser(User user)
        {
            var dto = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            return dto;
        }

        public class AddressDto
        {
            public string City { get; set; }

            public string Province { get; set; }

            public string AddressLine1 { get; set; }

            public string AddressLine2 { get; set; }
        }

        public class RegisterUser
        {
            public int Id { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            //[DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
            //public string ConfirmPassword { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string City { get; set; }

            public string Token { get; set; }
        }
    }
}
