using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bacterya",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rodname = table.Column<string>(nullable: true),
                    vidname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bacterya", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ChemistryElement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fullname = table.Column<string>(nullable: true),
                    shortname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemistryElement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ChronoCodes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronoCodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CulcherObject",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulcherObject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ElementType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    elementtype = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tree",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vector3",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    x = table.Column<float>(nullable: false),
                    y = table.Column<float>(nullable: false),
                    z = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vector3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    culcherobjectid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    shifr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.id);
                    table.ForeignKey(
                        name: "FK_Place_CulcherObject_culcherobjectid",
                        column: x => x.culcherobjectid,
                        principalTable: "CulcherObject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    placeid = table.Column<int>(nullable: true),
                    shifr = table.Column<string>(nullable: true),
                    typeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.id);
                    table.ForeignKey(
                        name: "FK_Element_Place_placeid",
                        column: x => x.placeid,
                        principalTable: "Place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_ElementType_typeid",
                        column: x => x.typeid,
                        principalTable: "ElementType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    buildingid = table.Column<int>(nullable: true),
                    coordinatesid = table.Column<int>(nullable: true),
                    dateofget = table.Column<DateTime>(nullable: false),
                    directionid = table.Column<int>(nullable: true),
                    elementid = table.Column<int>(nullable: true),
                    personid = table.Column<int>(nullable: true),
                    placedescription = table.Column<string>(nullable: true),
                    shifr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.id);
                    table.ForeignKey(
                        name: "FK_Point_CulcherObject_buildingid",
                        column: x => x.buildingid,
                        principalTable: "CulcherObject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Point_Vector3_coordinatesid",
                        column: x => x.coordinatesid,
                        principalTable: "Vector3",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Point_Vector3_directionid",
                        column: x => x.directionid,
                        principalTable: "Vector3",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Point_Element_elementid",
                        column: x => x.elementid,
                        principalTable: "Element",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Point_Person_personid",
                        column: x => x.personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "analyzes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    number = table.Column<string>(nullable: true),
                    personid = table.Column<int>(nullable: true),
                    pointid = table.Column<int>(nullable: true),
                    type = table.Column<int>(nullable: false),
                    codeid = table.Column<int>(nullable: true),
                    roundscount = table.Column<int>(nullable: true),
                    treeid = table.Column<int>(nullable: true),
                    count = table.Column<long>(nullable: true),
                    error = table.Column<int>(nullable: true),
                    labdatingnumber = table.Column<int>(nullable: true),
                    rcdate = table.Column<int>(nullable: true),
                    colorid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analyzes", x => x.id);
                    table.ForeignKey(
                        name: "FK_analyzes_Person_personid",
                        column: x => x.personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_analyzes_Point_pointid",
                        column: x => x.pointid,
                        principalTable: "Point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_analyzes_ChronoCodes_codeid",
                        column: x => x.codeid,
                        principalTable: "ChronoCodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_analyzes_Tree_treeid",
                        column: x => x.treeid,
                        principalTable: "Tree",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_analyzes_Color_colorid",
                        column: x => x.colorid,
                        principalTable: "Color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "datings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dchanalyzeid = table.Column<int>(nullable: true),
                    probability = table.Column<double>(nullable: false),
                    rcanalyzeid = table.Column<int>(nullable: true),
                    year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datings", x => x.id);
                    table.ForeignKey(
                        name: "FK_datings_analyzes_dchanalyzeid",
                        column: x => x.dchanalyzeid,
                        principalTable: "analyzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_datings_analyzes_rcanalyzeid",
                        column: x => x.rcanalyzeid,
                        principalTable: "analyzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HasBactery",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bacteryaid = table.Column<int>(nullable: true),
                    celluloznaya = table.Column<int>(nullable: false),
                    count = table.Column<long>(nullable: false),
                    lingnirazr = table.Column<int>(nullable: false),
                    mbanalyzeid = table.Column<int>(nullable: true),
                    proteznaya = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasBactery", x => x.id);
                    table.ForeignKey(
                        name: "FK_HasBactery_Bacterya_bacteryaid",
                        column: x => x.bacteryaid,
                        principalTable: "Bacterya",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HasBactery_analyzes_mbanalyzeid",
                        column: x => x.mbanalyzeid,
                        principalTable: "analyzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    esanalyzeid = table.Column<int>(nullable: true),
                    number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sector_analyzes_esanalyzeid",
                        column: x => x.esanalyzeid,
                        principalTable: "analyzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pointid = table.Column<int>(nullable: true),
                    Sectorid = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Photo_Point_Pointid",
                        column: x => x.Pointid,
                        principalTable: "Point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_Sector_Sectorid",
                        column: x => x.Sectorid,
                        principalTable: "Sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spectr",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateTable(
                name: "ChemistryElMassDole",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    chelementid = table.Column<int>(nullable: true),
                    rfanalyzeid = table.Column<int>(nullable: true),
                    spectrid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemistryElMassDole", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChemistryElMassDole_ChemistryElement_chelementid",
                        column: x => x.chelementid,
                        principalTable: "ChemistryElement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChemistryElMassDole_analyzes_rfanalyzeid",
                        column: x => x.rfanalyzeid,
                        principalTable: "analyzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChemistryElMassDole_Spectr_spectrid",
                        column: x => x.spectrid,
                        principalTable: "Spectr",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<bool>(
                name: "isrightinfo",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_analyzes_personid",
                table: "analyzes",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_analyzes_pointid",
                table: "analyzes",
                column: "pointid");

            migrationBuilder.CreateIndex(
                name: "IX_analyzes_codeid",
                table: "analyzes",
                column: "codeid");

            migrationBuilder.CreateIndex(
                name: "IX_analyzes_treeid",
                table: "analyzes",
                column: "treeid");

            migrationBuilder.CreateIndex(
                name: "IX_analyzes_colorid",
                table: "analyzes",
                column: "colorid");

            migrationBuilder.CreateIndex(
                name: "IX_ChemistryElMassDole_chelementid",
                table: "ChemistryElMassDole",
                column: "chelementid");

            migrationBuilder.CreateIndex(
                name: "IX_ChemistryElMassDole_rfanalyzeid",
                table: "ChemistryElMassDole",
                column: "rfanalyzeid");

            migrationBuilder.CreateIndex(
                name: "IX_ChemistryElMassDole_spectrid",
                table: "ChemistryElMassDole",
                column: "spectrid");

            migrationBuilder.CreateIndex(
                name: "IX_datings_dchanalyzeid",
                table: "datings",
                column: "dchanalyzeid");

            migrationBuilder.CreateIndex(
                name: "IX_datings_rcanalyzeid",
                table: "datings",
                column: "rcanalyzeid");

            migrationBuilder.CreateIndex(
                name: "IX_Element_placeid",
                table: "Element",
                column: "placeid");

            migrationBuilder.CreateIndex(
                name: "IX_Element_typeid",
                table: "Element",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_HasBactery_bacteryaid",
                table: "HasBactery",
                column: "bacteryaid");

            migrationBuilder.CreateIndex(
                name: "IX_HasBactery_mbanalyzeid",
                table: "HasBactery",
                column: "mbanalyzeid");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Pointid",
                table: "Photo",
                column: "Pointid");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_Sectorid",
                table: "Photo",
                column: "Sectorid");

            migrationBuilder.CreateIndex(
                name: "IX_Place_culcherobjectid",
                table: "Place",
                column: "culcherobjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_buildingid",
                table: "Point",
                column: "buildingid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_coordinatesid",
                table: "Point",
                column: "coordinatesid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_directionid",
                table: "Point",
                column: "directionid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_elementid",
                table: "Point",
                column: "elementid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_personid",
                table: "Point",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_esanalyzeid",
                table: "Sector",
                column: "esanalyzeid");

            migrationBuilder.CreateIndex(
                name: "IX_Spectr_colorid",
                table: "Spectr",
                column: "colorid");

            migrationBuilder.CreateIndex(
                name: "IX_Spectr_photoid",
                table: "Spectr",
                column: "photoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isrightinfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChemistryElMassDole");

            migrationBuilder.DropTable(
                name: "datings");

            migrationBuilder.DropTable(
                name: "HasBactery");

            migrationBuilder.DropTable(
                name: "ChemistryElement");

            migrationBuilder.DropTable(
                name: "Spectr");

            migrationBuilder.DropTable(
                name: "Bacterya");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "analyzes");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "ChronoCodes");

            migrationBuilder.DropTable(
                name: "Tree");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Vector3");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "ElementType");

            migrationBuilder.DropTable(
                name: "CulcherObject");
        }
    }
}
