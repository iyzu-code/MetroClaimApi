namespace MetroClaim.Api.Models;

public class Category
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // --- NAVIGATION PROPERTIES ---
    public virtual ICollection<Reimbursement> Reimbursements { get; set; } = new List<Reimbursement>();
}