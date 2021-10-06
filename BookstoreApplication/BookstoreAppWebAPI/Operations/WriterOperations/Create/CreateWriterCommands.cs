using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

using System;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.Operations.DbOperations;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Create
{
    public class CreateWriterCommands
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateWriterViewModel Model { get; set; }
        public CreateWriterCommands(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddWriter()
        {
            Writer searchedWriter = _context.Writers.ToList().Find(x => x.Name == Model.Name);

            if (searchedWriter != null)
            {
                throw new InvalidOperationException("Böyle bir yazar adı mevcut");
            }

            Writer addedWriter = new Writer();

            addedWriter = _mapper.Map(Model, addedWriter);

            _context.Writers.Add(addedWriter);

            _context.SaveChanges();
        }
    }

    public class CreateWriterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
