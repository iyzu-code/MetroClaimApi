using System;

namespace MetroClaim.Api.Dtos.Approval;

public record PendingApprovalDto(
    Guid Id,
    string EmployeeName,   // Nama Bawahan
    string Category,
    string Title,
    decimal Amount,
    DateTime DateOfExpense,
    DateTime CreatedAt
);