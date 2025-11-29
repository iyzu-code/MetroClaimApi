using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MetroClaim.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsDeletedToCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8042), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8043) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8047), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8048) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "expired", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8049), new DateTime(2025, 11, 29, 12, 26, 27, 863, DateTimeKind.Utc).AddTicks(8050), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "expired", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8056), new DateTime(2025, 11, 29, 11, 56, 27, 863, DateTimeKind.Utc).AddTicks(8057), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8056) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8058), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8058) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8060), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8085), "Transportation", new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8086) },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8090), "Meal", new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8090) },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8092), "Accommodation", new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8092) },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8093), "Medical", new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8094) },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8095), "Office Supplies", new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8095) },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8098), "Training & Development", new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8098) },
                    { new Guid("c0000000-0000-0000-0000-000000000007"), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8099), "Other", new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8100) }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(7988), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(7997), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(7997) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(7999), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(7999) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8002), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8002) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8003), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8004) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8007), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8007) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "categories");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3578), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3579) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3583), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3583) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "expired", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3585), new DateTime(2025, 11, 28, 10, 6, 49, 796, DateTimeKind.Utc).AddTicks(3586), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3585) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "expired", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3592), new DateTime(2025, 11, 28, 9, 36, 49, 796, DateTimeKind.Utc).AddTicks(3593), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3592) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3594), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3594) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3597), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3597) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3522), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3530), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3533), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3533) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3536), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3536) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3538), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3538) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3541), new DateTime(2025, 11, 28, 9, 56, 49, 796, DateTimeKind.Utc).AddTicks(3541) });
        }
    }
}
