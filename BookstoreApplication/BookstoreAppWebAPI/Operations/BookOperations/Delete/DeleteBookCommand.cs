using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;

namespace BookstoreAppWebAPI.Operations.BookOperations.Delete
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _context;

        public DeleteBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public DeleteBookViewModel Model { get; set; }

        public void DeleteBook()
        {
            var searchedBook = _context.Books.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedBook == null) throw new InvalidOperationException("Böyle bir kitap id'si içeren kitap yok");

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
