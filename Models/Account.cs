namespace MetroClaim.Api.Models;

public class Account
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? PasswordHash { get; set; }
    public string? Otp { get; set; }
    public DateTime? Expired { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsUsed { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // --- NAVIGATION PROPERTIES ---
    public virtual User? User { get; set; }
}