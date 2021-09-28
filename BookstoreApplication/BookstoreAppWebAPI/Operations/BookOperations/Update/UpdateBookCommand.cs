using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;

namespace BookstoreAppWebAPI.Operations.BookOperations.Update
{
    public class UpdateBookCommand
    {
        private readonly IBookStoreDbContext _context;

        public UpdateBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public UpdateBookViewModel Model { get; set; }

        public void UpdateBook()
        {
            var searchedBook = _context.Books.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedBook == null) throw new InvalidOperationException("Böyle bir kitap id'si içeren kitap yok");

            searchedBook.GenreId = Model.GenreId != default ? Model.GenreId : searchedBook.GenreId;
            searchedBook.Title = Model.Title != default ? Model.Title : searchedBook.Title;
            searchedBook.Description = Model.Description != default ? Model.Description : searchedBook.Description;
            searchedBook.WriterId = Model.WriterId != default ? Model.WriterId : searchedBook.WriterId;
            searchedBook.PublishDate = Model.PublishDate != default ? Model.PublishDate : searchedBook.PublishDate;

            _context.SaveChanges();

        }



    }

    public class UpdateBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public int WriterId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}