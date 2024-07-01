using FluentValidation;
using Hotelier.DtoLayer.SendMessages;

namespace Hotelier.WebUI_Asp.ValidationRules.SendMessages;

public class SendMessageAddDtoValidator : AbstractValidator<SendMessageAddDto>
{
    public SendMessageAddDtoValidator()
    {
        RuleFor(sm => sm.ReceiverName)
            .NotEmpty().WithMessage("Alici adi bos olamaz!")
            .MinimumLength(2).WithMessage("Alici adi minimum 2 karakter olmalidir!");

        RuleFor(sm => sm.ReceiverMail)
            .NotEmpty().WithMessage("Alici maili bos olamaz!")
            .EmailAddress().WithMessage("Gecerli bir mail adresi girin!");

        RuleFor(sm => sm.SenderName)
          .NotEmpty().WithMessage("Gonderen adi bos olamaz!")
          .MinimumLength(2).WithMessage("Gonderen adi minimum 2 karakter olmalidir!");

        RuleFor(sm => sm.SenderMail)
            .NotEmpty().WithMessage("Gonderen maili bos olamaz!")
            .EmailAddress().WithMessage("Gecerli bir mail adresi girin!");

        RuleFor(sm => sm.Title)
            .NotEmpty().WithMessage("Baslik alani bos olamaz!")
            .MinimumLength(5).WithMessage("Baslik adi minimum 5 karakter olmalidir!");

        RuleFor(sm => sm.Content)
            .NotEmpty().WithMessage("Icerik alani bos olamaz!")
            .MinimumLength(10).WithMessage("Icerik adi minimum 10 karakter olmalidir!");
    }
}