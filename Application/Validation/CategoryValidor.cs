using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
    public class CategoryValidor : AbstractValidator<CategoryDTO>
    {
        public CategoryValidor()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}