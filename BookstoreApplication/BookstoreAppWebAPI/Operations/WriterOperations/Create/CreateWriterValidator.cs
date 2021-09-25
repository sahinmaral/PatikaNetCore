using System;
using FluentValidation;

namespace BookstoreAppWebAPI.Operations.WriterOperations.Create
{
    public class CreateWriterValidator:AbstractValidator<CreateWriterViewModel>
    {
        public CreateWriterValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Yazar adı boş bırakılamaz");
            RuleFor(x => x.DateOfBirth).NotNull().WithMessage("Yazarın doğum tarihi boş bırakılamaz");
            
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Tür adı , 2 karakterden uzun olmalıdır");

            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now)
                .WithMessage("Yazarın doğum tarihini doğru girdiğinize emin olunuz");

        }
    }
}
