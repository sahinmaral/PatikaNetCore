using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Update
{
    public class UpdateGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public UpdateGenreViewModel Model { get; set; }

        public void UpdateGenre()
        {
            var searchedGenre = _context.Genres.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedGenre == null) throw new InvalidOperationException("Böyle bir tür id'si olan tür yok");

            searchedGenre.Name = Model.Name != default ? Model.Name : searchedGenre.Name;
            searchedGenre.IsActive = Model.IsActive != default ? Model.IsActive : searchedGenre.IsActive;

            _context.SaveChanges();
        }
    }

    public class UpdateGenreViewModel
    {
        public UpdateGenreViewModel()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
