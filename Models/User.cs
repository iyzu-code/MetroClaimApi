namespace MetroClaim.Api.Models;

public class User
{
    public Guid Id { get; set; }
    public string? EmployeeId { get; set; }
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public UserRole Role { get; set; }
    public Guid? ManagerId { get; set; }
    public string? BankAccountNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // --- NAVIGATION PROPERTIES ---
    
    // 1-to-1: User punya 1 Account
    public virtual Account? Account { get; set; }

    // Self-Referencing: Atasan
    public virtual User? Manager { get; set; }
    
    // Self-Referencing: Bawahan (Jika dia Manager)
    public virtual ICollection<User> Subordinates { get; set; } = new List<User>();

    // 1-to-Many: Daftar Reimburse yang diajukan user ini
    public virtual ICollection<Reimbursement> Reimbursements { get; set; } = new List<Reimbursement>();

    // 1-to-Many: Log aktivitas user ini (sebagai Approver/Finance)
    public virtual ICollection<ApprovalLog> ApprovalLogs { get; set; } = new List<ApprovalLog>();

    // 1-to-Many: Transaksi pencairan yang diproses user ini (sebagai Finance)
    public virtual ICollection<Disbursement> ProcessedDisbursements { get; set; } = new List<Disbursement>();
}