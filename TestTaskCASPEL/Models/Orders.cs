using System.ComponentModel.DataAnnotations;

namespace TestTaskCASPEL.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public List<Books>? Books { get; set; } = new();
        public DateTime OrderDate { get; set; }
    }
}
