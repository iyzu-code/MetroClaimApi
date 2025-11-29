using System;

namespace MetroClaim.Api.Dtos.Finance;

public record PaymentExecutionDto(
    Guid FinanceId,       // User Finance yang transfer
    Guid ReimbursementId,
    decimal AmountPaid,   // Bisa jadi beda dgn pengajuan (misal potong pajak/admin)
    string ReferenceNumber // Bukti transfer bank
);