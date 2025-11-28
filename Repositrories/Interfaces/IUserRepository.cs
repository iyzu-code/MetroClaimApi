using MetroClaim.Api.Models;

namespace MetroClaim.Api.Repositrories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}
