using FluentValidation;
using MetroClaim.Api.Dtos.Category;

namespace MetroClaim.Api.Utilities.Validation.Category;

public class CategoryRequestValidator : AbstractValidator<CategoryRequestDto>
{
    public CategoryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("name is required");
    }
}
