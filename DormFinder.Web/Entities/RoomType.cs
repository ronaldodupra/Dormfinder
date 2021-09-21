namespace DormFinder.Web.Entities
{
    public class RoomType:BaseEntity
    {
        public int Id { get; set; }

        public string RoomTypeName { get; set; }

        public int AllowedPerson { get; set; }
    }
}
