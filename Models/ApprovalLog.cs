namespace MetroClaim.Api.Models;

public class ApprovalLog
{
    public Guid Id { get; set; }
    public Guid ReimbursementId { get; set; }
    public Guid ActionByUserId { get; set; }
    public ReimbursementStatus Action { get; set; }
    public string? Comments { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // --- NAVIGATION PROPERTIES ---
    public virtual Reimbursement? Reimbursement { get; set; }
    public virtual User? ActionByUser { get; set; }
}