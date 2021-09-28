using BookstoreAppWebAPI.Operations.BookOperations.Update;

using BookStoreAppWebAPI.UnitTests.TestSetup;

using FluentAssertions;

using FluentValidation.Results;

using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.UpdateBook
{
    public class UpdateBookValidatorTests:IClassFixture<CommonTextFixture>
    {

        [InlineData("Test book","Nice book",0,0)]
        [InlineData("Test book","Nice book",0,1)]
        [InlineData("Test book","Nice book",1,-1)]
        [InlineData("Test book","Nice book",-1,-1)]
        [Theory]
        public void WhenInvalidInputsAreTaken_Validator_ShouldReturnErrors(string title,string description,int genreId,int writerId)
        {

            UpdateBookViewModel model = new UpdateBookViewModel()
            {
                Title = title,
                Description = description,
                GenreId = genreId,
                WriterId = writerId
            };

            UpdateBookValidator validator = new UpdateBookValidator();

            ValidationResult result = validator.Validate(model);

            result.Errors.Should().NotBeEmpty();
        }

    }
}
