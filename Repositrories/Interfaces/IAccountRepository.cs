using MetroClaim.Api.Models;

namespace MetroClaim.Api.Repositrories.Interfaces;

public interface IAccountRepository : IRepository<Account>
{
    Task<Account?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}
