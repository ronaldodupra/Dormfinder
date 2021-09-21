using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AddTenantRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tenant",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tenant_ContractId",
                table: "tenant",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenant_RoomId",
                table: "tenant",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_UserId",
                table: "tenant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_contract_RoomId",
                table: "contract",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_contract_room_RoomId",
                table: "contract",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_contract_ContractId",
                table: "tenant",
                column: "ContractId",
                principalTable: "contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_room_RoomId",
                table: "tenant",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_user_UserId",
                table: "tenant",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contract_room_RoomId",
                table: "contract");

            migrationBuilder.DropForeignKey(
                name: "FK_tenant_contract_ContractId",
                table: "tenant");

            migrationBuilder.DropForeignKey(
                name: "FK_tenant_room_RoomId",
                table: "tenant");

            migrationBuilder.DropForeignKey(
                name: "FK_tenant_user_UserId",
                table: "tenant");

            migrationBuilder.DropIndex(
                name: "IX_tenant_ContractId",
                table: "tenant");

            migrationBuilder.DropIndex(
                name: "IX_tenant_RoomId",
                table: "tenant");

            migrationBuilder.DropIndex(
                name: "IX_tenant_UserId",
                table: "tenant");

            migrationBuilder.DropIndex(
                name: "IX_contract_RoomId",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "contract");
        }
    }
}
