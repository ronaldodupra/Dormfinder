using System;

namespace DormFinder.Web.Entities
{
    public class RentalPdc : BaseEntity
    {
        public int Id { get; private set; }

        public string CheckNumber { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public string AccountNumber { get; set; }

        public double Amount { get; set; }

        public DateTime CheckDate { get; set; }

        public DateTime MaturityDate { get; set; }
    }
}
