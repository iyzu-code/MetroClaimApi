using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;

namespace MetroClaim.Api.Repositrories.Data;

public class ApprovalLogRepository : Repository<ApprovalLog>, IApprovalLogRepository
{
    public ApprovalLogRepository(MetroClaimDbContext context) : base(context)
    {
    }
}
