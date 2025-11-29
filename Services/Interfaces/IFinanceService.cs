using System;
using MetroClaim.Api.Dtos.Finance;

namespace MetroClaim.Api.Services.Interfaces;

public interface IFinanceService
{
    // GET Lists
    Task<IEnumerable<FinanceTaskDto>> GetPendingApprovalsAsync(CancellationToken cancellationToken);
    Task<IEnumerable<FinanceTaskDto>> GetPendingPaymentsAsync(CancellationToken cancellationToken);

    // Actions
    Task ApproveAsync(FinanceApprovalRequestDto requestDto, CancellationToken cancellationToken);
    Task RejectAsync(FinanceApprovalRequestDto requestDto, CancellationToken cancellationToken);
    Task PayAsync(PaymentExecutionDto requestDto, CancellationToken cancellationToken);
}