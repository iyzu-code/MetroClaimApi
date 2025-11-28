using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;

namespace MetroClaim.Api.Repositrories.Data;

public class ReimbursementRepository : Repository<Reimbursement>, IReimbursementRepository
{
    public ReimbursementRepository(MetroClaimDbContext context) : base(context)
    {
    }
}
