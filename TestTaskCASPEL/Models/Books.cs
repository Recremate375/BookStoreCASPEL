using System.ComponentModel.DataAnnotations;

namespace TestTaskCASPEL.Models
{
    public class Books
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public DateOnly ReleaseDate { get; set; }
        [Required]
        public List<Orders>? Order { get; set; }
    }
}
