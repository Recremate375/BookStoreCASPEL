using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TestTaskCASPEL.Data;
using TestTaskCASPEL.DTO.Order;
using TestTaskCASPEL.Models;
using TestTaskCASPEL.Repository.IRepository;

namespace TestTaskCASPEL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _db;
        private readonly IBookRepository _bookRepository;
        public OrderRepository(BookStoreDbContext db, IBookRepository bookRepository)
        {
            _db = db;
            _bookRepository = bookRepository;
        }
        public async Task Create(Order item)
        {
            await _db.Orders.AddAsync(item);
            await Save();

        }

        public void Delete(int id)
        {
            Order order = _db.Orders.Find(id);
            if(order != null)
            {
                _db.Orders.Remove(order);
            }
        }
        public async Task<List<Order>> GetAll()
        {
            return await _db.Orders.Include(x => x.Books).ToListAsync();
        }

        public async Task<Order> GetByID(int id)
        {
            return await _db.Orders.Include(b => b.Books).FirstAsync(x => x.ID == id);
        }

        public async Task<List<Order>> GetOdersByNumber(int number)
        {
            return await _db.Orders.Where(num => num.ID == number).Include(x => x.Books).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
            return await _db.Orders.Where(d => d.OrderDate.Date == date.Date).Include(x => x.Books).ToListAsync();
        }

        public async Task Save()
        {

            await _db.SaveChangesAsync();

        }

        public void Update(Order item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Order> CreateOrderByBooksId(int[] booksId)
        {
            var books = await _bookRepository.GetBooksById(booksId);

            var order = new Order
            {
                Books = books,
                OrderDate = DateTime.UtcNow
            };
            await _db.Orders.AddAsync(order);
            await Save();
            return order;
        }
    }
}
