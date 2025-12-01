using FluentValidation;
using MetroClaim.Api.Dtos.Reimbursement;

namespace MetroClaim.Api.Utilities.Validation.Reimbursement;

public class ReimbursementRequestValidator : AbstractValidator<ReimbursementRequestDto>
{
    public ReimbursementRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category ID is required");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0");
            
        RuleFor(x => x.DateOfExpense)
            .NotEmpty().WithMessage("Date of expense is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Date of expense cannot be in the future");

        RuleFor(x => x.Receipt)
            .NotEmpty().WithMessage("Receipt (Base64 image) is required")
            .Must(BeValidBase64).WithMessage("Receipt must be a valid Base64 string");
    }

    private bool BeValidBase64(string base64String)
    {
        if (string.IsNullOrWhiteSpace(base64String)) return false;
        
        if (base64String.Contains(','))
        {
            base64String = base64String.Split(',')[1];
        }

        Span<byte> buffer = new Span<byte>(new byte[base64String.Length]);
        return Convert.TryFromBase64String(base64String, buffer, out _);
    }
}