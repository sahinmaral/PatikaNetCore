using System;
using FluentValidation;

namespace BookstoreAppWebAPI.BookOperations.Create
{
    public class CreateBookValidator:AbstractValidator<CreateBookViewModel>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.Description).NotNull().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.GenreId).NotNull().WithMessage("Tür Id boş bırakılamaz");
            RuleFor(x => x.PublishDate).NotNull().WithMessage("Yayınlandığı tarih boş bırakılamaz");
            RuleFor(x => x.WriterId).NotNull().WithMessage("Yazar Id boş bırakılamaz");

            RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("Tür Id , 0'dan büyük olmalıdır");
            RuleFor(x => x.WriterId).GreaterThan(0).WithMessage("Tür Id , 0'dan büyük olmalıdır");
            
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık , 5 karakterden uzun olmalıdır");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Açıklama , 5 karakterden uzun olmalıdır");

            RuleFor(x => x.PublishDate).NotEmpty().LessThan(DateTime.Now)
                .WithMessage("Yayınlandığı tarih , bugünun tarihinden küçük olmalıdır");
        }
    }
}