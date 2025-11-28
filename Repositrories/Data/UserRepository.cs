using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;

namespace MetroClaim.Api.Repositrories.Data;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(MetroClaimDbContext context) : base(context)
    {
    }
}
