using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.GenreOperations.Delete;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace BookStoreAppWebAPI.UnitTests.Operations.GenreOperations.DeleteGenre
{
    public class DeleteGenreValidatorTests
    {
        
        [InlineData("Writer name",true,0)]
        [InlineData("Writer name",true,-1)]
        [InlineData("",true,0)]
        [InlineData("",true,-1)]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name,bool isActive,int id)
        {
            DeleteGenreValidator validator = new DeleteGenreValidator();

            ValidationResult result = validator.Validate(new DeleteGenreViewModel()
            {
                Id = id,
                Name = name,
                IsActive = isActive
            });

            result.Errors.Should().NotBeNull();
        }       
    }
}