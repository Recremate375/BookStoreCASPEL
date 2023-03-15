using Microsoft.EntityFrameworkCore;
using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Books> Books { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
