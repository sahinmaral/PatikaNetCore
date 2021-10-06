using System;
using System.Linq;
using AutoMapper;

using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.BookOperations.Delete;
using BookstoreAppWebAPI.Operations.DbOperations;
using BookStoreAppWebAPI.UnitTests.TestSetup;

using FluentAssertions;

using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteBookCommandTests(CommonTextFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidIdWasGiven_InvalidOperationException_ShouldBeThrown()
        {
            DeleteBookCommand command =
                new DeleteBookCommand(_context)
                {
                    Model = new DeleteBookViewModel() {Id = 0}
                };


            FluentActions.Invoking(() =>
            {
                command.DeleteBook();
            }).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap id'si içeren kitap yok");
        }

        [Fact]
        public void WhenDeletedBookIdWasGiven_Book_ShouldBeDeleted()
        {
            DeleteBookCommand command =
                new DeleteBookCommand(_context)
                {
                    Model = new DeleteBookViewModel()
                    {
                        Id = 1
                    }
                };

            FluentActions.Invoking(() =>
            {
                command.DeleteBook();
            }).Invoke();

            Book searchedBook = _context.Books.ToList().Find(x => x.Id == command.Model.Id);

            searchedBook.Should().BeNull();

        }


    }
}
