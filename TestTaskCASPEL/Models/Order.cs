using System.ComponentModel.DataAnnotations;

namespace TestTaskCASPEL.Models
{
    public class Order
    {
        public int ID { get; set; }
        public List<Book>? Books { get; set; } = new();
        public DateTime OrderDate { get; set; }
    }
}
