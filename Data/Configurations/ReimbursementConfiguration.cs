using MetroClaim.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroClaim.Api.Data.Configurations;

public class ReimbursementConfiguration : IEntityTypeConfiguration<Reimbursement>
{
    public void Configure(EntityTypeBuilder<Reimbursement> builder)
    {
        builder.ToTable("reimbursements");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r => r.UserId).HasColumnName("user_id");
        builder.Property(r => r.CategoryId).HasColumnName("category_id");
        builder.Property(r => r.Title).HasColumnName("title");
        builder.Property(r => r.Description).HasColumnName("description");
        builder.Property(r => r.Amount).HasColumnName("amount").HasPrecision(15, 2);
        builder.Property(r => r.DateOfExpense).HasColumnName("date_of_expense");
        builder.Property(r => r.Receipt).HasColumnName("receipt");
        builder.Property(r => r.Status).HasColumnName("status");
        builder.Property(r => r.RejectionReason).HasColumnName("rejection_reason");
        builder.Property(r => r.CreatedAt).HasColumnName("created_at");
        builder.Property(r => r.UpdatedAt).HasColumnName("updated_at");

        // RELASI 1: User -> Reimbursements
        builder.HasOne(r => r.User)
            .WithMany(u => u.Reimbursements)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict); // User tidak bisa dihapus jika masih punya data reimburse

        // RELASI 2: Category -> Reimbursements
        builder.HasOne(r => r.Category)
            .WithMany(c => c.Reimbursements)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Kategori tidak bisa dihapus jika sudah dipakai transaksi
    }
}