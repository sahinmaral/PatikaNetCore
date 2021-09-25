using FluentValidation;

namespace BookstoreAppWebAPI.Operations.BookOperations.Delete
{
    public class DeleteBookValidator:AbstractValidator<DeleteBookViewModel>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");


            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0'dan büyük olmalıdır");
        }
    }
}
