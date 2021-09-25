using System;
using System.Linq;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Delete
{
    public class DeleteWriterCommands
    {
        private readonly BookStoreDbContext _context;

        public DeleteWriterCommands(BookStoreDbContext context)
        {
            _context = context;
        }

        public DeleteWriterViewModel Model { get; set; }

        public void DeleteBook()
        {
            Writer searchedWriter = _context.Writers.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedWriter == null) throw new InvalidOperationException("Böyle bir tür id'si içeren tür yok");

            int activeBookCount = _context.Books.Count(x => x.WriterId == Model.Id);

            if (activeBookCount > 0)
            {
                throw new InvalidOperationException("Yazarın silinmesi için öncelikle kitapları silinmeli");
            }

            _context.Writers.Remove(searchedWriter);

            _context.SaveChanges();
        }
    }

    public class DeleteWriterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
