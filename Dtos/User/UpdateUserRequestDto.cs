using System;
using MetroClaim.Api.Models;

namespace MetroClaim.Api.Dtos.User;

public record UpdateUserRequestDto(
    string Fullname,
    string Email,
    UserRole Role,
    string? BankAccountNumber,
    Guid? ManagerId
);