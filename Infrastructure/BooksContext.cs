using Microsoft.EntityFrameworkCore;
using REST.Domain.Book;

namespace REST.Infrastructure
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
