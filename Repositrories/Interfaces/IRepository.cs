namespace MetroClaim.Api.Repositrories.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(T t, CancellationToken cancellationToken);
    Task UpdateAsync(T t);
    Task DeleteAsync(T t);
}
