using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AlterRoomFloorIdToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_room_Floor_FloorId",
                table: "room");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "room",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_room_Floor_FloorId",
                table: "room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_room_Floor_FloorId",
                table: "room");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "room",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AddForeignKey(
                name: "FK_room_Floor_FloorId",
                table: "room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
