using FluentValidation;

namespace BookstoreAppWebAPI.Operations.GenreOperations.Read
{
    public class ReadGenreValidator : AbstractValidator<ReadGenreViewModel>
    {
        public ReadGenreValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");


            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0'dan büyük olmalıdır");
        }
    }
}
