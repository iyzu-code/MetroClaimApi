namespace MetroClaim.Api.Dtos.Approval;

public record ApprovalRequestDto(
    Guid ManagerId,
    Guid ReimbursementId,
    string? Comments
);