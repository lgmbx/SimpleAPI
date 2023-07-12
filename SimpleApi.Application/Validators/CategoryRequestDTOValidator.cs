using FluentValidation;
using SimpleApi.Application.DTOs.RequestDTO;

namespace SimpleApi.Application.Validators
{
    public class CategoryRequestDTOValidator : AbstractValidator<CategoryRequestDTO>
    {

        public CategoryRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");
        }

    }
}
