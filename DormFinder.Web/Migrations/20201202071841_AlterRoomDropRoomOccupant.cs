using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AlterRoomDropRoomOccupant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roomoccupant");

            migrationBuilder.AddColumn<int>(
                name: "AdvanceRent",
                table: "room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Occupant",
                table: "room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SecurityDeposit",
                table: "room",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvanceRent",
                table: "room");

            migrationBuilder.DropColumn(
                name: "Occupant",
                table: "room");

            migrationBuilder.DropColumn(
                name: "SecurityDeposit",
                table: "room");

            migrationBuilder.CreateTable(
                name: "roomoccupant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BedspaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    RentAdvance = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SecurityDeposit = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()"),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomoccupant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roomoccupant_bedspace_BedspaceId",
                        column: x => x.BedspaceId,
                        principalTable: "bedspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roomoccupant_tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roomoccupant_BedspaceId",
                table: "roomoccupant",
                column: "BedspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_roomoccupant_TenantId",
                table: "roomoccupant",
                column: "TenantId");
        }
    }
}
