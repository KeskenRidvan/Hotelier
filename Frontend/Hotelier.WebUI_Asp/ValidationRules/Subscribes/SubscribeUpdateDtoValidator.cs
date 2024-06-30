using FluentValidation;
using Hotelier.DtoLayer.Subscribes;

namespace Hotelier.WebUI_Asp.ValidationRules.Subscribes;

public class SubscribeUpdateDtoValidator : AbstractValidator<SubscribeUpdateDto>
{
    public SubscribeUpdateDtoValidator()
    {
        RuleFor(s => s.SubscribeID)
            .NotEmpty().WithMessage("Id alani bos olamaz!");

        RuleFor(s => s.Mail)
            .NotEmpty().WithMessage("Mail alani bos olamaz!")
            .EmailAddress().WithMessage("Gecerli bir mail adresi girin!");
    }
}