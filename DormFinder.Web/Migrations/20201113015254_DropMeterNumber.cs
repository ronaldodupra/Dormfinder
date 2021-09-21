using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class DropMeterNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectricMeterNumber",
                table: "room");

            migrationBuilder.DropColumn(
                name: "WaterMeterNumber",
                table: "room");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "roomtype",
                type: "decimal(15,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "roomtype",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,4)");

            migrationBuilder.AddColumn<string>(
                name: "ElectricMeterNumber",
                table: "room",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaterMeterNumber",
                table: "room",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
