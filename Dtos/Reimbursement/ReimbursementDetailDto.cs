using System;
using MetroClaim.Api.Models;

namespace MetroClaim.Api.Dtos.Reimbursement;

public record ReimbursementDetailDto(
    Guid Id,
    string CategoryName,
    string Title,
    string Description,
    decimal Amount,
    DateTime DateOfExpense,
    string Receipt,
    ReimbursementStatus Status,
    string? RejectionReason,
    DateTime CreatedAt,
    IEnumerable<ApprovalLogDto> Logs
);