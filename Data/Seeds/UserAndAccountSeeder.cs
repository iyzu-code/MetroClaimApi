using MetroClaim.Api.Models;

namespace MetroClaim.Api.Data.Seeds;

public static class UserAndAccountSeeder
{
    // FIXED GUIDS
    public static readonly Guid AdminId = Guid.Parse("A0000000-0000-0000-0000-000000000001");
    public static readonly Guid ManagerId = Guid.Parse("A0000000-0000-0000-0000-000000000002");
    public static readonly Guid FinanceId = Guid.Parse("A0000000-0000-0000-0000-000000000003");
    public static readonly Guid Employee1Id = Guid.Parse("A0000000-0000-0000-0000-000000000004");
    public static readonly Guid Employee2Id = Guid.Parse("A0000000-0000-0000-0000-000000000005");
    public static readonly Guid InactiveEmployeeId = Guid.Parse("A0000000-0000-0000-0000-000000000006");

    // ACCOUNT GUIDS
    public static readonly Guid AdminAccountId = Guid.Parse("B0000000-0000-0000-0000-000000000001");
    public static readonly Guid ManagerAccountId = Guid.Parse("B0000000-0000-0000-0000-000000000002");
    public static readonly Guid FinanceAccountId = Guid.Parse("B0000000-0000-0000-0000-000000000003");
    public static readonly Guid Employee1AccountId = Guid.Parse("B0000000-0000-0000-0000-000000000004");
    public static readonly Guid Employee2AccountId = Guid.Parse("B0000000-0000-0000-0000-000000000005");
    public static readonly Guid InactiveEmployeeAccountId = Guid.Parse("B0000000-0000-0000-0000-000000000006");

    // -------------------------
    // USERS
    // -------------------------
    public static List<User> GetDefaultUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = AdminId,
                EmployeeId = "ADM001",
                Fullname = "System Administrator",
                Email = "admin@metroclaim.com",
                Role = UserRole.Admin,
                ManagerId = null,
                BankAccountNumber = "1000000000"
            },

            new User
            {
                Id = ManagerId,
                EmployeeId = "MGR001",
                Fullname = "John Manager",
                Email = "manager@metroclaim.com",
                Role = UserRole.Manager,
                ManagerId = null,
                BankAccountNumber = "2000000000"
            },

            new User
            {
                Id = FinanceId,
                EmployeeId = "FIN001",
                Fullname = "Sarah Finance",
                Email = "finance@metroclaim.com",
                Role = UserRole.Finance,
                ManagerId = ManagerId,
                BankAccountNumber = "3000000000"
            },

            new User
            {
                Id = Employee1Id,
                EmployeeId = "EMP001",
                Fullname = "Alice Employee",
                Email = "alice@metroclaim.com",
                Role = UserRole.Employee,
                ManagerId = ManagerId,
                BankAccountNumber = "4000000000"
            },

            new User
            {
                Id = Employee2Id,
                EmployeeId = "EMP002",
                Fullname = "Bob Employee",
                Email = "bob@metroclaim.com",
                Role = UserRole.Employee,
                ManagerId = ManagerId,
                BankAccountNumber = "5000000000"
            },

            new User
            {
                Id = InactiveEmployeeId,
                EmployeeId = "EMP003",
                Fullname = "Charlie Inactive",
                Email = "charlie@metroclaim.com",
                Role = UserRole.Employee,
                ManagerId = ManagerId,
                BankAccountNumber = "6000000000"
            }
        };
    }

    // -------------------------
    // ACCOUNTS
    // -------------------------
    public static List<Account> GetDefaultAccounts()
    {
        return new List<Account>
        {
            // Admin (Active, No OTP)
            new Account
            {
                Id = AdminAccountId,
                UserId = AdminId,
                PasswordHash = "0",
                Otp = null,
                Expired = null,
                IsActive = true,
                IsUsed = false
            },

            // Manager (Active)
            new Account
            {
                Id = ManagerAccountId,
                UserId = ManagerId,
                PasswordHash = "0",
                Otp = null,
                Expired = null,
                IsActive = true,
                IsUsed = false
            },

            // Finance (Active, OTP available)
            new Account
            {
                Id = FinanceAccountId,
                UserId = FinanceId,
                PasswordHash = "0",
                Otp = "123456",
                Expired = DateTime.UtcNow.AddMinutes(10),
                IsActive = true,
                IsUsed = false
            },

            // Employee1 (Active, OTP expired)
            new Account
            {
                Id = Employee1AccountId,
                UserId = Employee1Id,
                PasswordHash = "0",
                Otp = "999999",
                Expired = DateTime.UtcNow.AddMinutes(-20),
                IsActive = true,
                IsUsed = true
            },

            // Employee2 (Active)
            new Account
            {
                Id = Employee2AccountId,
                UserId = Employee2Id,
                PasswordHash = "0",
                Otp = null,
                Expired = null,
                IsActive = true,
                IsUsed = false
            },

            // Inactive Employee
            new Account
            {
                Id = InactiveEmployeeAccountId,
                UserId = InactiveEmployeeId,
                PasswordHash = "0",
                Otp = null,
                Expired = null,
                IsActive = false,
                IsUsed = false
            }
        };
    }
}
