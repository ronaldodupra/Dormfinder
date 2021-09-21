using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AddColumnLeadUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "lead",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_lead_UserId",
                table: "lead",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_user_UserId",
                table: "lead",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lead_user_UserId",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_UserId",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "lead");

        }
    }
}
