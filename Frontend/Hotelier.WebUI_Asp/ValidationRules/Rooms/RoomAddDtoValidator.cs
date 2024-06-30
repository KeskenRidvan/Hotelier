using FluentValidation;
using Hotelier.DtoLayer.Rooms;

namespace Hotelier.WebUI_Asp.ValidationRules.Rooms;

public class RoomAddDtoValidator : AbstractValidator<RoomAddDto>
{
    public RoomAddDtoValidator()
    {
        RuleFor(r => r.RoomNumber)
            .NotNull().WithMessage("Oda numarasi bos olamaz!")
            .MinimumLength(3).WithMessage("Oda numarasi minimum 3 karakter olmalidir!");

        RuleFor(r => r.RoomCoverImage)
            .NotNull().WithMessage("Oda resim alani bos olamaz!");

        RuleFor(r => r.Price)
            .NotNull().WithMessage("Oda ucreti bos olamaz!")
            .GreaterThanOrEqualTo(0).WithMessage("Oda ucreti 0 veya 0'dan buyuk olmali!");

        RuleFor(r => r.Title)
            .NotNull().WithMessage("Baslik alani bos olamaz!")
            .MinimumLength(5).WithMessage("Baslik alani minimum 5 karakter olmali!");
    }
}
