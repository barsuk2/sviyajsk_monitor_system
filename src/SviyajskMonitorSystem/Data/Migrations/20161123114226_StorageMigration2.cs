using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class StorageMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_storageplaces_Storageid",
                table: "Point");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_storageplaces_storageid",
                table: "Point",
                column: "Storageid",
                principalTable: "storageplaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "Storageid",
                table: "Point",
                newName: "storageid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_Storageid",
                table: "Point",
                newName: "IX_Point_storageid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_storageplaces_storageid",
                table: "Point");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_storageplaces_Storageid",
                table: "Point",
                column: "storageid",
                principalTable: "storageplaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "storageid",
                table: "Point",
                newName: "Storageid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_storageid",
                table: "Point",
                newName: "IX_Point_Storageid");
        }
    }
}
