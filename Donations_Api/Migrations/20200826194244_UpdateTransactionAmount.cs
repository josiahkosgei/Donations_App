using Microsoft.EntityFrameworkCore.Migrations;

namespace Donations_Api.Migrations
{
    public partial class UpdateTransactionAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c9ebe71-715a-4707-ae2f-8d7595b8b5c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8af0f8ba-438d-401c-ac42-154dcabca8c3");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f359213e-aa46-47ac-8d86-e85fda3c8ee3", "0d13d2c0-2076-4681-86cd-20a11e7839bc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "641432f3-660c-4571-8ac2-3d791693f841", 0, "31f8c2cc-2414-4569-b64b-2b74c2aa4de0", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEJ1tjWQCmYwZ4WOuGmpTVQ76iO0xJl+skk7W5q66pBH+qKni7aCutLRgtMQbXY/q2Q==", null, true, "00000000-0000-0000-0000-000000000000", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f359213e-aa46-47ac-8d86-e85fda3c8ee3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641432f3-660c-4571-8ac2-3d791693f841");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c9ebe71-715a-4707-ae2f-8d7595b8b5c4", "b29bd6d0-b3ac-4235-8831-60fe9733b2a4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8af0f8ba-438d-401c-ac42-154dcabca8c3", 0, "1873d584-81f3-4a11-8b83-1c8d9986649b", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEAO163otnKTpXknIBFwx485RV/cSrSTRGk5KtLKmAuNlCQ4vUFvL4AWf2A3pFP+38g==", null, true, "00000000-0000-0000-0000-000000000000", false, "Admin" });
        }
    }
}
