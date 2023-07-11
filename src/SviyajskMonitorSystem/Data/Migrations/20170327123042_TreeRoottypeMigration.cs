using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class TreeRoottypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "treetypeid",
                table: "roots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_roots_treetypeid",
                table: "roots",
                column: "treetypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_roots_treetypes_treetypeid",
                table: "roots",
                column: "treetypeid",
                principalTable: "treetypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roots_treetypes_treetypeid",
                table: "roots");

            migrationBuilder.DropIndex(
                name: "IX_roots_treetypeid",
                table: "roots");

            migrationBuilder.DropColumn(
                name: "treetypeid",
                table: "roots");
        }
    }
}
