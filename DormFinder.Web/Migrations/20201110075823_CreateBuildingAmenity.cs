using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class CreateBuildingAmenity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_inclusion_roominclusion_Id",
               table: "inclusion");

            migrationBuilder.DropForeignKey(
               name: "FK_roominclusion_inclusion_InclusionId",
               table: "roomInclusion");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "inclusion",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_roominclusion_inclusion_InclusionId",
                table: "roomInclusion",
                column: "InclusionId",
                principalTable: "inclusion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
                name: "FK_amenity_building_BuildingId",
                table: "amenity");


            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "amenity",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "BuildingAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()"),
                    UpdatedById = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false),
                    AmenityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAmenity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingAmenity_amenity_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "amenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingAmenity_building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAmenity_AmenityId",
                table: "BuildingAmenity",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAmenity_BuildingId",
                table: "BuildingAmenity",
                column: "BuildingId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingAmenity");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "amenity",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "BuildingAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AmenityId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP()"),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingAmenities_amenity_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "amenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingAmenities_building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAmenities_AmenityId",
                table: "BuildingAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAmenities_BuildingId",
                table: "BuildingAmenities",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_amenity_BuildingAmenities_Id",
                table: "amenity",
                column: "Id",
                principalTable: "BuildingAmenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
