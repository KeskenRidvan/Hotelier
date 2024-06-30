using FluentValidation;
using Hotelier.DtoLayer.Bookings;

namespace Hotelier.WebUI_Asp.ValidationRules.Bookings;

public class BookingAddDtoValidator : AbstractValidator<BookingAddDto>
{
    public BookingAddDtoValidator()
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Isim alani bos olamaz!")
            .MinimumLength(2).WithMessage("Isim alani minimum 2 karakter olmali!");

        RuleFor(b => b.Mail)
            .NotEmpty().WithMessage("Mail alani bos olamaz!")
            .EmailAddress().WithMessage("Lutfen gecerli bir mail adresi girin!");
    }
}