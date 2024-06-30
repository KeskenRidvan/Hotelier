using FluentValidation;
using Hotelier.DtoLayer.AppUsers;

namespace Hotelier.WebUI_Asp.ValidationRules.AppUsers;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Isim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Isim alani minimum 2 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Isim alani sayi iceremez!");

        RuleFor(r => r.Surname)
            .NotEmpty().WithMessage("Soyisim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Soyisim alani minimum 2 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Soyisim alani sayi iceremez!");

        RuleFor(r => r.Username)
            .NotEmpty().WithMessage("Sehir alani bos olamaz!")
            .MinimumLength(2).WithMessage("Sehir alani minimum 3 karakter olmali!");

        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Ulke alani bos olamaz!")
            .MinimumLength(2).WithMessage("Ulke alani minimum 4 karakter olmali!")
            .EmailAddress().WithMessage("Gecerli bir mail adresi girin!");

        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Sifre alani bos olamaz!");

        RuleFor(r => r.ConfirmPassword)
            .NotEmpty().WithMessage("Sifre alani bos olamaz!")
            .Equal(r => r.Password).WithMessage("Sifreler eslesmiyor!");
    }
}