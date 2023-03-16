using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Book
{
    public class UpdateBookDTO
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
