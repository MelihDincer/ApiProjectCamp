using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.ServiceTitle).NotEmpty().MinimumLength(8).WithMessage("Başlığı minimum 8 karakter olarak girmelisiniz.").MaximumLength(200).WithMessage("Başlığı maksimum 200 karakter olarak girmelisiniz.");
            RuleFor(x => x.ServiceDescription).NotEmpty().MinimumLength(8).WithMessage("Açıklamayı minimum 8 karakter olarak girmelisiniz.").MaximumLength(200).WithMessage("Açıklamayı maksimum 200 karakter olarak girmelisiniz.");
            RuleFor(x => x.ServiceIconUrl).NotEmpty().WithMessage("Icon boş olamaz.");
        }
    }
}
