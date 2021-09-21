using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class RenameOrganizationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userorganization_organization_OrganizationId",
                table: "userorganization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_organization",
                table: "organization");

            migrationBuilder.Sql(@"
                ALTER TABLE `organization`
                CHANGE COLUMN `RowId` `Id` INT(11) NOT NULL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_organization",
                table: "organization",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userorganization_organization_OrganizationId",
                table: "userorganization",
                column: "OrganizationId",
                principalTable: "organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userorganization_organization_OrganizationId",
                table: "userorganization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_organization",
                table: "organization");

            migrationBuilder.Sql(@"
                ALTER TABLE `organization`
                CHANGE COLUMN `Id` `RowId` INT(11) NOT NULL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_organization",
                table: "organization",
                column: "RowId");

            migrationBuilder.AddForeignKey(
                name: "FK_userorganization_organization_OrganizationId",
                table: "userorganization",
                column: "OrganizationId",
                principalTable: "organization",
                principalColumn: "RowId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
