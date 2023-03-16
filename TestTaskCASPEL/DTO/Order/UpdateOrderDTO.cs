using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Order
{
    public class UpdateOrderDTO
    {
        public int ID { get; set; }
        public List<Models.Book>? Books { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
