using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class TreesFixesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roots_Treeelements_rootid",
                table: "Roots");

            migrationBuilder.DropIndex(
                name: "IX_Roots_rootid",
                table: "Roots");

            migrationBuilder.DropColumn(
                name: "rootid",
                table: "Roots");

            migrationBuilder.AddColumn<int>(
                name: "rootid",
                table: "Treeelements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treeelements_rootid",
                table: "Treeelements",
                column: "rootid");

            migrationBuilder.AddForeignKey(
                name: "FK_Treeelements_Roots_rootid",
                table: "Treeelements",
                column: "rootid",
                principalTable: "Roots",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treeelements_Roots_rootid",
                table: "Treeelements");

            migrationBuilder.DropIndex(
                name: "IX_Treeelements_rootid",
                table: "Treeelements");

            migrationBuilder.DropColumn(
                name: "rootid",
                table: "Treeelements");

            migrationBuilder.AddColumn<long>(
                name: "rootid",
                table: "Roots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roots_rootid",
                table: "Roots",
                column: "rootid");

            migrationBuilder.AddForeignKey(
                name: "FK_Roots_Treeelements_rootid",
                table: "Roots",
                column: "rootid",
                principalTable: "Treeelements",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
