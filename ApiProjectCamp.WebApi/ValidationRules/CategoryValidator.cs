using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Categori adı boş geçilemez!").MaximumLength(100).WithMessage("Maksimum 100 karakter girişi yapabilirsiniz!").MinimumLength(3).WithMessage("Minimum 3 karakter veri giriniz!");
        }
    }
}
