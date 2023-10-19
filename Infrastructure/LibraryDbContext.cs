using Lenkie_Assessment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lenkie_Assessment.Infrastructure
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

    }
}
