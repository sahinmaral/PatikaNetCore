using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Delete
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public DeleteGenreViewModel Model { get; set; }

        public void DeleteBook()
        {
            var searchedGenre = _context.Genres.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedGenre == null) throw new InvalidOperationException("Böyle bir tür id'si içeren tür yok");

            _context.Genres.Remove(searchedGenre);

            _context.SaveChanges();
        }
    }

    public class DeleteGenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
