using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AddOrganizationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "tenant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "roompic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "roominclusion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "lead",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "inclusion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Floor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "charge",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "BuildingAmenity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "building",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "roompic");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "roominclusion");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "room");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "role");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "inclusion");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Floor");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "charge");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "BuildingAmenity");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "building");
        }
    }
}
