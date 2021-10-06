using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.FilmOperation.Read
{
    public class ReadFilmCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadFilmCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadFilmViewModel> GetAll()
        {
            List<Film> films = _context.Films
                .Include(x=>x.Director)
                .Include(x=>x.Genre)
                .ToList();

            List<ReadFilmViewModel> viewModels = new List<ReadFilmViewModel>();

            viewModels = _mapper.Map(films, viewModels);

            foreach (var film in viewModels)
            {
                film.Players = new List<Player>();

                List<FilmAndPlayerRelation> relations =
                    _context.FilmAndPlayerRelations
                        .Include(x=>x.Player)
                        .Where(x => x.FilmId == film.Id).ToList();

                relations.ForEach(x=>film.Players.Add(x.Player));

            }

            return viewModels;
        }
    }

    public class ReadFilmViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Price { get; set; }
        public string About { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }
        public List<Player> Players { get; set; }
    }
}
