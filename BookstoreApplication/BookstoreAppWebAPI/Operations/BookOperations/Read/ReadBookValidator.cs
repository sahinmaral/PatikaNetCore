using BookstoreAppWebAPI.BookOperations.Read;
using FluentValidation;

namespace BookstoreAppWebAPI.Operations.BookOperations.Read
{
    public class ReadBookValidator:AbstractValidator<ReadBookViewModel>
    {
        public ReadBookValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");


            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0'dan büyük olmalıdır");
        }
    }
}
