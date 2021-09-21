using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class DropColumnPriceToRoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "roomtype");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "roomtype",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP()");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "roomtype",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "roomtype",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()");

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "roomtype",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "roomtype");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "roomtype");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "roomtype");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "roomtype");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "roomtype",
                type: "decimal(15,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
