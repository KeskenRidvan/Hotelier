using FluentValidation;
using Hotelier.DtoLayer.Services;

namespace Hotelier.WebUI_Asp.ValidationRules.Services;

public class ServiceAddDtoValidator : AbstractValidator<ServiceAddDto>
{
    public ServiceAddDtoValidator()
    {
        RuleFor(s => s.ServiceIcon)
            .NotEmpty().WithMessage("Ikon alani bos olamaz!");

        RuleFor(s => s.Title)
            .NotEmpty().WithMessage("Baslik alani bos olamaz!")
            .MinimumLength(2).WithMessage("Baslik alani minimum 2 karakter olmali!");

        RuleFor(s => s.Description)
            .NotEmpty().WithMessage("Aciklama alani bos olamaz!")
            .MinimumLength(2).WithMessage("Aciklama alani minimum 2 karakter olmali!");
    }
}
