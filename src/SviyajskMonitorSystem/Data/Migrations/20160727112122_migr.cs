using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "culcherObjectid",
                table: "DecoreElement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DecoreElement_culcherObjectid",
                table: "DecoreElement",
                column: "culcherObjectid");

            migrationBuilder.AddForeignKey(
                name: "FK_DecoreElement_CulcherObject_culcherObjectid",
                table: "DecoreElement",
                column: "culcherObjectid",
                principalTable: "CulcherObject",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecoreElement_CulcherObject_culcherObjectid",
                table: "DecoreElement");

            migrationBuilder.DropIndex(
                name: "IX_DecoreElement_culcherObjectid",
                table: "DecoreElement");

            migrationBuilder.DropColumn(
                name: "culcherObjectid",
                table: "DecoreElement");
        }
    }
}
