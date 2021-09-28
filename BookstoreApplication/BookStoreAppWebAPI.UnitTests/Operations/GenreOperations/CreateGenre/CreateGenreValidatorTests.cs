using BookstoreAppWebAPI.Operations.GenreOperations.Create;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.GenreOperations.CreateGenre
{
    public class CreateGenreValidatorTests
    {
        
        [InlineData("",false)]
        [InlineData(null,true)]
        [InlineData(null,false)]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name,bool isActive)
        {
            CreateGenreValidator validator = new CreateGenreValidator();

            ValidationResult result = validator.Validate(new CreateGenreViewModel()
            {
                Name = name,
                IsActive = isActive
            });

            result.Errors.Should().NotBeNull();
        }       
    }
}