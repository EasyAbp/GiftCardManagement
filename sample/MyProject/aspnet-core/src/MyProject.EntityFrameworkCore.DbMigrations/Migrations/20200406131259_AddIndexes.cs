using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Migrations
{
    public partial class AddIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "GiftCardManagementGiftCards",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiftCardManagementGiftCards_Code",
                table: "GiftCardManagementGiftCards",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCardManagementGiftCards_GiftCardTemplateId",
                table: "GiftCardManagementGiftCards",
                column: "GiftCardTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GiftCardManagementGiftCards_Code",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.DropIndex(
                name: "IX_GiftCardManagementGiftCards_GiftCardTemplateId",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "GiftCardManagementGiftCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
