using FluentValidation;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Create
{
    public class CreateGenreValidator:AbstractValidator<CreateGenreViewModel>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Tür adı boş bırakılamaz");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Tür adı , 2 karakterden uzun olmalıdır");
        }
    }
}
