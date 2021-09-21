using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class addColumnContractLeadId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AddColumn<int>(
               name: "LeadId",
               table: "contract",
               nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_contract_LeadId",
                table: "contract",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_contract_lead_LeadId",
                table: "contract",
                column: "LeadId",
                principalTable: "lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "LeadId",
               table: "contract");

            migrationBuilder.DropForeignKey(
               name: "IX_contract_LeadId",
               table: "contract");

            migrationBuilder.DropForeignKey(
                name: "FK_contract_lead_LeadId",
                table: "contract");
        }
    }
}
