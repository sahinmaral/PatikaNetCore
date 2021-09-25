using FluentValidation;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Update
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreViewModel>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");

            RuleFor(x => x.Name).NotNull().WithMessage("Tür ismi , boş bırakılamaz");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Tür ismi , 2 karakterden büyük olmalıdır");
        }
    }
}
