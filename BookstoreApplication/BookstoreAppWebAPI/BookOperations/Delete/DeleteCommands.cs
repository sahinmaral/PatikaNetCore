using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.BookOperations.Delete
{
    public class DeleteCommands
    {
        private BookStoreDbContext _context;

        public DeleteBookViewModel Model { get; set; }

        public DeleteCommands(BookStoreDbContext context)
        {
            _context = context;
        }

        public void DeleteBook()
        {
            Book searchedBook = _context.Books.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedBook == null) throw new InvalidOperationException("Böyle bir kitap yok");

            _context.Books.Remove(searchedBook);

            _context.SaveChanges();
        }
    }

    public class DeleteBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public int WriterId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
