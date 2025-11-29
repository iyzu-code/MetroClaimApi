using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetroClaim.Api.Repositrories.Data;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    private readonly MetroClaimDbContext _context;
    public AccountRepository(MetroClaimDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Account?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        // Query mencari Account dimana kolom UserId cocok dengan parameter
        return await _context.Accounts
            .FirstOrDefaultAsync(a => a.UserId == userId, cancellationToken);
    }
}
