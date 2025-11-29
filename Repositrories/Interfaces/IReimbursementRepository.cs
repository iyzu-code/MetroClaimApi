using MetroClaim.Api.Models;

namespace MetroClaim.Api.Repositrories.Interfaces;

public interface IReimbursementRepository : IRepository<Reimbursement>
{
    Task<IEnumerable<Reimbursement>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<Reimbursement?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<Reimbursement>> GetPendingForManagerAsync(Guid managerId, CancellationToken cancellationToken);

    Task<IEnumerable<Reimbursement>> GetByStatusAsync(ReimbursementStatus status, CancellationToken cancellationToken);
}
