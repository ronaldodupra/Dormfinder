using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormFinder.Web.Migrations
{
    public partial class AddDefaultBuildingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "buildingtype",
                new string[]
                {
                    "Id",
                    "CreatedAt",
                    "CreatedById",
                    "UpdatedAt",
                    "UpdatedById",
                    "Description"
                },
                new object[]
                {
                    1,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    "Dormitory"
                });

            migrationBuilder.InsertData(
                "buildingtype",
                new string[]
                {
                    "Id",
                    "CreatedAt",
                    "CreatedById",
                    "UpdatedAt",
                    "UpdatedById",
                    "Description"
                },
                new object[]
                {
                    2,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    DateTime.FromFileTimeUtc(132506763430000000),
                    1,
                    "Condominium"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("buildingtype", "Id", 1);
            migrationBuilder.DeleteData("buildingtype", "Id", 2);
        }
    }
}
