using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AddAdditionalColumnsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Student",
                table: "user",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "user");

            migrationBuilder.DropColumn(
                name: "School",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Student",
                table: "user");
        }
    }
}
