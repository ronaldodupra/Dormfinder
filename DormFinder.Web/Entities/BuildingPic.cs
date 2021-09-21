namespace DormFinder.Web.Entities
{
    public class BuildingPic : BaseEntity
    {
        public int Id { get; private set; }

        public int BuildingId { get; set; }

        public int FileEntryId { get; set; }
    }
}
