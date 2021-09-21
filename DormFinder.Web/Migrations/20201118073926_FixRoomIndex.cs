using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class FixRoomIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_lead_RoomId",
                table: "lead",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_room_RoomId",
                table: "lead",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lead_room_RoomId",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_RoomId",
                table: "lead");
        }
    }
}
