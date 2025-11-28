using MetroClaim.Api.Models;

namespace MetroClaim.Api.Dtos.User;

public record UserResponseDto(
    Guid Id,
    string EmployeeId,
    string Fullname,
    string Email,
    UserRole Role,
    string? BankAccountNumber,
    Guid? ManagerId
);