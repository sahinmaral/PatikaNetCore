using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Read
{
    public class ReadWriterCommands
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public ReadWriterViewModel Model { get; set; }

        public ReadWriterCommands(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadWriterViewModel> GetAllClearly()
        {
            var genres = _context.Writers.ToList().OrderBy(x=>x.Id);

            List<ReadWriterViewModel> viewModels = _mapper.Map<List<ReadWriterViewModel>>(genres);

            return viewModels;
        }

        public List<Writer> GetAll()
        {
            return _context.Writers.ToList();
        }

        public ReadWriterViewModel GetWriterById()
        {
            Writer searchedWriter =  _context.Writers.ToList().Find(x => x.Id == Model.Id);

            ReadWriterViewModel viewModel = _mapper.Map<ReadWriterViewModel>(searchedWriter);

            return viewModel;
        }
    }

    public class ReadWriterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
    }
}
