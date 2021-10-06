using System;
using System.Collections.Generic;
using System.Text;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.DbOperations;

namespace BookStoreAppWebAPI.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(new Book
                {
                    Title = "Lean Startup",
                    Description = "Güzel kitap",
                    PublishDate = new DateTime(2001, 06, 12),
                    WriterId = 1,
                    GenreId = 1
                },
                new Book
                {
                    Title = "Dune",
                    Description = "Güzel kitap",
                    PublishDate = new DateTime(2001, 12, 21),
                    WriterId = 2,
                    GenreId = 2
                },
                new Book
                {
                    Title = "Herland",
                    Description = "Güzel kitap",
                    PublishDate = new DateTime(2010, 12, 21),
                    WriterId = 3,
                    GenreId = 2
                });
        }
    }
}
