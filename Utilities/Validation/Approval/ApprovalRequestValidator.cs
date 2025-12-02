using FluentValidation;
using MetroClaim.Api.Dtos.Approval;

namespace MetroClaim.Api.Utilities.Validation.Approval;

public class ApprovalRequestValidator : AbstractValidator<ApprovalRequestDto>
{
    public ApprovalRequestValidator()
    {
        RuleFor(x => x.ManagerId)
            .NotEmpty().WithMessage("Manager ID is required");

        RuleFor(x => x.ReimbursementId)
            .NotEmpty().WithMessage("Reimbursement ID is required");

        RuleFor(x => x.Comments)
            .MaximumLength(500).WithMessage("Comments cannot exceed 500 characters");
    }
}