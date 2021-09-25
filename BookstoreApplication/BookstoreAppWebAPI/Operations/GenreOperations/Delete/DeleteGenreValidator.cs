using BookstoreAppWebAPI.Operations.BookOperations.Delete;
using FluentValidation;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Delete
{
    public class DeleteGenreValidator:AbstractValidator<DeleteGenreViewModel>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");


            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0'dan büyük olmalıdır");
        }
    }
}
