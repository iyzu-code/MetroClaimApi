using System;
using MetroClaim.Api.Data;
using MetroClaim.Api.Repositrories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetroClaim.Api.Repositrories.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MetroClaimDbContext _context;

    public Repository(MetroClaimDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T t, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(t, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T t)
    {
        _context.Set<T>().Remove(t);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(T t)
    {
        _context.Set<T>().Update(t);
        await _context.SaveChangesAsync();
    }
}
