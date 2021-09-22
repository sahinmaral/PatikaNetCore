using BookstoreAppWebAPI.BookOperations.Update;
using FluentValidation;

namespace BookstoreAppWebAPI.BookOperations.Read
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookViewModel>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");

            RuleFor(x => x.GenreId).NotNull().WithMessage("Tür Id , boş bırakılamaz");
            RuleFor(x => x.WriterId).NotNull().WithMessage("Yazar Id , boş bırakılamaz");

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0'dan büyük olmalıdır");
            RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("Tür Id , 0'dan büyük olmalıdır");
            RuleFor(x => x.WriterId).GreaterThan(0).WithMessage("Yazar Id , 0'dan büyük olmalıdır");
        }
    }
}
