using FluentValidation;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Read
{
    public class ReadWriterValidator : AbstractValidator<ReadWriterViewModel>
    {
        public ReadWriterValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0'dan büyük olmalıdır");
        }
    }
}
