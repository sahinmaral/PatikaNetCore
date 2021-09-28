using BookstoreAppWebAPI.Operations.BookOperations.Delete;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.DeleteBook
{
    public class DeleteBookValidatorTests
    {
        [Theory]
        [InlineData("Test book", 0)]
        [InlineData("Test book", -1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string title, int id)
        {
            DeleteBookValidator validator = new DeleteBookValidator();

            DeleteBookViewModel model = new DeleteBookViewModel()
            {
                Title = title,
                Id = id
            };

            ValidationResult result = validator.Validate(model);

            result.Errors.Should().NotBeNull();
        }
    }
}