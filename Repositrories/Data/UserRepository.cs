using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetroClaim.Api.Repositrories.Data;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly MetroClaimDbContext _context;
    public UserRepository(MetroClaimDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {   
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
