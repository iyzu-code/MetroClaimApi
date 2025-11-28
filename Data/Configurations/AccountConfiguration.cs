using MetroClaim.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroClaim.Api.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("id");
        builder.Property(a => a.UserId).HasColumnName("user_id");
        builder.Property(a => a.PasswordHash).HasColumnName("password_hash");
        builder.Property(a => a.Otp).HasColumnName("otp");
        builder.Property(a => a.Expired).HasColumnName("expired");
        builder.Property(a => a.IsActive).HasColumnName("is_active");
        builder.Property(a => a.IsUsed).HasColumnName("is_used");
        builder.Property(a => a.CreatedAt).HasColumnName("created_at");
        builder.Property(a => a.UpdatedAt).HasColumnName("updated_at");

        // RELASI: One-to-One (User -> Account)
        builder.HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Jika User dihapus, Akun login ikut terhapus
    }
}