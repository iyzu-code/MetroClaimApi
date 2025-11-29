using System;

namespace MetroClaim.Api.Dtos.Finance;

public record FinanceApprovalRequestDto(
    Guid FinanceId,       // User Finance yang eksekusi
    Guid ReimbursementId,
    string? Comments
);