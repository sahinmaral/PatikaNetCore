using AutoMapper;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreAppWebAPI.Operations.FilmOperation.Create
{
    public class CreateFilmCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateFilmViewModel Model { get; set; }
        public CreateFilmCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add()
        {
            Film searchedFilm = _context.Films.SingleOrDefault(x => x.Name == Model.Name);

            if (searchedFilm != null)
            {
                throw new InvalidOperationException("Böyle bir film var");
            }

            Genre searchedGenre = _context.Genres.SingleOrDefault(x => x.Id == Model.GenreId);

            if (searchedGenre == null)
            {
                throw new InvalidOperationException("Böyle bir tür yok");
            }

            Director searchedDirector = _context.Directors.SingleOrDefault(x => x.Id == Model.DirectorId);

            if (searchedDirector == null)
            {
                throw new InvalidOperationException("Böyle bir yönetmen yok");
            }

            foreach (Player player in Model.Players)
            {
                Player searchedPlayer = _context.Players.SingleOrDefault(x => x.Id == player.Id);

                if (searchedPlayer == null)
                {
                    throw new InvalidOperationException("Böyle bir oyuncu yok");
                }
            }

            searchedFilm = _mapper.Map(Model, searchedFilm);

            _context.Films.Add(searchedFilm);

            foreach (Player player in Model.Players)
            {
                FilmAndPlayerRelation relation = new FilmAndPlayerRelation()
                {
                    PlayerId = player.Id,
                    FilmId = searchedFilm.Id
                };

                _context.FilmAndPlayerRelations.Add(relation);
            }


            _context.SaveChanges();
        }
    }

    public class CreateFilmViewModel
    {
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Price { get; set; }
        public string About { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public List<Player> Players { get; set; }
    }
}
