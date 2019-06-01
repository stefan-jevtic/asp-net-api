using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
    public class UserValidator : AbstractValidator<AuthDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty().NotNull().Length(2, 20);
            RuleFor(u => u.LastName).NotEmpty().NotNull().Length(2, 20);
            RuleFor(u => u.Password).NotEmpty().NotNull().Length(5, 20);
        }
    }
}