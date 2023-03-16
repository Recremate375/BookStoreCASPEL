using Microsoft.EntityFrameworkCore;
using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
