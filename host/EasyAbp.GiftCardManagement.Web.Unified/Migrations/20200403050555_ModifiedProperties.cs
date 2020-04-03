using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.GiftCardManagement.Migrations
{
    public partial class ModifiedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueTime",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.DropColumn(
                name: "ExtraInformation",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiration",
                table: "GiftCardManagementGiftCards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "GiftCardManagementGiftCards");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueTime",
                table: "GiftCardManagementGiftCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ExtraInformation",
                table: "GiftCardManagementGiftCards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
