using Microsoft.EntityFrameworkCore.Migrations;

namespace Donations_Api.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1876e575-a8aa-46eb-899d-46f3ddd53664");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c981462-e233-47cf-a543-a9073f4b597b", "bafc4485-ad4b-4edf-b188-0b3c7d501c46", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "63925840-ddae-4385-af95-0979040b5df7", 0, "d8858ab5-03bb-4e2d-a090-d4218c6da402", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAECT4BZD4pbNd7bCFZooaFefSBF/z0RlJP79pAUQKuwT6c0+fqHUAwgCjUnRex6DREw==", null, true, "00000000-0000-0000-0000-000000000000", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c981462-e233-47cf-a543-a9073f4b597b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63925840-ddae-4385-af95-0979040b5df7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1876e575-a8aa-46eb-899d-46f3ddd53664", "7eb0c229-fbe7-445a-b4fb-7ccdef1fdf3a", "Admin", "ADMIN" });
        }
    }
}
