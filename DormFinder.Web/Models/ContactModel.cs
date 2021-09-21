using System;
using System.Collections.Generic;

namespace DormFinder.Web.Models
{
    public class UpdateContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Type { get; set; } 
        public string Address { get; set; }
        public string LandLineNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string YearOfStudy { get; set; }
        public string Education { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Hobbies { get; set; }
        public string Status { get; set; }
    }
}