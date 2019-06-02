using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
    public class CartValidator : AbstractValidator<CartDTO>
    {
        public CartValidator()
        {
            RuleFor(c => c.BookId).GreaterThan(0).Unless(c => !c.BookId.Equals(0));
            RuleFor(c => c.Id).GreaterThan(0).Unless(c => !c.Id.Equals(0));
            RuleFor(c => c.Quantity).InclusiveBetween(1, 10).Unless(c => !c.Quantity.Equals(0));
        }
    }
}

/*
 *
 * TODO: NASTELOVATI USLOVE!!!11
 * 
 */