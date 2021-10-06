using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAppWebAPI.Operations.DbOperations
{
    public class BookStoreDbContext : DbContext,IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
    }
}