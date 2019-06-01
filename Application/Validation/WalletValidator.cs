using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
    public class WalletValidator: AbstractValidator<WalletDTO>
    {
        public WalletValidator()
        {
            RuleFor(w => w.Amount).NotEmpty().NotNull().InclusiveBetween(500, 100000);
        }
    }
}