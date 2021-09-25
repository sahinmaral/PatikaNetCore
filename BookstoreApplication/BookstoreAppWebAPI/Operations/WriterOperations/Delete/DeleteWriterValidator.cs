using FluentValidation;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Delete
{
    public class DeleteWriterValidator:AbstractValidator<DeleteWriterViewModel>
    {
        public DeleteWriterValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");


            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0'dan büyük olmalıdır");
        }
    }
}
