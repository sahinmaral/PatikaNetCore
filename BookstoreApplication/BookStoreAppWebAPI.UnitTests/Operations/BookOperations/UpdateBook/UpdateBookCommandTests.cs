using System;
using System.Linq;
using AutoMapper;

using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.BookOperations.Update;

using BookStoreAppWebAPI.UnitTests.TestSetup;

using FluentAssertions;

using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBookCommandTests(CommonTextFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidIdWasGiven_InvalidOperationException_ShouldBeThrew()
        {
            BookstoreAppWebAPI.Operations.BookOperations.Update.UpdateBookCommand command =
                new BookstoreAppWebAPI.Operations.BookOperations.Update.UpdateBookCommand(_context)
                {
                    Model = new UpdateBookViewModel() {Id = 0}
                };


            FluentActions.Invoking(() =>
            {
                command.UpdateBook();
            }).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap id'si içeren kitap yok");
        }

        [Fact]
        public void WhenUpdatedBookValuesEvenIdWasGiven_Book_ShouldBeUpdated()
        {
            BookstoreAppWebAPI.Operations.BookOperations.Update.UpdateBookCommand command =
                new BookstoreAppWebAPI.Operations.BookOperations.Update.UpdateBookCommand(_context)
                {
                    Model = new UpdateBookViewModel()
                    {
                        Description = "Nice book",
                        Title = "Another test book title",
                        Id = 1
                    }
                };

            FluentActions.Invoking(() =>
            {
                command.UpdateBook();
            }).Invoke();

            Book searchedBook = _context.Books.ToList().Find(x => x.Id == command.Model.Id);

            searchedBook.Should().NotBeNull();
            searchedBook.Description.Should().Be(command.Model.Description);
            searchedBook.Title.Should().Be(command.Model.Title);
        }


    }
}
