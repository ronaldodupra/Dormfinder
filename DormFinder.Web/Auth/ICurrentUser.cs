namespace DormFinder.Web.Auth
{
    public interface ICurrentUser
    {
        public int Id { get; }

        public int? OrganizationId { get; }
    }
}
