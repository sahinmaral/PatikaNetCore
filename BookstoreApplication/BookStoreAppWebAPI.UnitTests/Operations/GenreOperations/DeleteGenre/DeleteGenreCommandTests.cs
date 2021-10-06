using System;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.DbOperations;
using BookstoreAppWebAPI.Operations.GenreOperations.Delete;
using BookStoreAppWebAPI.UnitTests.TestSetup;
using FluentAssertions;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public DeleteGenreCommandTests(CommonTextFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidIdWasGiven_InvalidOperationException_ShouldBeThrown()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context)
            {
                Model = new DeleteGenreViewModel()
                {
                    Id = -1
                }
            };

            FluentActions.Invoking(() =>
                {
                    command.DeleteBook();
                }).Should().Throw<InvalidOperationException>().And.Message.Should()
                .Be("Böyle bir tür id'si içeren tür yok");
        }
        
        [Fact]
        public void WhenValidIdWasGiven_Book_ShouldBeDeleted()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context)
            {
                Model = new DeleteGenreViewModel()
                {
                    Id = 1
                }
            };

            FluentActions.Invoking(() =>
                {
                    command.DeleteBook();
                }).Invoke();

             _context.Genres.ToList().Find(x => x.Id == command.Model.Id).Should().BeNull();
             
        }
    }
}