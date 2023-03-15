namespace TestTaskCASPEL.Models
{
    public class Books
    {
        public Guid ID { get; set; }
        public string BookName { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<Orders>? Order { get; set; }
    }
}
