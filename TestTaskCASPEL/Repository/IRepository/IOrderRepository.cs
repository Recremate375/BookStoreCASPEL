using TestTaskCASPEL.DTO.Order;
using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.Repository.IRepository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOdersByNumber(int number);
        Task<List<Order>> GetOrdersByDate(DateTime date);
        Task<Order> CreateOrderByBooksId(int[] booksId);
    }
}
