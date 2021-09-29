using System;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.GenreOperations.Update;
using BookStoreAppWebAPI.UnitTests.TestSetup;
using FluentAssertions;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandTests:IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public UpdateGenreCommandTests(CommonTextFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidIdWasGiven_InvalidOperationException_ShouldBeThrown()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context)
            {
                Model = new UpdateGenreViewModel()
                {
                    Id = -1
                }
            };

            FluentActions.Invoking(() =>
                {
                    command.UpdateGenre();
                }).Should().Throw<InvalidOperationException>().And.Message.Should()
                .Be("Böyle bir tür id'si olan tür yok");
        }
        
        [Fact]
        public void WhenValidIdWasGiven_Book_ShouldBeUpdated()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context)
            {
                Model = new UpdateGenreViewModel()
                {
                    Id = 1,
                    Name = "Test genre name"
                }
            };

            FluentActions.Invoking(() =>
                {
                    command.UpdateGenre();
                }).Invoke();

            Genre searchedGenre = _context.Genres.ToList().Find(x => x.Id == command.Model.Id);
            searchedGenre.Should().NotBeNull();
            searchedGenre.Name.Should().Be(command.Model.Name);


        }
    }
}