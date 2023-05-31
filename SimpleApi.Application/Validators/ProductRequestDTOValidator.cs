using FluentValidation;
using SimpleApi.Application.DTOs.RequestDTO;

namespace SimpleApi.Application.Validators
{
    public class ProductRequestDTOValidator : AbstractValidator<ProductRequestDTO>
    {
        public ProductRequestDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category Id is required");
        }
    }
}
