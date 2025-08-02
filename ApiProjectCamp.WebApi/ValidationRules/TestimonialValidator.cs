using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.TestimonialTitle).NotEmpty().WithMessage("Referans adını boş geçmeyin");
            RuleFor(x => x.TestimonialTitle).MinimumLength(2).WithMessage("En az 2 karakter veri girişi yapın!");
            RuleFor(x => x.TestimonialTitle).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın!");
        }
    }
}
