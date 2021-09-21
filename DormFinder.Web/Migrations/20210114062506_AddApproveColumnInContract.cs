using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AddApproveColumnInContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approve",
                table: "contract",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approve",
                table: "contract");
        }
    }
}
