using System;
using MetroClaim.Api.Models;

namespace MetroClaim.Api.Dtos.Reimbursement;

public record ReimbursementResponseDto(
    Guid Id,
    string CategoryName,
    string Title,
    decimal Amount,
    DateTime DateOfExpense,
    ReimbursementStatus Status,
    DateTime CreatedAt
);