using MetroClaim.Api.Dtos.Approval;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositories;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;

namespace MetroClaim.Api.Services;

public class ApprovalService : IApprovalService
{
    private readonly IReimbursementRepository _reimbursementRepository;
    private readonly IApprovalLogRepository _approvalLogRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApprovalService(
        IReimbursementRepository reimbursementRepository,
        IApprovalLogRepository approvalLogRepository,
        IUnitOfWork unitOfWork)
    {
        _reimbursementRepository = reimbursementRepository;
        _approvalLogRepository = approvalLogRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PendingApprovalDto>> GetPendingManagerApprovalsAsync(Guid managerId, CancellationToken cancellationToken)
    {
        if (managerId == Guid.Empty)
        {
            throw new ArgumentNullException("id is invalid");
        }

        var items = await _reimbursementRepository.GetPendingForManagerAsync(managerId, cancellationToken);

        return items.Select(x => new PendingApprovalDto(
            x.Id,
            x.User?.Fullname ?? "Unknown Employee", // Nama bawahan
            x.Category?.Name ?? "-",
            x.Title!,
            x.Amount,
            x.DateOfExpense,
            x.CreatedAt
        ));
    }

    public async Task ApproveByManagerAsync(ApprovalRequestDto requestDto, CancellationToken cancellationToken)
    {
        var reimbursement = await _reimbursementRepository.GetByIdWithDetailsAsync(requestDto.ReimbursementId, cancellationToken);

        if (reimbursement is null)
            throw new NullReferenceException("Reimbursement not found");

        if (reimbursement.Status != ReimbursementStatus.Submitted)
            throw new ArgumentException($"Cannot approve. Current status is {reimbursement.Status}");

        if (reimbursement.User!.ManagerId != requestDto.ManagerId)
            throw new UnauthorizedAccessException("You are not the manager of this employee.");

        reimbursement.Status = ReimbursementStatus.Manager_Approved;
        reimbursement.UpdatedAt = DateTime.UtcNow;

        var log = new ApprovalLog
        {
            Id = Guid.NewGuid(),
            ReimbursementId = reimbursement.Id,
            ActionByUserId = requestDto.ManagerId,
            Action = ReimbursementStatus.Manager_Approved,
            Comments = requestDto.Comments ?? "Approved by Manager",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _reimbursementRepository.UpdateAsync(reimbursement);
            await _approvalLogRepository.CreateAsync(log, cancellationToken);
        }, cancellationToken);
    }

    public async Task RejectByManagerAsync(ApprovalRequestDto requestDto, CancellationToken cancellationToken)
    {
        // 1. Ambil data
        var reimbursement = await _reimbursementRepository.GetByIdWithDetailsAsync(requestDto.ReimbursementId, cancellationToken);

        if (reimbursement == null)
            throw new NullReferenceException("Reimbursement not found");

        // 2. Validasi Status
        if (reimbursement.Status != ReimbursementStatus.Submitted)
            throw new ArgumentException($"Cannot reject. Current status is {reimbursement.Status}");

        // 3. Validasi Otoritas
        if (reimbursement.User!.ManagerId != requestDto.ManagerId)
            throw new UnauthorizedAccessException("You are not the manager of this employee.");

        // 4. Validasi Komentar: Reject WAJIB ada alasan
        if (string.IsNullOrWhiteSpace(requestDto.Comments))
            throw new ArgumentException("Rejection reason is required.");

        // 5. Update Status & Alasan Penolakan
        reimbursement.Status = ReimbursementStatus.Manager_Rejected;
        reimbursement.RejectionReason = requestDto.Comments;
        reimbursement.UpdatedAt = DateTime.UtcNow;

        // 6. Siapkan Log
        var log = new ApprovalLog
        {
            Id = Guid.NewGuid(),
            ReimbursementId = reimbursement.Id,
            ActionByUserId = requestDto.ManagerId,
            Action = ReimbursementStatus.Manager_Rejected,
            Comments = requestDto.Comments,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // 7. Commit Transaksi
        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _reimbursementRepository.UpdateAsync(reimbursement);
            await _approvalLogRepository.CreateAsync(log, cancellationToken);
        }, cancellationToken);
    }
}