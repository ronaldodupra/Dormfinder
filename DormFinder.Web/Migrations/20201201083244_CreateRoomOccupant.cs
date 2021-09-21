using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class CreateRoomOccupant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomOccupant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()"),
                    UpdatedById = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    BedspaceId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    SecurityDeposit = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    RentAdvance = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomOccupant", x => x.Id);
                });
            migrationBuilder.CreateIndex(
               name: "IX_roomOccupant_RoomId",
               table: "roomoccupant",
               column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_roomOccupant_Bedspace",
                table: "roomoccupant",
                column: "BedSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_roomOccupant_Tenant",
                table: "roomoccupant",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_roomOccupant_room_RoomId",
                table: "roomoccupant",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "FK_roomOccupant_Bedspace_BedspaceId",
               table: "roomoccupant",
               column: "BedspaceId",
               principalTable: "bedspace",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "FK_roomOccupant_tenant_Id",
               table: "roomoccupant",
               column: "TenantId",
               principalTable: "tenant",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomOccupant");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "room",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
            
            migrationBuilder.DropForeignKey(
            name: "IX_roomOccupant_RoomId",
            table: "roomoccupant");
            
            migrationBuilder.DropIndex(
            name: "IX_roomOccupant_Bedspace",
            table: "roomoccupant");
            
            migrationBuilder.DropForeignKey(
            name: "FK_roomOccupant_room_RoomId",
            table: "roomoccupant");
            
            migrationBuilder.DropForeignKey(
            name: "FK_roomOccupant_Bedspace_BedspaceId",
            table: "roomoccupant");

            migrationBuilder.DropForeignKey(
           name: "FK_roomOccupant_tenant_Id",
           table: "roomoccupant");

            migrationBuilder.DropIndex(
            name: "IX_roomOccupant_Tenant",
            table: "roomoccupant");
        }
    }
}
