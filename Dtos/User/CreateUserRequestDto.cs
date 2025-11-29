using MetroClaim.Api.Models;

namespace MetroClaim.Api.Dtos.User;

public record CreateUserRequestDto(
    string EmployeeId,
    string Fullname,
    string Email,
    string Password,
    UserRole Role,
    string? BankAccountNumber,
    Guid? ManagerId
);