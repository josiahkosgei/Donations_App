using Microsoft.EntityFrameworkCore.Migrations;

namespace Donations_Api.Migrations
{
    public partial class UpdateTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c981462-e233-47cf-a543-a9073f4b597b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63925840-ddae-4385-af95-0979040b5df7");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Email",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "935f88ae-2daa-4dfe-9a8d-2fc14bc1cf54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a71b1ca3-5fb6-441b-bbc1-0ef890ac2cc9");

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c981462-e233-47cf-a543-a9073f4b597b", "bafc4485-ad4b-4edf-b188-0b3c7d501c46", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "63925840-ddae-4385-af95-0979040b5df7", 0, "d8858ab5-03bb-4e2d-a090-d4218c6da402", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAECT4BZD4pbNd7bCFZooaFefSBF/z0RlJP79pAUQKuwT6c0+fqHUAwgCjUnRex6DREw==", null, true, "00000000-0000-0000-0000-000000000000", false, "Admin" });
        }
    }
}
