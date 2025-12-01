using MetroClaim.Api.Dtos.Finance;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositories;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;

namespace MetroClaim.Api.Services;

public class FinanceService : IFinanceService
{
    private readonly IReimbursementRepository _reimbursementRepository;
    private readonly IApprovalLogRepository _approvalLogRepository;
    private readonly IDisbursementRepository _disbursementRepository; // Repo baru
    private readonly IUnitOfWork _unitOfWork;

    public FinanceService(
        IReimbursementRepository reimbursementRepository,
        IApprovalLogRepository approvalLogRepository,
        IDisbursementRepository disbursementRepository,
        IUnitOfWork unitOfWork)
    {
        _reimbursementRepository = reimbursementRepository;
        _approvalLogRepository = approvalLogRepository;
        _disbursementRepository = disbursementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<FinanceTaskDto>> GetPendingApprovalsAsync(CancellationToken cancellationToken)
    {
        var items = await _reimbursementRepository.GetByStatusAsync(ReimbursementStatus.Manager_Approved, cancellationToken);
        return MapToDto(items);
    }

    public async Task<IEnumerable<FinanceTaskDto>> GetPendingPaymentsAsync(CancellationToken cancellationToken)
    {
        var items = await _reimbursementRepository.GetByStatusAsync(ReimbursementStatus.Finance_Approved, cancellationToken);
        return MapToDto(items);
    }

    public async Task ApproveAsync(FinanceApprovalRequestDto requestDto, CancellationToken cancellationToken)
    {
        var reimbursement = await _reimbursementRepository.GetByIdAsync(requestDto.ReimbursementId, cancellationToken);
        if (reimbursement == null) throw new NullReferenceException("Reimbursement not found");

        if (reimbursement.Status != ReimbursementStatus.Manager_Approved)
            throw new ArgumentException($"Invalid status: {reimbursement.Status}. Expecting Manager_Approved.");

        reimbursement.Status = ReimbursementStatus.Finance_Approved;
        reimbursement.UpdatedAt = DateTime.UtcNow;

        var log = CreateLog(reimbursement.Id, requestDto.FinanceId, ReimbursementStatus.Finance_Approved, requestDto.Comments ?? "Finance Verified");

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _reimbursementRepository.UpdateAsync(reimbursement);
            await _approvalLogRepository.CreateAsync(log, cancellationToken);
        }, cancellationToken);
    }

    public async Task RejectAsync(FinanceApprovalRequestDto requestDto, CancellationToken cancellationToken)
    {
        var reimbursement = await _reimbursementRepository.GetByIdAsync(requestDto.ReimbursementId, cancellationToken);
        if (reimbursement == null) throw new NullReferenceException("Reimbursement not found");

        if (reimbursement.Status != ReimbursementStatus.Manager_Approved && 
            reimbursement.Status != ReimbursementStatus.Finance_Approved)
            throw new ArgumentException($"Invalid status: {reimbursement.Status}.");

        if (string.IsNullOrWhiteSpace(requestDto.Comments))
            throw new ArgumentException("Rejection reason is required.");

        reimbursement.Status = ReimbursementStatus.Finance_Rejected;
        reimbursement.RejectionReason = requestDto.Comments;
        reimbursement.UpdatedAt = DateTime.UtcNow;

        var log = CreateLog(reimbursement.Id, requestDto.FinanceId, ReimbursementStatus.Finance_Rejected, requestDto.Comments);

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _reimbursementRepository.UpdateAsync(reimbursement);
            await _approvalLogRepository.CreateAsync(log, cancellationToken);
        }, cancellationToken);
    }

    public async Task PayAsync(PaymentExecutionDto requestDto, CancellationToken cancellationToken)
    {
        var reimbursement = await _reimbursementRepository.GetByIdAsync(requestDto.ReimbursementId, cancellationToken);
        if (reimbursement == null) throw new NullReferenceException("Reimbursement not found");

        if (reimbursement.Status != ReimbursementStatus.Finance_Approved)
            throw new ArgumentException($"Invalid status: {reimbursement.Status}. Expecting Finance_Approved.");

        reimbursement.Status = ReimbursementStatus.Paid;
        reimbursement.UpdatedAt = DateTime.UtcNow;

        var disbursement = new Disbursement
        {
            Id = Guid.NewGuid(),
            ReimbursementId = reimbursement.Id,
            ProcessedByUserId = requestDto.FinanceId,
            AmountPaid = requestDto.AmountPaid,
            ReferenceNumber = requestDto.ReferenceNumber,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var log = CreateLog(reimbursement.Id, requestDto.FinanceId, ReimbursementStatus.Paid, $"Paid via Transfer. Ref: {requestDto.ReferenceNumber}");

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _reimbursementRepository.UpdateAsync(reimbursement);
            await _disbursementRepository.CreateAsync(disbursement, cancellationToken);
            await _approvalLogRepository.CreateAsync(log, cancellationToken);
        }, cancellationToken);
    }

    // --- Helper Methods ---
    private IEnumerable<FinanceTaskDto> MapToDto(IEnumerable<Reimbursement> items)
    {
        return items.Select(x => new FinanceTaskDto(
            x.Id,
            x.User?.Fullname ?? "Unknown",
            x.Category?.Name ?? "-",
            x.Title!,
            x.Amount,
            x.DateOfExpense,
            x.CreatedAt
        ));
    }

    private ApprovalLog CreateLog(Guid reimId, Guid userId, ReimbursementStatus action, string comment)
    {
        return new ApprovalLog
        {
            Id = Guid.NewGuid(),
            ReimbursementId = reimId,
            ActionByUserId = userId,
            Action = action,
            Comments = comment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}