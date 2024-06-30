using FluentValidation;
using Hotelier.DtoLayer.Contacts;

namespace Hotelier.WebUI_Asp.ValidationRules.Contacts;

public class ContactAddDtoValidator : AbstractValidator<ContactAddDto>
{
    public ContactAddDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Isim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Isim alani minimum 2 karakter olmali!");

        RuleFor(c => c.Mail)
            .NotEmpty().WithMessage("Mail alani bos olamaz!")
            .EmailAddress().WithMessage("Gecerli mail adresi girin!");

        RuleFor(c => c.Subject)
            .NotEmpty().WithMessage("Konu alani bos olamaz!")
            .MinimumLength(2).WithMessage("Konu alani minimum 2 karakter olmali!");

        RuleFor(c => c.Message)
           .NotEmpty().WithMessage("Mesaj alani bos olamaz!")
           .MinimumLength(2).WithMessage("Mesaj alani minimum 2 karakter olmali!");
    }
}