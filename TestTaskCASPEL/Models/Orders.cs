using System.ComponentModel.DataAnnotations;

namespace TestTaskCASPEL.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public List<Books> Books { get; set; } = new();
        [Required]
        public DateOnly OrderDate { get; set; }
    }
}
