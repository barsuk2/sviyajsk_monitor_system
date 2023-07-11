using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class Ref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_Spectr_spectrid",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_DecoreElement_CulcherObject_culcherObjectid",
                table: "DecoreElement");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_DecoreElementRegion_decoreregionid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_decoreregionid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_DecoreElement_culcherObjectid",
                table: "DecoreElement");

            migrationBuilder.DropIndex(
                name: "IX_ChemistryElMassDole_spectrid",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "decoreregionid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "culcherObjectid",
                table: "DecoreElement");

            migrationBuilder.DropColumn(
                name: "spectrid",
                table: "ChemistryElMassDole");

            migrationBuilder.DropTable(
                name: "DecoreElementRegion");

            migrationBuilder.DropTable(
                name: "Spectr");

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
                    name = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.AddColumn<int>(
                name: "buildingElementid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "decoreElementid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "elementid",
                table: "DecoreElement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_buildingElementid",
                table: "Point",
                column: "buildingElementid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_decoreElementid",
                table: "Point",
                column: "decoreElementid");

            migrationBuilder.CreateIndex(
                name: "IX_DecoreElement_elementid",
                table: "DecoreElement",
                column: "elementid");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingElement_elementid",
                table: "BuildingElement",
                column: "elementid");

            migrationBuilder.AddForeignKey(
                name: "FK_DecoreElement_element_elementid",
                table: "DecoreElement",
                column: "elementid",
                principalTable: "element",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecoreElement_element_elementid",
                table: "DecoreElement");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_BuildingElement_buildingElementid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_DecoreElement_decoreElementid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_buildingElementid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_decoreElementid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_DecoreElement_elementid",
                table: "DecoreElement");

            migrationBuilder.DropColumn(
                name: "buildingElementid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "decoreElementid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "elementid",
                table: "DecoreElement");

            migrationBuilder.DropTable(
                name: "BuildingElement");

            migrationBuilder.CreateTable(
                name: "DecoreElementRegion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    decoreelementid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecoreElementRegion", x => x.id);
                    table.ForeignKey(
                        name: "FK_DecoreElementRegion_DecoreElement_decoreelementid",
                        column: x => x.decoreelementid,
                        principalTable: "DecoreElement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spectr",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    colorid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    photoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spectr", x => x.id);
                    table.ForeignKey(
                        name: "FK_Spectr_Color_colorid",
                        column: x => x.colorid,
                        principalTable: "Color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spectr_Photo_photoid",
                        column: x => x.photoid,
                        principalTable: "Photo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "decoreregionid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "culcherObjectid",
                table: "DecoreElement",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "spectrid",
                table: "ChemistryElMassDole",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_decoreregionid",
                table: "Point",
                column: "decoreregionid");

            migrationBuilder.CreateIndex(
                name: "IX_DecoreElement_culcherObjectid",
                table: "DecoreElement",
                column: "culcherObjectid");

            migrationBuilder.CreateIndex(
                name: "IX_ChemistryElMassDole_spectrid",
                table: "ChemistryElMassDole",
                column: "spectrid");

            migrationBuilder.CreateIndex(
                name: "IX_DecoreElementRegion_decoreelementid",
                table: "DecoreElementRegion",
                column: "decoreelementid");

            migrationBuilder.CreateIndex(
                name: "IX_Spectr_colorid",
                table: "Spectr",
                column: "colorid");

            migrationBuilder.CreateIndex(
                name: "IX_Spectr_photoid",
                table: "Spectr",
                column: "photoid");

            migrationBuilder.AddForeignKey(
                name: "FK_ChemistryElMassDole_Spectr_spectrid",
                table: "ChemistryElMassDole",
                column: "spectrid",
                principalTable: "Spectr",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DecoreElement_CulcherObject_culcherObjectid",
                table: "DecoreElement",
                column: "culcherObjectid",
                principalTable: "CulcherObject",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_DecoreElementRegion_decoreregionid",
                table: "Point",
                column: "decoreregionid",
                principalTable: "DecoreElementRegion",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
