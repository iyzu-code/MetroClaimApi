using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MetroClaim.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUserAndAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "bank_account_number", "created_at", "email", "employee_id", "full_name", "manager_id", "role", "updated_at" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), "1000000000", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3522), "admin@metroclaim.com", "ADM001", "System Administrator", null, 3, new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3524) },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), "2000000000", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3530), "manager@metroclaim.com", "MGR001", "John Manager", null, 1, new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3530) }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "expired", "is_active", "is_used", "otp", "password_hash", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3578), null, true, false, null, "0", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3579), new Guid("a0000000-0000-0000-0000-000000000001") },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3583), null, true, false, null, "0", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3583), new Guid("a0000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "bank_account_number", "created_at", "email", "employee_id", "full_name", "manager_id", "role", "updated_at" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000003"), "3000000000", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3533), "finance@metroclaim.com", "FIN001", "Sarah Finance", new Guid("a0000000-0000-0000-0000-000000000002"), 2, new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3533) },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), "4000000000", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3536), "alice@metroclaim.com", "EMP001", "Alice Employee", new Guid("a0000000-0000-0000-0000-000000000002"), 0, new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3536) },
                    { new Guid("a0000000-0000-0000-0000-000000000005"), "5000000000", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3538), "bob@metroclaim.com", "EMP002", "Bob Employee", new Guid("a0000000-0000-0000-0000-000000000002"), 0, new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3538) },
                    { new Guid("a0000000-0000-0000-0000-000000000006"), "6000000000", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3541), "charlie@metroclaim.com", "EMP003", "Charlie Inactive", new Guid("a0000000-0000-0000-0000-000000000002"), 0, new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3541) }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_at", "expired", "is_active", "is_used", "otp", "password_hash", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3585), new DateTime(2025, 11, 28, 10, 6, 49, 796, DateTimeKind.Utc).AddTicks(3586), true, false, "123456", "0", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3585), new Guid("a0000000-0000-0000-0000-000000000003") },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3592), new DateTime(2025, 11, 28, 9, 36, 49, 796, DateTimeKind.Utc).AddTicks(3593), true, true, "999999", "0", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3592), new Guid("a0000000-0000-0000-0000-000000000004") },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3594), null, true, false, null, "0", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3594), new Guid("a0000000-0000-0000-0000-000000000005") },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3597), null, false, false, null, "0", new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3597), new Guid("a0000000-0000-0000-0000-000000000006") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"));
        }
    }
}
