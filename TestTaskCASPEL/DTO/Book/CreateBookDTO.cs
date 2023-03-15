using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Book
{
    public class CreateBookDTO
    {
        public string BookName { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<Orders>? Order { get; set; }
    }
}
