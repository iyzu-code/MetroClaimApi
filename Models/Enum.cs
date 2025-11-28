namespace MetroClaim.Api.Models
{
    public enum UserRole
    {
        Employee = 0,
        Manager = 1,
        Finance = 2,
        Admin = 3
    }

    public enum ReimbursementStatus
    {
        Submitted = 0,
        Manager_Approved = 1,
        Manager_Rejected = 2,
        Finance_Approved = 3,
        Finance_Rejected = 4,
        Paid = 5
    }
}