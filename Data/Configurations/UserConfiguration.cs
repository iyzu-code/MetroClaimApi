using MetroClaim.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroClaim.Api.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.EmployeeId).HasColumnName("employee_id");
        builder.Property(u => u.Fullname).HasColumnName("full_name");
        builder.Property(u => u.Email).HasColumnName("email");
        builder.Property(u => u.Role).HasColumnName("role");
        builder.Property(u => u.ManagerId).HasColumnName("manager_id");
        builder.Property(u => u.BankAccountNumber).HasColumnName("bank_account_number");
        builder.Property(u => u.CreatedAt).HasColumnName("created_at");
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");

        builder.HasIndex(u => u.Email).IsUnique();

        // RELASI: Self-Referencing (Manager -> Subordinates)
        builder.HasOne(u => u.Manager)
            .WithMany(u => u.Subordinates)
            .HasForeignKey(u => u.ManagerId)
            .OnDelete(DeleteBehavior.Restrict); // Jangan hapus bawahan jika manager dihapus
    }
}