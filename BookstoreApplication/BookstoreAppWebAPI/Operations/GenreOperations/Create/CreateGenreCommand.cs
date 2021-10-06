using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.GenreOperations.Read;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Create
{
    public class CreateGenreCommand
    {
        private readonly IBookStoreDbContext _context;

        public CreateGenreViewModel Model { get; set; }
        public CreateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void AddGenre()
        {
            Genre searchedGenre = _context.Genres.ToList().Find(x => x.Name == Model.Name);

            if (searchedGenre != null)
            {
                throw new InvalidOperationException("Böyle bir tür adı mevcut");
            }

            _context.Genres.Add(new Genre()
            {
                IsActive = Model.IsActive,
                Name = Model.Name
            });

            _context.SaveChanges();
        }
    }

    public class CreateGenreViewModel
    {
        public CreateGenreViewModel()
        {
            IsActive = true;
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
