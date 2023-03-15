namespace TestTaskCASPEL.Models
{
    public class Orders
    {
        public Guid ID { get; set; }
        public int OrderNumber { get; set; }
        public List<Books> Books { get; set; } = new();
    }
}
