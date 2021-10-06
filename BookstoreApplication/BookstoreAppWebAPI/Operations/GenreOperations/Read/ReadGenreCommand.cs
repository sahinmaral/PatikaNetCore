using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using FluentValidation.Results;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Read
{
    public class ReadGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public ReadGenreViewModel Model { get; set; }

        public ReadGenreCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadGenreViewModel> GetAllClearly()
        {
            var genres = _context.Genres.ToList().OrderBy(x=>x.Id);

            List<ReadGenreViewModel> viewModels = _mapper.Map<List<ReadGenreViewModel>>(genres);

            return viewModels;
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public ReadGenreViewModel GetGenreById()
        {
            
            Genre searchedGenre =  _context.Genres.ToList().Find(x => x.Id == Model.Id);

            ReadGenreViewModel viewModel = _mapper.Map<ReadGenreViewModel>(searchedGenre);

            return viewModel;
        }
    }

    public class ReadGenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
