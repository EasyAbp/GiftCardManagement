using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.GiftCardManagement.Migrations
{
    public partial class AddAnonymousConsumptionAllowedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnonymousConsumptionAllowed",
                table: "GiftCardManagementGiftCardTemplates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration",
                table: "GiftCardManagementGiftCards",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnonymousConsumptionAllowed",
                table: "GiftCardManagementGiftCardTemplates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration",
                table: "GiftCardManagementGiftCards",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
