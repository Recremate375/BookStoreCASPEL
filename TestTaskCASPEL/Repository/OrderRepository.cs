using Microsoft.EntityFrameworkCore;
using TestTaskCASPEL.Data;
using TestTaskCASPEL.Models;
using TestTaskCASPEL.Repository.IRepository;

namespace TestTaskCASPEL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _db;

        public OrderRepository(BookStoreDbContext db)
        {
            _db = db;
        }
        public void Create(Orders item)
        {
            _db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Orders order = _db.Orders.Find(id);
            if(order != null)
            {
                _db.Orders.Remove(order);
            }
        }
        public async Task<List<Orders>> GetAll()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Orders> GetByID(int id)
        {
            return await _db.Orders.FindAsync(id);
        }

        public async Task<List<Orders>> GetOdersByNumber(int number)
        {
            return await _db.Orders.Where(num => num.ID == number).Include(x => x.Books).ToListAsync();
        }

        public async Task<List<Orders>> GetOrdersByDate(DateOnly date)
        {
            return await _db.Orders.Where(d => d.OrderDate == date).Include(x => x.Books).ToListAsync();
        }

        public async Task Save()
        {
             await _db.SaveChangesAsync();
        }

        public void Update(Orders item)
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
    }
}
