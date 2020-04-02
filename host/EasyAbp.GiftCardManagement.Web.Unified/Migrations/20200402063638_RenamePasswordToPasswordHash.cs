using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.GiftCardManagement.Migrations
{
    public partial class RenamePasswordToPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "GiftCardManagementGiftCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "GiftCardManagementGiftCards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
