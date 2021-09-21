using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class RenameColumnPriceToBasicRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE `room` CHANGE COLUMN `Price` `BasicRent` DECIMAL(15, 4) NULL DEFAULT NULL");

            migrationBuilder.Sql("ALTER TABLE `contract` CHANGE COLUMN `Price` `BasicRent` DECIMAL(15, 4) NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE `room` CHANGE COLUMN `BasicRent` `Price` DECIMAL(10, 2) NULL DEFAULT NULL");

            migrationBuilder.Sql("ALTER TABLE `contract` CHANGE COLUMN `BasicRent` `Price` DECIMAL(15, 4) NOT NULL");
        }
    }
}
