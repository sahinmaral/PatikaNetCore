using System;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.BookOperations.Create;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.CreateBook
{
    public class CreateBookValidationTests
    {
        [Theory]
        [InlineData("Lord Of The Rings",0,0)]
        [InlineData("",0,0)]
        [InlineData("Cerrah",-1,0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title,int genreId,int writerId)
        {
            var book = new Book()
            {
                Title = title,
                GenreId = genreId,
                WriterId = writerId
            };

            CreateBookViewModel viewModel = new CreateBookViewModel()
            {
                Title = book.Title,
                GenreId = book.GenreId,
                WriterId = book.WriterId
            };

            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(viewModel);

            result.Errors.Should().NotBeEmpty();
        }

        
        [Fact]
        public void WhenDateTimeNowIsGiven_Validator_ShouldBeReturnError()
        {
            var book = new Book()
            {
                Title = "Cerrah",
                GenreId = 1,
                WriterId = 1,
                PublishDate = DateTime.Now
            };

            CreateBookViewModel viewModel = new CreateBookViewModel()
            {
                Title = book.Title,
                GenreId = book.GenreId,
                WriterId = book.WriterId
            };

            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(viewModel);

            result.Errors.Should().NotBeEmpty();
        }

    }
}
