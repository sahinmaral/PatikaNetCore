using BookstoreAppWebAPI.Operations.GenreOperations.Read;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.GenreOperations.ReadGenre
{
    public class ReadGenreValidatorTests
    {

        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(2)]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id)
        {
            ReadGenreValidator validator = new ReadGenreValidator();

            ReadGenreViewModel model = new ReadGenreViewModel()
            {
                Id = id
            };

            ValidationResult result = validator.Validate(model);

            result.Errors.Should().NotBeNull();
        }
    }
}