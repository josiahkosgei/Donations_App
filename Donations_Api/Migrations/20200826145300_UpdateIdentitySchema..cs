using Microsoft.EntityFrameworkCore.Migrations;

namespace Donations_Api.Migrations
{
    public partial class UpdateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1876e575-a8aa-46eb-899d-46f3ddd53664", "7eb0c229-fbe7-445a-b4fb-7ccdef1fdf3a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1876e575-a8aa-46eb-899d-46f3ddd53664");
        }
    }
}
