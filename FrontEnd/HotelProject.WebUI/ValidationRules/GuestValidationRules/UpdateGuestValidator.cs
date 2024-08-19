using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakter veri girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla 20 karakter veri girişi yapınız");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("En az 3 karakter veri girişi yapınız");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("En fazla 30 karakter veri girişi yapınız");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("En az 3 karakter veri girişi yapınız");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("En fazla 20 karakter veri girişi yapınız");
        }
    }
}
