using FluentValidation;
using MetroClaim.Api.Dtos.User;
using MetroClaim.Api.Models;

namespace MetroClaim.Api.Utilities.Validation.User;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequestDto>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEmpty().WithMessage("Employee ID is required")
            .MaximumLength(50).WithMessage("Employee ID max 50 characters");

        RuleFor(x => x.Fullname)
            .NotEmpty().WithMessage("Full Name is required")
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches(@"\d").WithMessage("Password must contain at least one number")
            .Matches(@"[^\w]").WithMessage("Password must contain at least one special character");


        RuleFor(x => x.PasswordConfirmation)
            .NotEmpty().WithMessage("Password confirmation is required")
            .Equal(x => x.Password).WithMessage("Passwords do not match");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Invalid user role");

        RuleFor(x => x.BankAccountNumber)
            .NotEmpty().WithMessage("Bank Account Number is required")
            .Matches(@"^\d+$").WithMessage("Bank Account Number must contain only digits");

        RuleFor(x => x.ManagerId)
            .NotEmpty()
            .When(x => x.Role != UserRole.Admin)
            .WithMessage("Manager ID is required for non-admin users.");
    }
}