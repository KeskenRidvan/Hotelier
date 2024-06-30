using FluentValidation;
using Hotelier.DtoLayer.Subscribes;

namespace Hotelier.WebUI_Asp.ValidationRules.Subscribes;

public class SubscribeAddDtoValidator : AbstractValidator<SubscribeAddDto>
{
    public SubscribeAddDtoValidator()
    {
        RuleFor(s => s.Mail)
            .NotEmpty().WithMessage("Mail alani bos olamaz!")
            .EmailAddress().WithMessage("Gecerli bir mail adresi girin!");
    }
}