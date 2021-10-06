using System;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.BookOperations.Create;
using BookstoreAppWebAPI.Operations.DbOperations;
using BookStoreAppWebAPI.UnitTests.TestSetup;
using FluentAssertions;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTextFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTextFixture textFixture)
        {
            _mapper = textFixture.Mapper;
            _context = textFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistBootTitleGiven_InvalidOperationException_ShouldBeThrown()
        {
            var book = new Book()
            {
                Description = "Güzel kitap",
                Title = "Lean Startup",
                GenreId = 1,
                WriterId = 1,
                PublishDate = new DateTime(2000, 02, 11)
            };

            CreateBookCommand commands = new CreateBookCommand(_context, _mapper)
            {
                Model = new CreateBookViewModel()
                {
                    Title = book.Title,
                    Description = book.Description,
                    GenreId = book.GenreId,
                    PublishDate = book.PublishDate,
                    WriterId = book.WriterId
                }
            };

            FluentActions.Invoking(() =>
            {
                commands.AddBook();
            }).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");


        }


        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            BookstoreAppWebAPI.Operations.BookOperations.Create.CreateBookCommand commands =
                new BookstoreAppWebAPI.Operations.BookOperations.Create.CreateBookCommand(_context, _mapper);

            CreateBookViewModel model = new CreateBookViewModel()
            {
                Title = "Cerrah",
                Description = "Güzel kitap",
                GenreId = 1,
                PublishDate = new DateTime(2000, 02, 11),
                WriterId = 1
            };

            commands.Model = model;

            //act
            FluentActions.Invoking(() =>
            {
                commands.AddBook();
            }).Invoke();

            //assert

            var searchedBook = _context.Books.ToList().Find(x => x.Title == model.Title);

            searchedBook.Should().NotBeNull();
            searchedBook.Title.Should().Be(model.Title);
            searchedBook.PublishDate.Should().Be(model.PublishDate);
            searchedBook.WriterId.Should().Be(model.WriterId);
            searchedBook.GenreId.Should().Be(model.GenreId);
        }

    }
}