using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_Place_placeid",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_ElementType_typeid",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Element_elementid",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Element",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_placeid",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_typeid",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "placeid",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "typeid",
                table: "Element");

            migrationBuilder.DropTable(
                name: "ElementType");

            migrationBuilder.DropTable(
                name: "Place");

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
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecoreElement", x => x.id);
                });

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tree",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Tree",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Spectr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Spectr",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Spectr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Spectr",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Sector",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Sector",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Sector",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Sector",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "culcherObjectid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "decoreregionid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Photo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Photo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Photo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Photo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HasBactery",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "HasBactery",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "HasBactery",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "HasBactery",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Element",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Element",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Element",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Element",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "culcherobjectid",
                table: "Element",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parentid",
                table: "Element",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "datings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "datings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "datings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "datings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CulcherObject",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "CulcherObject",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "CulcherObject",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "CulcherObject",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Color",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Color",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ChronoCodes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ChronoCodes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "ChronoCodes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ChronoCodes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ChemistryElMassDole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ChemistryElMassDole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "ChemistryElMassDole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ChemistryElMassDole",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "value",
                table: "ChemistryElMassDole",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ChemistryElement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ChemistryElement",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "ChemistryElement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ChemistryElement",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bacterya",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Bacterya",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Bacterya",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Bacterya",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "analyzes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "analyzes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "analyzes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "analyzes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_culcherObjectid",
                table: "Point",
                column: "culcherObjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Point_decoreregionid",
                table: "Point",
                column: "decoreregionid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_element",
                table: "Element",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_element_culcherobjectid",
                table: "Element",
                column: "culcherobjectid");

            migrationBuilder.CreateIndex(
                name: "IX_element_parentid",
                table: "Element",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_DecoreElementRegion_decoreelementid",
                table: "DecoreElementRegion",
                column: "decoreelementid");

            migrationBuilder.AddForeignKey(
                name: "FK_element_CulcherObject_culcherobjectid",
                table: "Element",
                column: "culcherobjectid",
                principalTable: "CulcherObject",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_element_element_parentid",
                table: "Element",
                column: "parentid",
                principalTable: "Element",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_CulcherObject_culcherObjectid",
                table: "Point",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Point_element_elementid",
                table: "Point",
                column: "elementid",
                principalTable: "Element",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "Element",
                newName: "element");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_element_CulcherObject_culcherobjectid",
                table: "element");

            migrationBuilder.DropForeignKey(
                name: "FK_element_element_parentid",
                table: "element");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_CulcherObject_culcherObjectid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_DecoreElementRegion_decoreregionid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_element_elementid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_culcherObjectid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_decoreregionid",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_element",
                table: "element");

            migrationBuilder.DropIndex(
                name: "IX_element_culcherobjectid",
                table: "element");

            migrationBuilder.DropIndex(
                name: "IX_element_parentid",
                table: "element");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Spectr");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Spectr");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Spectr");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Spectr");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "culcherObjectid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "decoreregionid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HasBactery");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "HasBactery");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "HasBactery");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "HasBactery");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "element");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "element");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "element");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "element");

            migrationBuilder.DropColumn(
                name: "culcherobjectid",
                table: "element");

            migrationBuilder.DropColumn(
                name: "parentid",
                table: "element");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "datings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "datings");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "datings");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "datings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CulcherObject");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CulcherObject");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "CulcherObject");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "CulcherObject");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ChronoCodes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ChronoCodes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "ChronoCodes");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ChronoCodes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "value",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ChemistryElement");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ChemistryElement");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "ChemistryElement");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ChemistryElement");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bacterya");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Bacterya");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Bacterya");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Bacterya");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "analyzes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "analyzes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "analyzes");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "analyzes");

            migrationBuilder.DropTable(
                name: "DecoreElementRegion");

            migrationBuilder.DropTable(
                name: "DecoreElement");

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

            migrationBuilder.AddColumn<int>(
                name: "placeid",
                table: "element",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "typeid",
                table: "element",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Element",
                table: "element",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_placeid",
                table: "element",
                column: "placeid");

            migrationBuilder.CreateIndex(
                name: "IX_Element_typeid",
                table: "element",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Place_culcherobjectid",
                table: "Place",
                column: "culcherobjectid");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Place_placeid",
                table: "element",
                column: "placeid",
                principalTable: "Place",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_ElementType_typeid",
                table: "element",
                column: "typeid",
                principalTable: "ElementType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Element_elementid",
                table: "Point",
                column: "elementid",
                principalTable: "element",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "element",
                newName: "Element");
        }
    }
}
