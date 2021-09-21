using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.BookOperations.Create
{
    public class CreateCommands
    {
        public CreateBookViewModel Model { get; set; }

        private BookStoreDbContext _context;

        public CreateCommands(BookStoreDbContext context)
        {
            _context = context;
        }

        public void AddBook()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }

            book = new Book()
            {
                Description = Model.Description,
                GenreId = Model.GenreId,
                WriterId = Model.WriterId,
                PublishDate = Model.PublishDate
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        

    }

    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public int WriterId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}