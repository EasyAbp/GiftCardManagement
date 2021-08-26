using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Migrations
{
    public partial class ChangedDbTablePrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftCardManagementGiftCardTemplates",
                table: "GiftCardManagementGiftCardTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftCardManagementGiftCards",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.RenameTable(
                name: "GiftCardManagementGiftCardTemplates",
                newName: "EasyAbpGiftCardManagementGiftCardTemplates");

            migrationBuilder.RenameTable(
                name: "GiftCardManagementGiftCards",
                newName: "EasyAbpGiftCardManagementGiftCards");

            migrationBuilder.RenameIndex(
                name: "IX_GiftCardManagementGiftCards_GiftCardTemplateId",
                table: "EasyAbpGiftCardManagementGiftCards",
                newName: "IX_EasyAbpGiftCardManagementGiftCards_GiftCardTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_GiftCardManagementGiftCards_Code",
                table: "EasyAbpGiftCardManagementGiftCards",
                newName: "IX_EasyAbpGiftCardManagementGiftCards_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpGiftCardManagementGiftCardTemplates",
                table: "EasyAbpGiftCardManagementGiftCardTemplates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpGiftCardManagementGiftCards",
                table: "EasyAbpGiftCardManagementGiftCards",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpGiftCardManagementGiftCardTemplates",
                table: "EasyAbpGiftCardManagementGiftCardTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpGiftCardManagementGiftCards",
                table: "EasyAbpGiftCardManagementGiftCards");

            migrationBuilder.RenameTable(
                name: "EasyAbpGiftCardManagementGiftCardTemplates",
                newName: "GiftCardManagementGiftCardTemplates");

            migrationBuilder.RenameTable(
                name: "EasyAbpGiftCardManagementGiftCards",
                newName: "GiftCardManagementGiftCards");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpGiftCardManagementGiftCards_GiftCardTemplateId",
                table: "GiftCardManagementGiftCards",
                newName: "IX_GiftCardManagementGiftCards_GiftCardTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpGiftCardManagementGiftCards_Code",
                table: "GiftCardManagementGiftCards",
                newName: "IX_GiftCardManagementGiftCards_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftCardManagementGiftCardTemplates",
                table: "GiftCardManagementGiftCardTemplates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftCardManagementGiftCards",
                table: "GiftCardManagementGiftCards",
                column: "Id");
        }
    }
}
