using MetroClaim.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetroClaim.Api.Data.Configurations;

public class ApprovalLogConfiguration : IEntityTypeConfiguration<ApprovalLog>
{
    public void Configure(EntityTypeBuilder<ApprovalLog> builder)
    {
        builder.ToTable("approval_logs");
        builder.HasKey(al => al.Id);

        builder.Property(al => al.Id).HasColumnName("id");
        builder.Property(al => al.ReimbursementId).HasColumnName("reimbursement_id");
        builder.Property(al => al.ActionByUserId).HasColumnName("action_by_user_id");
        builder.Property(al => al.Action).HasColumnName("action");
        builder.Property(al => al.Comments).HasColumnName("comments");
        builder.Property(al => al.CreatedAt).HasColumnName("created_at");
        builder.Property(al => al.UpdatedAt).HasColumnName("updated_at");

        // RELASI 1: Reimbursement -> Logs
        builder.HasOne(l => l.Reimbursement)
            .WithMany(r => r.ApprovalLogs)
            .HasForeignKey(l => l.ReimbursementId)
            .OnDelete(DeleteBehavior.Cascade); // Jika Reimburse dihapus (jarang terjadi), log ikut hilang

        // RELASI 2: User (Actor) -> Logs
        builder.HasOne(l => l.ActionByUser)
            .WithMany(u => u.ApprovalLogs)
            .HasForeignKey(l => l.ActionByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}