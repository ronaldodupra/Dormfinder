namespace DormFinder.Web.Entities
{
    public class Inclusion : BaseEntity
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string InclusionName { get; set; }

    }
}
