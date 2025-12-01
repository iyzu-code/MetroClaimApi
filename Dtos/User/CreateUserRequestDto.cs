using MetroClaim.Api.Models;

namespace MetroClaim.Api.Dtos.User;

public record CreateUserRequestDto(
    string EmployeeId,
    string Fullname,
    string Email,
    string Password,
    string PasswordConfirmation,
    UserRole Role,
    string? BankAccountNumber,
    Guid? ManagerId
);