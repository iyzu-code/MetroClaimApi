namespace MetroClaim.Api.Models;

public class Reimbursement
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateOfExpense { get; set; }
    public string? Receipt { get; set; } 
    public ReimbursementStatus Status { get; set; } = ReimbursementStatus.Submitted;
    public string? RejectionReason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // --- NAVIGATION PROPERTIES ---
    public virtual User? User { get; set; }
    public virtual Category? Category { get; set; }
    
    // 1 Reimburse punya banyak history log
    public virtual ICollection<ApprovalLog> ApprovalLogs { get; set; } = new List<ApprovalLog>();
    
    // 1 Reimburse punya 1 data pencairan (jika sudah paid)
    public virtual Disbursement? Disbursement { get; set; }
}