﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Book>> GetBooksByName(string name)
        {
            return await _db.Books.Where(x => x.BookName == name).ToListAsync();
        }

        public bool IsBookExist(string name)
        {
            Book book = _db.Books.Find(name);
            if(book == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Book>> GetBooksByDate(DateTime releaseDate)
        {
            return await _db.Books.Where(x => x.ReleaseDate == releaseDate).ToListAsync();
        }

        public async Task<List<Book>> GetAll()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetByID(int id)
        {
            return await _db.Books.FindAsync(id);
        }

        public async Task Create(Book item)
        {
            _db.Books.Add(item);
            await Save();
        }

        public void Update(Book item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = _db.Books.Find(id);
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

        public async Task<List<Book>> GetBooksById(int[] id)
        {
            return await _db.Books.Where(book => id.Contains(book.ID)).ToListAsync();
        }
    }
}
