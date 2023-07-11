using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class ETypeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_values_types_typeid",
                table: "values");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "values",
                newName: "typeId");

            migrationBuilder.RenameIndex(
                name: "IX_values_typeid",
                table: "values",
                newName: "IX_values_typeId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "types",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "types",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "entitytypeId",
                table: "attributekeys",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_attributekeys_entitytypeId",
                table: "attributekeys",
                column: "entitytypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_attributekeys_types_entitytypeId",
                table: "attributekeys",
                column: "entitytypeId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_values_types_typeId",
                table: "values",
                column: "typeId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attributekeys_types_entitytypeId",
                table: "attributekeys");

            migrationBuilder.DropForeignKey(
                name: "FK_values_types_typeId",
                table: "values");

            migrationBuilder.DropIndex(
                name: "IX_attributekeys_entitytypeId",
                table: "attributekeys");

            migrationBuilder.DropColumn(
                name: "entitytypeId",
                table: "attributekeys");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "values",
                newName: "typeid");

            migrationBuilder.RenameIndex(
                name: "IX_values_typeId",
                table: "values",
                newName: "IX_values_typeid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "types",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "types",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_values_types_typeid",
                table: "values",
                column: "typeid",
                principalTable: "types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
