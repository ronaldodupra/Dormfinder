namespace DormFinder.Web.Entities
{
    public class BuildingType : BaseEntity
    {
        public int Id { get; private set; }

        public string Description { get; private set; }

        private BuildingType()
        {
        }

        public BuildingType(string description)
        {
            Description = description;
        }
    }
}
