using FluentValidation;
using SimpleApi.Application.DTOs.RequestDTO;

namespace SimpleApi.Application.Validators
{
    public class UserRequestDTOValidator : AbstractValidator<UserRequestDTO>
    {
        public UserRequestDTOValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters")
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(x => x.Role)
                .IsInEnum()
                .WithMessage("Role is required");
        }
    }
}
