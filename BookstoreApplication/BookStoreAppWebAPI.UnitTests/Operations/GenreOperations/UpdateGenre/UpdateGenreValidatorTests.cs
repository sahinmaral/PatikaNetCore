using BookstoreAppWebAPI.Operations.GenreOperations.Update;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.GenreOperations.UpdateGenre
{
    public class UpdateGenreValidatorTests
    {
        
        [InlineData(1,"Test genre")]
        [InlineData(0,"Test genre")]
        [InlineData(-1,"Test genre")]
        [InlineData(1,null)]
        [InlineData(1,"")]
        [InlineData(1,"T")]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id,string name)
        {
            UpdateGenreValidator validator = new UpdateGenreValidator();

            ValidationResult result = validator.Validate(new UpdateGenreViewModel()
            {
                Name = name,
                Id = id
            });

            result.Errors.Should().NotBeNull();
        }       
    }
}