using FluentValidation;
using Hotelier.DtoLayer.Staffs;

namespace Hotelier.WebUI_Asp.ValidationRules.Staffs;

public class StaffAddDtoValidator : AbstractValidator<StaffAddDto>
{
    public StaffAddDtoValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Isim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Isim alani minimum 2 karakter olmali!");

        RuleFor(s => s.Title)
            .NotEmpty().WithMessage("Baslik alani bos olamaz!")
            .MinimumLength(2).WithMessage("Baslik alani minimum 2 karakter olmali!");
    }
}