using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class CreateUtilityReadingAndUtilityTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "utility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtilityTypeId",
                table: "utility",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "utilityreading",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()"),
                    UpdatedById = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    UtilityId = table.Column<int>(nullable: false),
                    Reading = table.Column<decimal>(type: "decimal(15,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilityreading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_utilityreading_utility_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "utility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilitytype",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()"),
                    UpdatedById = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilitytype", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_utility_UtilityTypeId",
                table: "utility",
                column: "UtilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_utilityreading_UtilityId",
                table: "utilityreading",
                column: "UtilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_utility_utilitytype_UtilityTypeId",
                table: "utility",
                column: "UtilityTypeId",
                principalTable: "utilitytype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_utility_utilitytype_UtilityTypeId",
                table: "utility");

            migrationBuilder.DropTable(
                name: "utilityreading");

            migrationBuilder.DropTable(
                name: "utilitytype");

            migrationBuilder.DropIndex(
                name: "IX_utility_UtilityTypeId",
                table: "utility");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "utility");

            migrationBuilder.DropColumn(
                name: "UtilityTypeId",
                table: "utility");
        }
    }
}
