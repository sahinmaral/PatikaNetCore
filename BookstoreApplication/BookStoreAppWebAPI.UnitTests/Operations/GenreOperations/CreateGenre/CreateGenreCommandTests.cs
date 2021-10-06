using System;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.BookOperations.Create;
using BookstoreAppWebAPI.Operations.DbOperations;
using BookstoreAppWebAPI.Operations.GenreOperations.Create;
using BookStoreAppWebAPI.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.GenreOperations.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTextFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTests(CommonTextFixture textFixture)
        {
            _mapper = textFixture.Mapper;
            _context = textFixture.Context;
        }

        [Fact]
        public void WhenSavedGenreNameGiven_InvalidOperationException_ShouldBeThrew()
        {
            CreateGenreCommand command = new CreateGenreCommand(_context)
            {
                Model = new CreateGenreViewModel()
                {
                    Name = "Novel"
                }
            };

            FluentActions.Invoking(() =>
            {
                command.AddGenre();
            }).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir tür adı mevcut");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            CreateGenreCommand command = new CreateGenreCommand(_context)
            {
                Model = new CreateGenreViewModel()
                {
                    Name = "Test genre name"
                }
            };

            FluentActions.Invoking(() =>
            {
                command.AddGenre();
            }).Invoke();

            _context.Genres.ToList().Find(x => x.Name == command.Model.Name).Should().NotBeNull();
        }

        

    }
}