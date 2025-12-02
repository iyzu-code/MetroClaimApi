using FluentValidation;
using MetroClaim.Api.Dtos.Finance;

namespace MetroClaim.Api.Utilities.Validation.Finance;

public class FinanceApprovalRequestValidator : AbstractValidator<FinanceApprovalRequestDto>
{
    public FinanceApprovalRequestValidator()
    {
        RuleFor(x => x.FinanceId)
            .NotEmpty().WithMessage("Finance ID is required");

        RuleFor(x => x.ReimbursementId)
            .NotEmpty().WithMessage("Reimbursement ID is required");

        RuleFor(x => x.Comments)
            .MaximumLength(500).WithMessage("Comments cannot exceed 500 characters");
    }
}