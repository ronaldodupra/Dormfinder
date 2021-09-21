using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AlterFloor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "room");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Floor");

            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "bedspace");

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Floor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "bedspace",
                nullable: false,
                defaultValue: 0,
                comment: "1=Available,2=Hold,3=Reserved,4=Rented");

            migrationBuilder.CreateIndex(
                name: "IX_room_FloorId",
                table: "room",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingId",
                table: "Floor",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_bedspace_RoomId",
                table: "bedspace",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_bedspace_room_RoomId",
                table: "bedspace",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_building_BuildingId",
                table: "Floor",
                column: "BuildingId",
                principalTable: "building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_room_Floor_FloorId",
                table: "room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bedspace_room_RoomId",
                table: "bedspace");

            migrationBuilder.DropForeignKey(
                name: "FK_Floor_building_BuildingId",
                table: "Floor");

            migrationBuilder.DropForeignKey(
                name: "FK_room_Floor_FloorId",
                table: "room");

            migrationBuilder.DropIndex(
                name: "IX_room_FloorId",
                table: "room");

            migrationBuilder.DropIndex(
                name: "IX_Floor_BuildingId",
                table: "Floor");

            migrationBuilder.DropIndex(
                name: "IX_bedspace_RoomId",
                table: "bedspace");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "room");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Floor");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "bedspace");

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Floor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "bedspace",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
