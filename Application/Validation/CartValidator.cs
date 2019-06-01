using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
    public class CartValidator : AbstractValidator<CartDTO>
    {
        public CartValidator()
        {
            RuleFor(c => c.DishId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(c => c.Quantity).InclusiveBetween(1, 10).NotEmpty().NotNull();
        }
    }
}