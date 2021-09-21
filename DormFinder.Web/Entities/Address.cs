namespace DormFinder.Web.Entities
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public override string ToString()
        {
            return $"{AddressLine1}, {City}";
        }
    }
}
