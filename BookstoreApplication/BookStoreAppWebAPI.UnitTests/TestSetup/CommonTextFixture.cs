using System.Net.Mime;
using AutoMapper;
using BookstoreAppWebAPI.Common;
using BookstoreAppWebAPI.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAppWebAPI.UnitTests.TestSetup
{
    public class CommonTextFixture
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTextFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDb").Options;

            Context = new BookStoreDbContext(options);

            Context.Database.EnsureCreated();

            Context.AddBooks();
            
            Context.AddGenres();

            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
    }
}
