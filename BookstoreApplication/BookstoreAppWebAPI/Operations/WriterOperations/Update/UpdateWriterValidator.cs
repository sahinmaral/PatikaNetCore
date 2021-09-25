using System;
using FluentValidation;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Update
{
    public class UpdateWriterValidator : AbstractValidator<UpdateWriterViewModel>
    {
        public UpdateWriterValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id , boş bırakılamaz");

            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now).When(x=>x.DateOfBirth != null)
                .WithMessage("Yazarın doğum tarihini doğru girdiğinize emin olunuz");

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id , 0 'dan büyük olmalıdır");

            RuleFor(x => x.Name).MinimumLength(0).When(x=>x.Name != null).WithMessage("Yazar adı , 0 karakterden büyük olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(0).When(x => x.Surname != null).WithMessage("Yazar soyadı , 0 karakterden büyük olmalıdır");
        }
    }
}
