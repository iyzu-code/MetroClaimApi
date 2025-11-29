using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetroClaim.Api.Repositrories.Data;

public class ReimbursementRepository : Repository<Reimbursement>, IReimbursementRepository
{
    private readonly MetroClaimDbContext _context;
    public ReimbursementRepository(MetroClaimDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reimbursement>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        // Kita gunakan .Include() agar saat di-map ke DTO, nama kategorinya tidak null
        return await _context.Reimbursements
            .Include(r => r.Category)
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.CreatedAt) // Urutkan dari yang terbaru
            .ToListAsync(cancellationToken);
    }

    public async Task<Reimbursement?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        // Query Complex: Join ke banyak tabel sekaligus
        return await _context.Reimbursements
            .Include(r => r.Category)              // Ambil Nama Kategori
            .Include(r => r.User)                  // Ambil Data Pengaju (Employee)
            .Include(r => r.ApprovalLogs)          // Ambil History Log
                .ThenInclude(log => log.ActionByUser) // Ambil Nama User di dalam Log (Siapa yang approve)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Reimbursement>> GetPendingForManagerAsync(Guid managerId, CancellationToken cancellationToken)
    {
        return await _context.Reimbursements
            .Include(r => r.User) // Join ke User untuk cek ManagerId
            .Include(r => r.Category)
            .Where(r =>
                r.Status == ReimbursementStatus.Submitted && // Hanya yang Submitted
                r.User!.ManagerId == managerId // Hanya milik bawahan manager ini
            )
            .OrderBy(r => r.DateOfExpense)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reimbursement>> GetByStatusAsync(ReimbursementStatus status, CancellationToken cancellationToken)
    {
        return await _context.Reimbursements
            .Include(r => r.User)     // Butuh nama karyawan
            .Include(r => r.Category) // Butuh nama kategori
            .Where(r => r.Status == status)
            .OrderBy(r => r.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}
