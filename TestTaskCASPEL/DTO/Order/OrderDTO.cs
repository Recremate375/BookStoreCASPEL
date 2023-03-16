using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Order
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public List<Books>? Books { get; set; } 
        public DateTime? OrderDate { get; set; }
    }
}
