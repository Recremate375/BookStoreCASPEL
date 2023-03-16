using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Order
{
    public class CreateOrderDTO
    {
        public List<Models.Book>? Books { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
