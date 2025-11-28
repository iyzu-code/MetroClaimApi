using MetroClaim.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MetroClaim.Api.Data;

public class MetroClaimDbContext : DbContext
{
    public MetroClaimDbContext(DbContextOptions<MetroClaimDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Reimbursement> Reimbursements { get; set; }
    public DbSet<ApprovalLog> ApprovalLogs { get; set; }
    public DbSet<Disbursement> Disbursements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetroClaimDbContext).Assembly);
    }
}
