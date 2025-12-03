namespace MetroClaim.Api.Models;

public class Disbursement
{
    public Guid Id { get; set; }
    public Guid ReimbursementId { get; set; }
    public Guid? ProcessedByUserId { get; set; } //finance
    public decimal AmountPaid { get; set; }
    public string? ReferenceNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // --- NAVIGATION PROPERTIES ---
    public virtual Reimbursement? Reimbursement { get; set; }
    public virtual User? ProcessedByUser { get; set; }
}