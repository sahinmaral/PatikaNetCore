using System.Collections.Generic;
using BookstoreAppWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAppWebAPI.DbOperations
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }

        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
