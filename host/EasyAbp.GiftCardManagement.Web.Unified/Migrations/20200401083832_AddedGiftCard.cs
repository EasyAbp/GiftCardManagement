using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.GiftCardManagement.Migrations
{
    public partial class AddedGiftCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiftCardManagementGiftCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    GiftCardTemplateId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DueTime = table.Column<DateTime>(nullable: false),
                    ConsumptionUserId = table.Column<Guid>(nullable: true),
                    ConsumptionTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCardManagementGiftCards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiftCardManagementGiftCards");
        }
    }
}
