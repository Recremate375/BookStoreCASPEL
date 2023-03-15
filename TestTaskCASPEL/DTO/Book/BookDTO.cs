using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Book
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<Orders>? Order { get; set; }
    }
}
