using Microsoft.EntityFrameworkCore;
using TestTaskCASPEL.Data;
using TestTaskCASPEL.Models;
using TestTaskCASPEL.Repository.IRepository;

namespace TestTaskCASPEL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _db;
        public BookRepository(BookStoreDbContext db)
        {
            _db = db;
        }

        public async Task<List<Books>> GetBooksByName(string name)
        {
            return await _db.Books.Where(x => x.BookName == name).ToListAsync();
        }

        public bool IsBookExist(string name)
        {
            Books book = _db.Books.Find(name);
            if(book == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Books>> GetBooksByDate(DateOnly releaseDate)
        {
            return await _db.Books.Where(x => x.ReleaseDate == releaseDate).ToListAsync();
        }

        public async Task<List<Books>> GetAll()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Books> GetByID(int id)
        {
            return await _db.Books.FindAsync(id);
        }

        public void Create(Books item)
        {
            _db.Books.Add(item);
        }

        public void Update(Books item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Books book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
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
