using System;

namespace MetroClaim.Api.Dtos.Approval;

public record ApprovalRequestDto(
    Guid ManagerId,        // Siapa yang melakukan aksi (karena belum ada Token)
    Guid ReimbursementId,  // Transaksi mana
    string? Comments       // Wajib jika Reject, Opsional jika Approve
);