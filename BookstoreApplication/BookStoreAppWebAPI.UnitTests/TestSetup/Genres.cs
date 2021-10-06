using System;
using System.Collections.Generic;
using System.Text;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.DbOperations;

namespace BookStoreAppWebAPI.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre
                {
                    Id = 1,
                    Name = "Training Book"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Novel"
                }
            );
        }
    }
}
