using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.Repository.IRepository
{
    public interface IOrderRepository : IBaseRepository<Orders>
    {
        Task<List<Orders>> GetOdersByNumber(int number);
        Task<List<Orders>> GetOrdersByDate(DateOnly date);
        
    }
}
