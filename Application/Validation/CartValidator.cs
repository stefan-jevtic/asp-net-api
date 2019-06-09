using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
    public class CartValidator : AbstractValidator<InsertCartDTO>
    {
        public CartValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0);
            RuleFor(c => c.Quantity).InclusiveBetween(1, 20);
        }
    }
}