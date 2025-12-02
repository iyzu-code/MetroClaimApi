namespace MetroClaim.Api.Dtos.Finance;

public record FinanceApprovalRequestDto(
    Guid FinanceId,
    Guid ReimbursementId,
    string? Comments
);