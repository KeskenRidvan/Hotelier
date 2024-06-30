using FluentValidation;
using Hotelier.DtoLayer.Abouts;

namespace Hotelier.WebUI_Asp.ValidationRules.Abouts;
public class AboutUpdateDtoValidator : AbstractValidator<AboutUpdateDto>
{
    public AboutUpdateDtoValidator()
    {
        RuleFor(a => a.AboutID)
            .NotEmpty().WithMessage("Id alani bos olamaz!");

        RuleFor(a => a.Title1)
            .NotEmpty().WithMessage("Baslik alani bos gecilemez!")
            .MinimumLength(5).WithMessage("Baslik alani en az 5 karakter olmalidir gecilemez!");

        RuleFor(a => a.Title2)
            .NotEmpty().WithMessage("Baslik alani bos gecilemez!")
            .MinimumLength(5).WithMessage("Baslik alani en az 5 karakter olmalidir gecilemez!");

        RuleFor(a => a.Content)
            .NotEmpty().WithMessage("Icerik alani bos gecilemez!")
            .MinimumLength(5).WithMessage("Icerik alani en az 5 karakter olmalidir gecilemez!");

        RuleFor(a => a.RoomCount)
            .GreaterThan(0).WithMessage("Oda sayisi 0'dan buyuk olmali!");

        RuleFor(a => a.StaffCount)
            .GreaterThan(0).WithMessage("Personel sayisi 0'dan buyuk olmali!");

        RuleFor(a => a.CustomerCount)
            .GreaterThan(0).WithMessage("Musteri sayisi 0'dan buyuk olmali!");
    }
}