using MetroClaim.Api.Models;

namespace MetroClaim.Api.Dtos.Reimbursement;

public record ApprovalLogDto(
    string ActionBy,
    ReimbursementStatus Action,
    string? Comments,
    DateTime CreatedAt
);