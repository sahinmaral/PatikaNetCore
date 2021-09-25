using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Update
{
    public class UpdateWriterCommands
    {
        private readonly BookStoreDbContext _context;
        public UpdateWriterCommands(BookStoreDbContext context)
        {
            _context = context;
        }

        public UpdateWriterViewModel Model { get; set; }

        public void UpdateWriter()
        {
            var searchedWriter = _context.Writers.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedWriter == null) throw new InvalidOperationException("Böyle bir yazar id'si olan tür yok");

            searchedWriter.Name = Model.Name != default ? Model.Name : searchedWriter.Name;
            searchedWriter.Surname = Model.Surname != default ? Model.Surname : searchedWriter.Surname;
            searchedWriter.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth : searchedWriter.DateOfBirth;

            _context.SaveChanges();
        }
    }

    public class UpdateWriterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
