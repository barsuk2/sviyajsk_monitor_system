using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class geocords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_CulcherObject_buildingid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_buildingid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "buildingid",
                table: "Point");

            migrationBuilder.AddColumn<float>(
                name: "altitude",
                table: "Point",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "latitude",
                table: "Point",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "longitude",
                table: "Point",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "altitude",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Point");

            migrationBuilder.AddColumn<int>(
                name: "buildingid",
                table: "Point",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_buildingid",
                table: "Point",
                column: "buildingid");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_CulcherObject_buildingid",
                table: "Point",
                column: "buildingid",
                principalTable: "CulcherObject",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
