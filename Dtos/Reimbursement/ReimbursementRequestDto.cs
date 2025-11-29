using System;

namespace MetroClaim.Api.Dtos.Reimbursement;

public record ReimbursementRequestDto(
    Guid UserId,
    Guid CategoryId,
    string Title,
    string Description,
    decimal Amount,
    DateTime DateOfExpense,
    string Receipt // Base64 String
);
