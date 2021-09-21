namespace DormFinder.Web.Entities
{
    public class ContractCheckList : BaseEntity
    {
        public int Id { get; private set; }
        public string StudentId { get; set; }

        public string ParentId { get; set; }

        public string ParentIdType { get; set; }
    }
}
