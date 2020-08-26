using Microsoft.EntityFrameworkCore.Migrations;

namespace Donations_Api.Migrations
{
    public partial class UpdateTransactionObj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "935f88ae-2daa-4dfe-9a8d-2fc14bc1cf54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a71b1ca3-5fb6-441b-bbc1-0ef890ac2cc9");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "Transactions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Transactions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Transactions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c9ebe71-715a-4707-ae2f-8d7595b8b5c4", "b29bd6d0-b3ac-4235-8831-60fe9733b2a4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8af0f8ba-438d-401c-ac42-154dcabca8c3", 0, "1873d584-81f3-4a11-8b83-1c8d9986649b", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEAO163otnKTpXknIBFwx485RV/cSrSTRGk5KtLKmAuNlCQ4vUFvL4AWf2A3pFP+38g==", null, true, "00000000-0000-0000-0000-000000000000", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c9ebe71-715a-4707-ae2f-8d7595b8b5c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8af0f8ba-438d-401c-ac42-154dcabca8c3");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "935f88ae-2daa-4dfe-9a8d-2fc14bc1cf54", "7b910722-74e3-4a12-9a20-04cd4cd8ee52", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a71b1ca3-5fb6-441b-bbc1-0ef890ac2cc9", 0, "7e51498b-745c-47d9-bb42-06fe5b0e8f00", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEDAqed9BnMy6a6rkzvPWqPLq0hssyVzGQKawBj2/IvvccSted+WJQywWvIoI2engtA==", null, true, "00000000-0000-0000-0000-000000000000", false, "Admin" });
        }
    }
}
