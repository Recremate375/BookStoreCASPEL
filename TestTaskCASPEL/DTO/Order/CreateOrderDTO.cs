using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Order
{
    public class CreateOrderDTO
    {
        public List<Books> Books { get; set; } = new();
        public DateOnly OrderDate { get; set; }
    }
}
