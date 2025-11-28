using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;

namespace MetroClaim.Api.Repositrories.Data;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    public AccountRepository(MetroClaimDbContext context) : base(context)
    {
    }
}
