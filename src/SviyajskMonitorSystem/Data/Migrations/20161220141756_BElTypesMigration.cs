using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class BElTypesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BETypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BETypes", x => x.id);
                });

            migrationBuilder.AddColumn<string>(
                name: "shifr",
                table: "BuildingElement",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "typeid",
                table: "BuildingElement",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "storageplaces",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Person",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Person",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "element",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "DecoreElement",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "CulcherObject",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Color",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "shortname",
                table: "ChemistryElement",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "ChemistryElement",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "BuildingElement",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingElement_typeid",
                table: "BuildingElement",
                column: "typeid");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingElement_BETypes_typeid",
                table: "BuildingElement",
                column: "typeid",
                principalTable: "BETypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingElement_BETypes_typeid",
                table: "BuildingElement");

            migrationBuilder.DropIndex(
                name: "IX_BuildingElement_typeid",
                table: "BuildingElement");

            migrationBuilder.DropColumn(
                name: "shifr",
                table: "BuildingElement");

            migrationBuilder.DropColumn(
                name: "typeid",
                table: "BuildingElement");

            migrationBuilder.DropTable(
                name: "BETypes");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "storageplaces",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Person",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Person",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "element",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "DecoreElement",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "CulcherObject",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Color",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "shortname",
                table: "ChemistryElement",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "ChemistryElement",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "BuildingElement",
                nullable: true);
        }
    }
}
