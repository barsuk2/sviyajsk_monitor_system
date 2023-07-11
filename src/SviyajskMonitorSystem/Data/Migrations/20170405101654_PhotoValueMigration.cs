using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class PhotoValueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_DecoreElement_DecoreElementid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_BuildingElement_buildingElementid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_DecoreElement_decoreElementid",
                table: "Point");

            migrationBuilder.DropTable(
                name: "BuildingElement");

            migrationBuilder.DropTable(
                name: "DecoreElement");

            migrationBuilder.DropIndex(
                name: "IX_Point_buildingElementid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_decoreElementid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_photos_DecoreElementid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "buildingElementid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "decoreElementid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "DecoreElementid",
                table: "photos");

            migrationBuilder.AddColumn<long>(
                name: "PhotoAttributeValueid",
                table: "photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pointid",
                table: "treeelements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_photos_PhotoAttributeValueid",
                table: "photos",
                column: "PhotoAttributeValueid");

            migrationBuilder.CreateIndex(
                name: "IX_treeelements_Pointid",
                table: "treeelements",
                column: "Pointid");

            migrationBuilder.AddForeignKey(
                name: "FK_treeelements_Point_Pointid",
                table: "treeelements",
                column: "Pointid",
                principalTable: "Point",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_AbstractAttributeValue_PhotoAttributeValueid",
                table: "photos",
                column: "PhotoAttributeValueid",
                principalTable: "AbstractAttributeValue",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_treeelements_Point_Pointid",
                table: "treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_AbstractAttributeValue_PhotoAttributeValueid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_PhotoAttributeValueid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_treeelements_Pointid",
                table: "treeelements");

            migrationBuilder.DropColumn(
                name: "PhotoAttributeValueid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Pointid",
                table: "treeelements");

            migrationBuilder.AddColumn<int>(
                name: "buildingElementid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "decoreElementid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecoreElementid",
                table: "photos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BuildingElement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    elementid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    shifr = table.Column<string>(nullable: false),
                    typeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingElement", x => x.id);
                    table.ForeignKey(
                        name: "FK_BuildingElement_element_elementid",
                        column: x => x.elementid,
                        principalTable: "element",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildingElement_BETypes_typeid",
                        column: x => x.typeid,
                        principalTable: "BETypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DecoreElement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    elementid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecoreElement", x => x.id);
                    table.ForeignKey(
                        name: "FK_DecoreElement_element_elementid",
                        column: x => x.elementid,
                        principalTable: "element",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Point_buildingElementid",
                table: "Point",
                column: "buildingElementid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_decoreElementid",
                table: "Point",
                column: "decoreElementid");

            migrationBuilder.CreateIndex(
                name: "IX_photos_DecoreElementid",
                table: "photos",
                column: "DecoreElementid");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingElement_elementid",
                table: "BuildingElement",
                column: "elementid");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingElement_typeid",
                table: "BuildingElement",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_DecoreElement_elementid",
                table: "DecoreElement",
                column: "elementid");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_DecoreElement_DecoreElementid",
                table: "photos",
                column: "DecoreElementid",
                principalTable: "DecoreElement",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_BuildingElement_buildingElementid",
                table: "Point",
                column: "buildingElementid",
                principalTable: "BuildingElement",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_DecoreElement_decoreElementid",
                table: "Point",
                column: "decoreElementid",
                principalTable: "DecoreElement",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
