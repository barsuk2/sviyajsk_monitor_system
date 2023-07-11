using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class PhotosMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Point_Pointid",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Sector_Sectorid",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.AlterColumn<string>(
                name: "shifr",
                table: "Point",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_photos",
                table: "Photo",
                column: "id");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "analyzes",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_Sector_Sectorid",
                table: "Photo",
                column: "Sectorid",
                principalTable: "Sector",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_Point_pointid",
                table: "Photo",
                column: "Pointid",
                principalTable: "Point",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "Pointid",
                table: "Photo",
                newName: "pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_Sectorid",
                table: "Photo",
                newName: "IX_photos_Sectorid");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_Pointid",
                table: "Photo",
                newName: "IX_photos_pointid");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "photos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_Sector_Sectorid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_Point_pointid",
                table: "photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_photos",
                table: "photos");

            migrationBuilder.AlterColumn<string>(
                name: "shifr",
                table: "Point",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "photos",
                column: "id");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "analyzes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Point_Pointid",
                table: "photos",
                column: "pointid",
                principalTable: "Point",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Sector_Sectorid",
                table: "photos",
                column: "Sectorid",
                principalTable: "Sector",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "pointid",
                table: "photos",
                newName: "Pointid");

            migrationBuilder.RenameIndex(
                name: "IX_photos_pointid",
                table: "photos",
                newName: "IX_Photo_Pointid");

            migrationBuilder.RenameIndex(
                name: "IX_photos_Sectorid",
                table: "photos",
                newName: "IX_Photo_Sectorid");

            migrationBuilder.RenameTable(
                name: "photos",
                newName: "Photo");
        }
    }
}
