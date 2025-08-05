using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x=>x.NotificationDescription).NotEmpty().WithMessage("Bildirim açıklaması boş geçilemez!").MaximumLength(250).WithMessage("Maksimum 250 karakter girişi yapabilirsiniz!");
        }
    }
}
