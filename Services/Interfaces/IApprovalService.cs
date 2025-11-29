using System;
using MetroClaim.Api.Dtos.Approval;

namespace MetroClaim.Api.Services.Interfaces;

public interface IApprovalService
{
    // List tugas Manager
    Task<IEnumerable<PendingApprovalDto>> GetPendingManagerApprovalsAsync(Guid managerId, CancellationToken cancellationToken);
    
    // Aksi Manager
    Task ApproveByManagerAsync(ApprovalRequestDto requestDto, CancellationToken cancellationToken);
    Task RejectByManagerAsync(ApprovalRequestDto requestDto, CancellationToken cancellationToken);
}