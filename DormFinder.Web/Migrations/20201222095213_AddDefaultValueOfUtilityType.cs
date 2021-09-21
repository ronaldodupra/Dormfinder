using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AddDefaultValueOfUtilityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "utilitytype",
                new string[]
                {
                    "Id",
                    "CreatedAt",
                    "CreatedById",
                    "UpdatedAt",
                    "UpdatedById",
                    "Name"
                },
                new object[]
                {
                    1,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    "Water"
                });

            migrationBuilder.InsertData(
                "utilitytype",
                new string[]
                {
                    "Id",
                    "CreatedAt",
                    "CreatedById",
                    "UpdatedAt",
                    "UpdatedById",
                    "Name"
                },
                new object[]
                {
                    2,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    "Electricity"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("buildingtype", "Id", 1);
            migrationBuilder.DeleteData("buildingtype", "Id", 2);
        }
    }
}
