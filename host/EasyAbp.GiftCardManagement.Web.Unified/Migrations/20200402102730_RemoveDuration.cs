using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.GiftCardManagement.Migrations
{
    public partial class RemoveDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "GiftCardManagementGiftCardTemplates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "GiftCardManagementGiftCardTemplates",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
