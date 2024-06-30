using FluentValidation;
using Hotelier.DtoLayer.Guests;

namespace Hotelier.WebUI_Asp.ValidationRules.Guests;
public class GuestAddDtoValidator : AbstractValidator<GuestAddDto>
{
    public GuestAddDtoValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("Isim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Isim alani minimum 2 karakter olmalidir!");

        RuleFor(g => g.Surname)
           .NotEmpty().WithMessage("Soyisim alani bos olamaz!")
           .MinimumLength(2).WithMessage("Soyisim alani minimum 2 karakter olmalidir!");

        RuleFor(g => g.City)
           .NotEmpty().WithMessage("Sehir alani bos olamaz!")
           .MinimumLength(2).WithMessage("Sehir alani minimum 2 karakter olmalidir!");
    }
}