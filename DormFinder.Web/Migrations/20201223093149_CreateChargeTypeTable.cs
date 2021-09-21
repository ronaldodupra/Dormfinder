using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class CreateChargeTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "charge");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "charge",
                type: "decimal(15,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ChargeTypeId",
                table: "charge",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "charge",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "charge",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "chargetype",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()"),
                    UpdatedById = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    DefaultAmount = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    IsVatable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chargetype", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_charge_ChargeTypeId",
                table: "charge",
                column: "ChargeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_charge_chargetype_ChargeTypeId",
                table: "charge",
                column: "ChargeTypeId",
                principalTable: "chargetype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_charge_chargetype_ChargeTypeId",
                table: "charge");

            migrationBuilder.DropTable(
                name: "chargetype");

            migrationBuilder.DropIndex(
                name: "IX_charge_ChargeTypeId",
                table: "charge");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "charge");

            migrationBuilder.DropColumn(
                name: "ChargeTypeId",
                table: "charge");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "charge");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "charge");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "charge",
                type: "varchar(50) CHARACTER SET utf8mb4",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
