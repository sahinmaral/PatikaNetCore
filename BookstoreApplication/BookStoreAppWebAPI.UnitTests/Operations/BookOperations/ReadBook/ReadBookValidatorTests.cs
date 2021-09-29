using BookstoreAppWebAPI.Operations.BookOperations.Read;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.BookOperations.ReadBook
{
    public class ReadBookValidatorTests
    {

        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(2)]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id)
        {
            ReadBookValidator validator = new ReadBookValidator();

            ReadBookViewModel model = new ReadBookViewModel()
            {
                Id = id
            };

            ValidationResult result = validator.Validate(model);

            result.Errors.Should().NotBeNull();
        }
    }
}