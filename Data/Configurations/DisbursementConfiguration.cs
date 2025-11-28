using MetroClaim.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroClaim.Api.Data.Configurations;

public class DisbursementConfiguration : IEntityTypeConfiguration<Disbursement>
{
    public void Configure(EntityTypeBuilder<Disbursement> builder)
    {
        builder.ToTable("disbursements");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("id");
        builder.Property(d => d.ReimbursementId).HasColumnName("reimbursement_id");
        builder.Property(d => d.ProcessedByUserId).HasColumnName("processed_by_user_id");
        builder.Property(d => d.AmountPaid).HasColumnName("amount_paid").HasPrecision(15, 2);
        builder.Property(d => d.ReferenceNumber).HasColumnName("reference_number");
        builder.Property(d => d.CreatedAt).HasColumnName("created_at");
        builder.Property(d => d.UpdatedAt).HasColumnName("updated_at");

        // RELASI 1: Reimbursement -> Disbursement (One-to-One)
        builder.HasOne(d => d.Reimbursement)
            .WithOne(r => r.Disbursement)
            .HasForeignKey<Disbursement>(d => d.ReimbursementId)
            .OnDelete(DeleteBehavior.Restrict);

        // RELASI 2: User (Finance) -> Disbursement
        builder.HasOne(d => d.ProcessedByUser)
            .WithMany(u => u.ProcessedDisbursements)
            .HasForeignKey(d => d.ProcessedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}