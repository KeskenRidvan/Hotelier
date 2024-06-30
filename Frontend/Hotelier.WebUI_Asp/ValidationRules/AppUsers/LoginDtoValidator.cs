using FluentValidation;
using Hotelier.DtoLayer.AppUsers;

namespace Hotelier.WebUI_Asp.ValidationRules.AppUsers;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Sifre alani bos olamaz");

        RuleFor(l => l.Username)
             .NotEmpty().WithMessage("Kullanici adi bos olamaz");
    }
}