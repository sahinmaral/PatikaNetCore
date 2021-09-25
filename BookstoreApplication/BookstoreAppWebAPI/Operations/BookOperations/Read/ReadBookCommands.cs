using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.Operations.BookOperations.Read
{
    public class ReadBookCommands
    {
        private readonly BookStoreDbContext _context;

        public ReadBookCommands(BookStoreDbContext context)
        {
            _context = context;
        }

        public ReadBookViewModel Model { get; set; }

        public List<ReadBookViewModel> GetBooksWithDetails()
        {
            var books = from book in _context.Books
                join writer in _context.Writers on book.WriterId equals writer.Id
                join genre in _context.Genres on book.GenreId equals genre.Id
                select new ReadBookViewModel
                {
                    Id = book.Id,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    Title = book.Title,
                    Genre = genre,
                    Writer = writer
                };

            return books.ToList();
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookByBookId()
        {
            return _context.Books.Single(x => x.Id == Model.Id);
        }

        public ReadBookViewModel GetBookWithDetailsByBookId()
        {
            var searchedBook = from book in _context.Books
                join writer in _context.Writers on book.WriterId equals writer.Id
                join genre in _context.Genres on book.GenreId equals genre.Id
                select new ReadBookViewModel
                {
                    Id = book.Id,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    Title = book.Title,
                    Genre = genre,
                    Writer = writer
                };

            return searchedBook.Single(x => x.Id == Model.Id);
        }

    }


    public class ReadBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public Genre Genre { get; set; }
        public Writer Writer { get; set; }
    }
}