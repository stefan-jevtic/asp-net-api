using Application.DTO;
using FluentValidation;

namespace Application.Validation
{
    public class AuthorValidor : AbstractValidator<AuthorDTO>
    {
        public AuthorValidor()
        {
            RuleFor(a => a.FullName).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}