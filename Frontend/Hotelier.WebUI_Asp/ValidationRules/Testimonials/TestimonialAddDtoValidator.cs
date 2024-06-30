using FluentValidation;
using Hotelier.DtoLayer.Testimonials;

namespace Hotelier.WebUI_Asp.ValidationRules.Testimonials;

public class TestimonialAddDtoValidator : AbstractValidator<TestimonialAddDto>
{
    public TestimonialAddDtoValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Isim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Isim alani minimum 2 karakter olmalidir!");

        RuleFor(t => t.Title)
            .NotEmpty().WithMessage("Baslik alani bos olamaz!")
            .MinimumLength(2).WithMessage("Baslik alani minimum 2 karakter olmalidir!");

        RuleFor(t => t.Description)
            .NotEmpty().WithMessage("Aciklama alani bos olamaz!")
            .MinimumLength(2).WithMessage("Aciklama alani minimum 2 karakter olmalidir!");
    }
}