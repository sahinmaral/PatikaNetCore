using BookstoreAppWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAppWebAPI.DbOperations
{
    public interface IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Writer> Writers { get; set; }
        int SaveChanges();
    }
}