using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroClaim.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsDeletedToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4427), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4428) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4441), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4442) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "expired", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4445), new DateTime(2025, 11, 29, 13, 15, 35, 524, DateTimeKind.Utc).AddTicks(4448), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4446) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "expired", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4461), new DateTime(2025, 11, 29, 12, 45, 35, 524, DateTimeKind.Utc).AddTicks(4464), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4462) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4467), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4467) });

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4472), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4553), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4564), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4565) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4569), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4572), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4576), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4583), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4584) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4589), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4160), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4190), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4195), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4196) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4201), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4202) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4312), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4323), new DateTime(2025, 11, 29, 13, 5, 35, 524, DateTimeKind.Utc).AddTicks(4323) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "users");

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

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8085), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8086) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8090), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8092), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8093), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8095), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8095) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8098), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8099), new DateTime(2025, 11, 29, 12, 16, 27, 863, DateTimeKind.Utc).AddTicks(8100) });

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
    }
}
