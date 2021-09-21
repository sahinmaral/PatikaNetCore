using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookstoreAppWebAPI
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(new Book()
                    {
                        Title = "Lean Startup",
                        Description = "Güzel kitap",
                        PublishDate = new DateTime(2001, 06, 12),
                        WriterId = 1,
                        GenreId = 1
                    },
                    new Book()
                    {
                        Title = "Dune",
                        Description = "Güzel kitap",
                        PublishDate = new DateTime(2001, 12, 21),
                        WriterId = 2,
                        GenreId = 2
                    },
                    new Book()
                    {
                        Title = "Herland",
                        Description = "Güzel kitap",
                        PublishDate = new DateTime(2010, 12, 21),
                        WriterId = 3,
                        GenreId = 2
                    });

                context.Writers.AddRange(
                    new Writer()
                    {
                        Id = 1,
                        Name = "Eric Ries"
                    },
                    new Writer()
                    {
                        Id = 2,
                        Name = "Frank Herbert"
                    },
                    new Writer()
                    {
                        Id = 3,
                        Name = "Charlotte Perkins Gilman"
                    }
                );

                context.Genres.AddRange(
                    new Genre()
                    {
                        Id = 1,
                        Name = "Training Book"
                    },
                    new Genre()
                    {
                        Id = 2,
                        Name = "Novel"
                    }
                );

                context.SaveChanges();

            }
        }
    }
}
