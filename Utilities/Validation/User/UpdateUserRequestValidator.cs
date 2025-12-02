using FluentValidation;
using MetroClaim.Api.Dtos.User;
using MetroClaim.Api.Models;

namespace MetroClaim.Api.Utilities.Validation.User;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequestDto>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Fullname)
            .NotEmpty().WithMessage("Full name is required")
            .MaximumLength(100).WithMessage("Full name max 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Invalid user role");

        RuleFor(x => x.BankAccountNumber)
            .NotEmpty().WithMessage("Bank account number is required")
            .Matches(@"^\d+$").WithMessage("Bank account number must contain only digits");

        RuleFor(x => x.ManagerId)
            .NotEmpty()
            .When(x => x.Role != UserRole.Admin)
            .WithMessage("Manager ID is required for non-admin users");
    }
}