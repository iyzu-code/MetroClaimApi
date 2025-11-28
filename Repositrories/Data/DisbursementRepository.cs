using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;

namespace MetroClaim.Api.Repositrories.Data;

public class DisbursementRepository : Repository<Disbursement>, IDisbursementRepository
{
    public DisbursementRepository(MetroClaimDbContext context) : base(context)
    {
    }
}
