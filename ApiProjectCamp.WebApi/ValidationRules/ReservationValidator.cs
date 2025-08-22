using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.ReservationNameSurname).NotEmpty().WithMessage("Rezervasyon ad soyad bilgisini boş geçmeyin");
            RuleFor(x => x.ReservationEmail).NotEmpty().WithMessage("Rezervasyon mail bilgisini boş geçmeyin");
            RuleFor(x => x.ReservationPhoneNumber).NotEmpty().WithMessage("Rezervasyon telefon bilgisini boş geçmeyin");
            RuleFor(x => x.ReservationNameSurname).MinimumLength(2).WithMessage("En az 10 karakter veri girişi yapın!");
            RuleFor(x => x.ReservationNameSurname).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın!");
            RuleFor(x => x.ReservationCountOfPeople).GreaterThan(-1).WithMessage("Sayı negatif olamaz.");
        }
    }
}
