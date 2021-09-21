using System;
using Microsoft.AspNetCore.Identity;

namespace DormFinder.Web.Entities.Identity
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? OriginalImageId { get; set; }

        public virtual FileEntry OriginalImage { get; set; }

        public string UserType { get; set; }

        public string Status { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public DateTime CreatedAt { get; private set; }

        public int CreatedById { get; set; }

        public DateTime UpdatedAt { get; private set; }

        public int UpdatedById { get; set; }

        public bool Student { get; set; }

        public string School { get; set; }

        public string Course { get; set; }

        public string Gender { get; set; }

        public User()
        {
            Address = new Address();
        }
    }
}
