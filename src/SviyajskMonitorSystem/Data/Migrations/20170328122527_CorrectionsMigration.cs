using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class CorrectionsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemid",
                table: "AbstractAttributeValue");

            migrationBuilder.RenameColumn(
                name: "listname",
                table: "AbstractAttributeValue",
                newName: "stringvalue");

            migrationBuilder.AddColumn<int>(
                name: "valueid",
                table: "AbstractAttributeValue",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbstractAttributeValue_valueid",
                table: "AbstractAttributeValue",
                column: "valueid");

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractAttributeValue_values_valueid",
                table: "AbstractAttributeValue",
                column: "valueid",
                principalTable: "values",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractAttributeValue_values_valueid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropIndex(
                name: "IX_AbstractAttributeValue_valueid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropColumn(
                name: "valueid",
                table: "AbstractAttributeValue");

            migrationBuilder.RenameColumn(
                name: "stringvalue",
                table: "AbstractAttributeValue",
                newName: "listname");

            migrationBuilder.AddColumn<int>(
                name: "itemid",
                table: "AbstractAttributeValue",
                nullable: true);
        }
    }
}
