using System;

namespace MetroClaim.Api.Dtos.Finance;

public record FinanceTaskDto(
    Guid Id,
    string EmployeeName,
    string Category,
    string Title,
    decimal Amount,
    DateTime DateOfExpense,
    DateTime CreatedAt
);