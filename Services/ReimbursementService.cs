using MetroClaim.Api.Dtos.Reimbursement;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositories;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;

namespace MetroClaim.Api.Services;

public class ReimbursementService : IReimbursementService
{
    private readonly IReimbursementRepository _reimbursementRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IApprovalLogRepository _approvalLogRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReimbursementService(
        IReimbursementRepository reimbursementRepository,
        ICategoryRepository categoryRepository,
        IApprovalLogRepository approvalLogRepository,
        IUnitOfWork unitOfWork)
    {
        _reimbursementRepository = reimbursementRepository;
        _categoryRepository = categoryRepository;
        _approvalLogRepository = approvalLogRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(ReimbursementRequestDto requestDto, CancellationToken cancellationToken)
    {
        // 1. Validasi Kategori
        var category = await _categoryRepository.GetByIdAsync(requestDto.CategoryId, cancellationToken);
        if (category == null)
        {
            throw new NullReferenceException("Category not found");
        }

        // ID Reimbursement dibuat di awal agar bisa dipakai oleh Log
        var reimbursementId = Guid.NewGuid();

        // 2. Mapping Entity Reimbursement
        var reimbursement = new Reimbursement
        {
            Id = reimbursementId,
            UserId = requestDto.UserId,
            CategoryId = requestDto.CategoryId,
            Title = requestDto.Title,
            Description = requestDto.Description,
            Amount = requestDto.Amount,
            DateOfExpense = requestDto.DateOfExpense,
            Receipt = requestDto.Receipt,

            // Status awal Submitted
            Status = ReimbursementStatus.Submitted,

            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // 3. (BARU) Buat Entity Log 'Submitted'
        var initialLog = new ApprovalLog
        {
            Id = Guid.NewGuid(),
            ReimbursementId = reimbursementId,
            ActionByUserId = requestDto.UserId, // User sendiri yang melakukan aksi submit
            Action = ReimbursementStatus.Submitted, // Sesuai Enum
            Comments = "Pengajuan baru dibuat oleh karyawan.",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // 4. Simpan Keduanya dalam Satu Transaksi
        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            // Simpan Header
            await _reimbursementRepository.CreateAsync(reimbursement, cancellationToken);

            // Simpan Log
            await _approvalLogRepository.CreateAsync(initialLog, cancellationToken);

        }, cancellationToken);
    }

    public async Task<IEnumerable<ReimbursementResponseDto>> GetByUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("id is not valid");
        }
        var reimbursements = await _reimbursementRepository.GetByUserIdAsync(userId, cancellationToken);

        if (!reimbursements.Any())
        {
            // return Enumerable.Empty<ReimbursementResponseDto>();
            throw new NullReferenceException("reimbursement not found");
        }

        var response = reimbursements.Select(r => new ReimbursementResponseDto(
            r.Id,
            r.Category?.Name ?? "Unknown",
            r.Title!,
            r.Amount,
            r.DateOfExpense,
            r.Status,
            r.CreatedAt
        ));

        return response;
    }

    public async Task<ReimbursementDetailDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var reimbursement = await _reimbursementRepository.GetByIdWithDetailsAsync(id, cancellationToken);

        if (reimbursement == null)
        {
            throw new NullReferenceException("Reimbursement not found");
        }

        // Mapping Logs
        // Perlu handle null pada ActionByUser jika user terhapus atau data tidak konsisten
        var logsDto = reimbursement.ApprovalLogs.Select(l => new ApprovalLogDto(
            l.ActionByUser?.Fullname ?? "Unknown User",
            l.Action,
            l.Comments,
            l.CreatedAt
        ));

        var detailDto = new ReimbursementDetailDto(
            reimbursement.Id,
            reimbursement.Category?.Name ?? "-",
            reimbursement.Title!,
            reimbursement.Description!,
            reimbursement.Amount,
            reimbursement.DateOfExpense,
            reimbursement.Receipt!,
            reimbursement.Status,
            reimbursement.RejectionReason,
            reimbursement.CreatedAt,
            logsDto
        );

        return detailDto;
    }
}