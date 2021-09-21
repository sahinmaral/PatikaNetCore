using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.BookOperations.Read
{
    public class ReadCommands
    {
        private BookStoreDbContext _context;

        public ReadBookViewModel Model { get; set; }

        public ReadCommands(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<ReadBookViewModel> GetBooks()
        {
            var books = from book in _context.Books
                join writer in _context.Writers on book.WriterId equals writer.Id
                join genre in _context.Genres on book.GenreId equals genre.Id
                select new ReadBookViewModel()
                {
                    Id = book.Id,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    Title = book.Title,
                    Genre = genre,
                    Writer = writer,
                };

            return books.ToList();
        }

        public ReadBookViewModel GetBookByBookId()
        {
            var searchedBook = from book in _context.Books
                join writer in _context.Writers on book.WriterId equals writer.Id
                join genre in _context.Genres on book.GenreId equals genre.Id
                select new ReadBookViewModel()
                {
                    Id = book.Id,
                    Description = book.Description,
                    PublishDate = book.PublishDate,
                    Title = book.Title,
                    Genre = genre,
                    Writer = writer,
                };

            return searchedBook.Single(x=>x.Id == Model.Id);
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
