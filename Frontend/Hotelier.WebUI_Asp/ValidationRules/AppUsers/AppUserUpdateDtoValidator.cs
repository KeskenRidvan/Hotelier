using FluentValidation;
using Hotelier.DtoLayer.AppUsers;

namespace Hotelier.WebUI_Asp.ValidationRules.AppUsers;

public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
{
    public AppUserUpdateDtoValidator()
    {
        RuleFor(au => au.AppUserId)
            .NotEmpty().WithMessage("Id alanşi bos olamaz!");

        RuleFor(au => au.Name)
            .NotEmpty().WithMessage("Isim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Isim alani minimum 2 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Isim alani sayi iceremez!");

        RuleFor(au => au.Surname)
            .NotEmpty().WithMessage("Soyisim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Soyisim alani minimum 2 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Soyisim alani sayi iceremez!");

        RuleFor(au => au.City)
            .NotEmpty().WithMessage("Sehir alani bos olamaz!")
            .MinimumLength(2).WithMessage("Sehir alani minimum 3 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Sehir alani sayi iceremez!");

        RuleFor(au => au.ImageUrl)
            .NotEmpty().WithMessage("Resim alani bos olamaz!");

        RuleFor(au => au.Country)
            .NotEmpty().WithMessage("Ulke alani bos olamaz!")
            .MinimumLength(2).WithMessage("Ulke alani minimum 4 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Ulke alani sayi iceremez!");

        RuleFor(au => au.Gender)
            .NotEmpty().WithMessage("Cinsiyet alani bos olamaz!")
            .MinimumLength(2).WithMessage("Cinsiyet alani minimum 3 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Cinsiyet alani sayi iceremez!");

        RuleFor(au => au.WorkDepartment)
            .NotEmpty().WithMessage("Calisan departman alani bos olamaz!")
            .MinimumLength(2).WithMessage("Calisan departman alani minimum 3 karakter olmali!")
            .Matches(@"^[^0-9]*$").WithMessage("Calisan departman alani sayi iceremez!");
    }
}