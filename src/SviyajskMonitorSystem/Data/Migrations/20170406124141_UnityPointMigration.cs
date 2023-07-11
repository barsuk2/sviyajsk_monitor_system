using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class UnityPointMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractAttributeValue_treeelements_TreeElementid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractAttributeValue_attributekeys_attributekeyid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractAttributeValue_values_valueid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_analyzes_specimen_Specimenid",
                table: "analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_analyzes_Person_personid",
                table: "analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_analyzes_Point_pointid",
                table: "analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_analyzes_ChronoCodes_codeid",
                table: "analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_analyzes_Tree_treeid",
                table: "analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_analyzes_Color_colorid",
                table: "analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_attributekeys_treetypes_TreeTypeid",
                table: "attributekeys");

            migrationBuilder.DropForeignKey(
                name: "FK_attributekeys_types_entitytypeId",
                table: "attributekeys");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_analyzes_rfanalyzeid",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_datings_analyzes_dchanalyzeid",
                table: "datings");

            migrationBuilder.DropForeignKey(
                name: "FK_datings_analyzes_rcanalyzeid",
                table: "datings");

            migrationBuilder.DropForeignKey(
                name: "FK_values_types_typeId",
                table: "values");

            migrationBuilder.DropForeignKey(
                name: "FK_treeelements_Point_Pointid",
                table: "treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_treeelements_element_materialobjectid",
                table: "treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_treeelements_treeelements_parentid",
                table: "treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_treeelements_treetypes_typeid",
                table: "treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_roots_element_elementid",
                table: "roots");

            migrationBuilder.DropForeignKey(
                name: "FK_roots_treeelements_rootid",
                table: "roots");

            migrationBuilder.DropForeignKey(
                name: "FK_roots_treetypes_treetypeid",
                table: "roots");

            migrationBuilder.DropForeignKey(
                name: "FK_element_CulcherObject_culcherobjectid",
                table: "element");

            migrationBuilder.DropForeignKey(
                name: "FK_element_element_parentid",
                table: "element");

            migrationBuilder.DropForeignKey(
                name: "FK_HasBactery_analyzes_mbanalyzeid",
                table: "HasBactery");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_AbstractAttributeValue_PhotoAttributeValueid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_Sector_Sectorid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_Point_pointid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_organizations_Organizationid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Vector3_coordinatesid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Vector3_directionid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_element_elementid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_analyzes_esanalyzeid",
                table: "Sector");

            migrationBuilder.DropForeignKey(
                name: "FK_specimen_Point_Pointid",
                table: "specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_specimen_organizations_organizationid",
                table: "specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_specimen_Person_personid",
                table: "specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_specimen_storage_storageid",
                table: "specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_storage_organizations_organizationid",
                table: "storage");

            migrationBuilder.DropTable(
                name: "BETypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_treetypes",
                table: "treetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_storage",
                table: "storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specimen",
                table: "specimen");

            migrationBuilder.DropIndex(
                name: "IX_Point_coordinatesid",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_photos",
                table: "photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_organizations",
                table: "organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_element",
                table: "element");

            migrationBuilder.DropIndex(
                name: "IX_element_culcherobjectid",
                table: "element");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roots",
                table: "roots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_treeelements",
                table: "treeelements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_values",
                table: "values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_types",
                table: "types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_datings",
                table: "datings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_attributekeys",
                table: "attributekeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_analyzes",
                table: "analyzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accauntReqest",
                table: "accauntReqest");

            migrationBuilder.DropColumn(
                name: "coordinatesid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "culcherobjectid",
                table: "element");

            migrationBuilder.DropColumn(
                name: "shifr",
                table: "element");

            migrationBuilder.RenameTable(
                name: "treetypes",
                newName: "Treetypes");

            migrationBuilder.RenameTable(
                name: "storage",
                newName: "Storage");

            migrationBuilder.RenameTable(
                name: "specimen",
                newName: "Specimen");

            migrationBuilder.RenameTable(
                name: "photos",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "organizations",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "element",
                newName: "Element");

            migrationBuilder.RenameTable(
                name: "roots",
                newName: "Roots");

            migrationBuilder.RenameTable(
                name: "treeelements",
                newName: "Treeelements");

            migrationBuilder.RenameTable(
                name: "values",
                newName: "Values");

            migrationBuilder.RenameTable(
                name: "types",
                newName: "Types");

            migrationBuilder.RenameTable(
                name: "datings",
                newName: "Datings");

            migrationBuilder.RenameTable(
                name: "attributekeys",
                newName: "Attributekeys");

            migrationBuilder.RenameTable(
                name: "analyzes",
                newName: "Analyzes");

            migrationBuilder.RenameTable(
                name: "accauntReqest",
                newName: "AccauntReqest");

            migrationBuilder.RenameColumn(
                name: "z",
                table: "Vector3",
                newName: "Z");

            migrationBuilder.RenameColumn(
                name: "y",
                table: "Vector3",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "x",
                table: "Vector3",
                newName: "X");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Vector3",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_storage_organizationid",
                table: "Storage",
                newName: "IX_Storage_organizationid");

            migrationBuilder.RenameColumn(
                name: "Pointid",
                table: "Specimen",
                newName: "PointId");

            migrationBuilder.RenameIndex(
                name: "IX_specimen_storageid",
                table: "Specimen",
                newName: "IX_Specimen_storageid");

            migrationBuilder.RenameIndex(
                name: "IX_specimen_personid",
                table: "Specimen",
                newName: "IX_Specimen_personid");

            migrationBuilder.RenameIndex(
                name: "IX_specimen_organizationid",
                table: "Specimen",
                newName: "IX_Specimen_organizationid");

            migrationBuilder.RenameIndex(
                name: "IX_specimen_Pointid",
                table: "Specimen",
                newName: "IX_Specimen_PointId");

            migrationBuilder.RenameColumn(
                name: "placedescription",
                table: "Point",
                newName: "Placedescription");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Point",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Point",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "elementid",
                table: "Point",
                newName: "ElementId");

            migrationBuilder.RenameColumn(
                name: "altitude",
                table: "Point",
                newName: "Altitude");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Point",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "directionid",
                table: "Point",
                newName: "UnitypointId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_elementid",
                table: "Point",
                newName: "IX_Point_ElementId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_directionid",
                table: "Point",
                newName: "IX_Point_UnitypointId");

            migrationBuilder.RenameColumn(
                name: "pointid",
                table: "Photos",
                newName: "pointId");

            migrationBuilder.RenameIndex(
                name: "IX_photos_pointid",
                table: "Photos",
                newName: "IX_Photos_pointId");

            migrationBuilder.RenameIndex(
                name: "IX_photos_Sectorid",
                table: "Photos",
                newName: "IX_Photos_Sectorid");

            migrationBuilder.RenameIndex(
                name: "IX_photos_PhotoAttributeValueid",
                table: "Photos",
                newName: "IX_Photos_PhotoAttributeValueid");

            migrationBuilder.RenameColumn(
                name: "parentid",
                table: "Element",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Element",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Element",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_element_parentid",
                table: "Element",
                newName: "IX_Element_ParentId");

            migrationBuilder.RenameColumn(
                name: "elementid",
                table: "Roots",
                newName: "elementId");

            migrationBuilder.RenameIndex(
                name: "IX_roots_treetypeid",
                table: "Roots",
                newName: "IX_Roots_treetypeid");

            migrationBuilder.RenameIndex(
                name: "IX_roots_rootid",
                table: "Roots",
                newName: "IX_Roots_rootid");

            migrationBuilder.RenameIndex(
                name: "IX_roots_elementid",
                table: "Roots",
                newName: "IX_Roots_elementId");

            migrationBuilder.RenameColumn(
                name: "materialobjectid",
                table: "Treeelements",
                newName: "materialobjectId");

            migrationBuilder.RenameColumn(
                name: "Pointid",
                table: "Treeelements",
                newName: "PointId");

            migrationBuilder.RenameIndex(
                name: "IX_treeelements_typeid",
                table: "Treeelements",
                newName: "IX_Treeelements_typeid");

            migrationBuilder.RenameIndex(
                name: "IX_treeelements_parentid",
                table: "Treeelements",
                newName: "IX_Treeelements_parentid");

            migrationBuilder.RenameIndex(
                name: "IX_treeelements_materialobjectid",
                table: "Treeelements",
                newName: "IX_Treeelements_materialobjectId");

            migrationBuilder.RenameIndex(
                name: "IX_treeelements_Pointid",
                table: "Treeelements",
                newName: "IX_Treeelements_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_values_typeId",
                table: "Values",
                newName: "IX_Values_typeId");

            migrationBuilder.RenameIndex(
                name: "IX_datings_rcanalyzeid",
                table: "Datings",
                newName: "IX_Datings_rcanalyzeid");

            migrationBuilder.RenameIndex(
                name: "IX_datings_dchanalyzeid",
                table: "Datings",
                newName: "IX_Datings_dchanalyzeid");

            migrationBuilder.RenameIndex(
                name: "IX_attributekeys_entitytypeId",
                table: "Attributekeys",
                newName: "IX_Attributekeys_entitytypeId");

            migrationBuilder.RenameIndex(
                name: "IX_attributekeys_TreeTypeid",
                table: "Attributekeys",
                newName: "IX_Attributekeys_TreeTypeid");

            migrationBuilder.RenameColumn(
                name: "pointid",
                table: "Analyzes",
                newName: "pointId");

            migrationBuilder.RenameIndex(
                name: "IX_analyzes_colorid",
                table: "Analyzes",
                newName: "IX_Analyzes_colorid");

            migrationBuilder.RenameIndex(
                name: "IX_analyzes_treeid",
                table: "Analyzes",
                newName: "IX_Analyzes_treeid");

            migrationBuilder.RenameIndex(
                name: "IX_analyzes_codeid",
                table: "Analyzes",
                newName: "IX_Analyzes_codeid");

            migrationBuilder.RenameIndex(
                name: "IX_analyzes_pointid",
                table: "Analyzes",
                newName: "IX_Analyzes_pointId");

            migrationBuilder.RenameIndex(
                name: "IX_analyzes_personid",
                table: "Analyzes",
                newName: "IX_Analyzes_personid");

            migrationBuilder.RenameIndex(
                name: "IX_analyzes_Specimenid",
                table: "Analyzes",
                newName: "IX_Analyzes_Specimenid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treetypes",
                table: "Treetypes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storage",
                table: "Storage",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specimen",
                table: "Specimen",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Element",
                table: "Element",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roots",
                table: "Roots",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treeelements",
                table: "Treeelements",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Values",
                table: "Values",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datings",
                table: "Datings",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributekeys",
                table: "Attributekeys",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analyzes",
                table: "Analyzes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccauntReqest",
                table: "AccauntReqest",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ElementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnityPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DirectionId = table.Column<int>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnityPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnityPoints_Vector3_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Vector3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnityPoints_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnityPoints_Vector3_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Vector3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ElementId",
                table: "Models",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_UnityPoints_DirectionId",
                table: "UnityPoints",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UnityPoints_ModelId",
                table: "UnityPoints",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UnityPoints_PositionId",
                table: "UnityPoints",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractAttributeValue_Treeelements_TreeElementid",
                table: "AbstractAttributeValue",
                column: "TreeElementid",
                principalTable: "Treeelements",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractAttributeValue_Attributekeys_attributekeyid",
                table: "AbstractAttributeValue",
                column: "attributekeyid",
                principalTable: "Attributekeys",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractAttributeValue_Values_valueid",
                table: "AbstractAttributeValue",
                column: "valueid",
                principalTable: "Values",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Specimen_Specimenid",
                table: "Analyzes",
                column: "Specimenid",
                principalTable: "Specimen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Person_personid",
                table: "Analyzes",
                column: "personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Point_pointId",
                table: "Analyzes",
                column: "pointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_ChronoCodes_codeid",
                table: "Analyzes",
                column: "codeid",
                principalTable: "ChronoCodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Tree_treeid",
                table: "Analyzes",
                column: "treeid",
                principalTable: "Tree",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Color_colorid",
                table: "Analyzes",
                column: "colorid",
                principalTable: "Color",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributekeys_Treetypes_TreeTypeid",
                table: "Attributekeys",
                column: "TreeTypeid",
                principalTable: "Treetypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributekeys_Types_entitytypeId",
                table: "Attributekeys",
                column: "entitytypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemistryElMassDole_Analyzes_rfanalyzeid",
                table: "ChemistryElMassDole",
                column: "rfanalyzeid",
                principalTable: "Analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Datings_Analyzes_dchanalyzeid",
                table: "Datings",
                column: "dchanalyzeid",
                principalTable: "Analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Datings_Analyzes_rcanalyzeid",
                table: "Datings",
                column: "rcanalyzeid",
                principalTable: "Analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Values_Types_typeId",
                table: "Values",
                column: "typeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treeelements_Point_PointId",
                table: "Treeelements",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treeelements_Element_materialobjectId",
                table: "Treeelements",
                column: "materialobjectId",
                principalTable: "Element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treeelements_Treeelements_parentid",
                table: "Treeelements",
                column: "parentid",
                principalTable: "Treeelements",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treeelements_Treetypes_typeid",
                table: "Treeelements",
                column: "typeid",
                principalTable: "Treetypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roots_Element_elementId",
                table: "Roots",
                column: "elementId",
                principalTable: "Element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roots_Treeelements_rootid",
                table: "Roots",
                column: "rootid",
                principalTable: "Treeelements",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roots_Treetypes_treetypeid",
                table: "Roots",
                column: "treetypeid",
                principalTable: "Treetypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Element_ParentId",
                table: "Element",
                column: "ParentId",
                principalTable: "Element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HasBactery_Analyzes_mbanalyzeid",
                table: "HasBactery",
                column: "mbanalyzeid",
                principalTable: "Analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AbstractAttributeValue_PhotoAttributeValueid",
                table: "Photos",
                column: "PhotoAttributeValueid",
                principalTable: "AbstractAttributeValue",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Sector_Sectorid",
                table: "Photos",
                column: "Sectorid",
                principalTable: "Sector",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Point_pointId",
                table: "Photos",
                column: "pointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Element_ElementId",
                table: "Point",
                column: "ElementId",
                principalTable: "Element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Organizations_Organizationid",
                table: "Point",
                column: "Organizationid",
                principalTable: "Organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_UnityPoints_UnitypointId",
                table: "Point",
                column: "UnitypointId",
                principalTable: "UnityPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sector_Analyzes_esanalyzeid",
                table: "Sector",
                column: "esanalyzeid",
                principalTable: "Analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Point_PointId",
                table: "Specimen",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Organizations_organizationid",
                table: "Specimen",
                column: "organizationid",
                principalTable: "Organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Person_personid",
                table: "Specimen",
                column: "personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Storage_storageid",
                table: "Specimen",
                column: "storageid",
                principalTable: "Storage",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Organizations_organizationid",
                table: "Storage",
                column: "organizationid",
                principalTable: "Organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractAttributeValue_Treeelements_TreeElementid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractAttributeValue_Attributekeys_attributekeyid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractAttributeValue_Values_valueid",
                table: "AbstractAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Specimen_Specimenid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Person_personid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Point_pointId",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_ChronoCodes_codeid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Tree_treeid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Color_colorid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Attributekeys_Treetypes_TreeTypeid",
                table: "Attributekeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Attributekeys_Types_entitytypeId",
                table: "Attributekeys");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_Analyzes_rfanalyzeid",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_Datings_Analyzes_dchanalyzeid",
                table: "Datings");

            migrationBuilder.DropForeignKey(
                name: "FK_Datings_Analyzes_rcanalyzeid",
                table: "Datings");

            migrationBuilder.DropForeignKey(
                name: "FK_Values_Types_typeId",
                table: "Values");

            migrationBuilder.DropForeignKey(
                name: "FK_Treeelements_Point_PointId",
                table: "Treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_Treeelements_Element_materialobjectId",
                table: "Treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_Treeelements_Treeelements_parentid",
                table: "Treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_Treeelements_Treetypes_typeid",
                table: "Treeelements");

            migrationBuilder.DropForeignKey(
                name: "FK_Roots_Element_elementId",
                table: "Roots");

            migrationBuilder.DropForeignKey(
                name: "FK_Roots_Treeelements_rootid",
                table: "Roots");

            migrationBuilder.DropForeignKey(
                name: "FK_Roots_Treetypes_treetypeid",
                table: "Roots");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Element_ParentId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_HasBactery_Analyzes_mbanalyzeid",
                table: "HasBactery");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AbstractAttributeValue_PhotoAttributeValueid",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Sector_Sectorid",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Point_pointId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Element_ElementId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Organizations_Organizationid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_UnityPoints_UnitypointId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Analyzes_esanalyzeid",
                table: "Sector");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Point_PointId",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Organizations_organizationid",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Person_personid",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Storage_storageid",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Organizations_organizationid",
                table: "Storage");

            migrationBuilder.DropTable(
                name: "UnityPoints");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treetypes",
                table: "Treetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storage",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specimen",
                table: "Specimen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Element",
                table: "Element");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roots",
                table: "Roots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treeelements",
                table: "Treeelements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Values",
                table: "Values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Datings",
                table: "Datings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributekeys",
                table: "Attributekeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Analyzes",
                table: "Analyzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccauntReqest",
                table: "AccauntReqest");

            migrationBuilder.RenameTable(
                name: "Treetypes",
                newName: "treetypes");

            migrationBuilder.RenameTable(
                name: "Storage",
                newName: "storage");

            migrationBuilder.RenameTable(
                name: "Specimen",
                newName: "specimen");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "photos");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "organizations");

            migrationBuilder.RenameTable(
                name: "Element",
                newName: "element");

            migrationBuilder.RenameTable(
                name: "Roots",
                newName: "roots");

            migrationBuilder.RenameTable(
                name: "Treeelements",
                newName: "treeelements");

            migrationBuilder.RenameTable(
                name: "Values",
                newName: "values");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "types");

            migrationBuilder.RenameTable(
                name: "Datings",
                newName: "datings");

            migrationBuilder.RenameTable(
                name: "Attributekeys",
                newName: "attributekeys");

            migrationBuilder.RenameTable(
                name: "Analyzes",
                newName: "analyzes");

            migrationBuilder.RenameTable(
                name: "AccauntReqest",
                newName: "accauntReqest");

            migrationBuilder.RenameColumn(
                name: "Z",
                table: "Vector3",
                newName: "z");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Vector3",
                newName: "y");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "Vector3",
                newName: "x");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vector3",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_organizationid",
                table: "storage",
                newName: "IX_storage_organizationid");

            migrationBuilder.RenameColumn(
                name: "PointId",
                table: "specimen",
                newName: "Pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_storageid",
                table: "specimen",
                newName: "IX_specimen_storageid");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_personid",
                table: "specimen",
                newName: "IX_specimen_personid");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_organizationid",
                table: "specimen",
                newName: "IX_specimen_organizationid");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_PointId",
                table: "specimen",
                newName: "IX_specimen_Pointid");

            migrationBuilder.RenameColumn(
                name: "Placedescription",
                table: "Point",
                newName: "placedescription");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Point",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Point",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "ElementId",
                table: "Point",
                newName: "elementid");

            migrationBuilder.RenameColumn(
                name: "Altitude",
                table: "Point",
                newName: "altitude");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Point",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UnitypointId",
                table: "Point",
                newName: "directionid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_ElementId",
                table: "Point",
                newName: "IX_Point_elementid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_UnitypointId",
                table: "Point",
                newName: "IX_Point_directionid");

            migrationBuilder.RenameColumn(
                name: "pointId",
                table: "photos",
                newName: "pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_pointId",
                table: "photos",
                newName: "IX_photos_pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_Sectorid",
                table: "photos",
                newName: "IX_photos_Sectorid");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_PhotoAttributeValueid",
                table: "photos",
                newName: "IX_photos_PhotoAttributeValueid");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "element",
                newName: "parentid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "element",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "element",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Element_ParentId",
                table: "element",
                newName: "IX_element_parentid");

            migrationBuilder.RenameColumn(
                name: "elementId",
                table: "roots",
                newName: "elementid");

            migrationBuilder.RenameIndex(
                name: "IX_Roots_treetypeid",
                table: "roots",
                newName: "IX_roots_treetypeid");

            migrationBuilder.RenameIndex(
                name: "IX_Roots_rootid",
                table: "roots",
                newName: "IX_roots_rootid");

            migrationBuilder.RenameIndex(
                name: "IX_Roots_elementId",
                table: "roots",
                newName: "IX_roots_elementid");

            migrationBuilder.RenameColumn(
                name: "materialobjectId",
                table: "treeelements",
                newName: "materialobjectid");

            migrationBuilder.RenameColumn(
                name: "PointId",
                table: "treeelements",
                newName: "Pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Treeelements_typeid",
                table: "treeelements",
                newName: "IX_treeelements_typeid");

            migrationBuilder.RenameIndex(
                name: "IX_Treeelements_parentid",
                table: "treeelements",
                newName: "IX_treeelements_parentid");

            migrationBuilder.RenameIndex(
                name: "IX_Treeelements_materialobjectId",
                table: "treeelements",
                newName: "IX_treeelements_materialobjectid");

            migrationBuilder.RenameIndex(
                name: "IX_Treeelements_PointId",
                table: "treeelements",
                newName: "IX_treeelements_Pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Values_typeId",
                table: "values",
                newName: "IX_values_typeId");

            migrationBuilder.RenameIndex(
                name: "IX_Datings_rcanalyzeid",
                table: "datings",
                newName: "IX_datings_rcanalyzeid");

            migrationBuilder.RenameIndex(
                name: "IX_Datings_dchanalyzeid",
                table: "datings",
                newName: "IX_datings_dchanalyzeid");

            migrationBuilder.RenameIndex(
                name: "IX_Attributekeys_entitytypeId",
                table: "attributekeys",
                newName: "IX_attributekeys_entitytypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attributekeys_TreeTypeid",
                table: "attributekeys",
                newName: "IX_attributekeys_TreeTypeid");

            migrationBuilder.RenameColumn(
                name: "pointId",
                table: "analyzes",
                newName: "pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_colorid",
                table: "analyzes",
                newName: "IX_analyzes_colorid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_treeid",
                table: "analyzes",
                newName: "IX_analyzes_treeid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_codeid",
                table: "analyzes",
                newName: "IX_analyzes_codeid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_pointId",
                table: "analyzes",
                newName: "IX_analyzes_pointid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_personid",
                table: "analyzes",
                newName: "IX_analyzes_personid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_Specimenid",
                table: "analyzes",
                newName: "IX_analyzes_Specimenid");

            migrationBuilder.AddColumn<int>(
                name: "coordinatesid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "culcherobjectid",
                table: "element",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shifr",
                table: "element",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_treetypes",
                table: "treetypes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_storage",
                table: "storage",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specimen",
                table: "specimen",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_photos",
                table: "photos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_organizations",
                table: "organizations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_element",
                table: "element",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roots",
                table: "roots",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_treeelements",
                table: "treeelements",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_values",
                table: "values",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_types",
                table: "types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_datings",
                table: "datings",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_attributekeys",
                table: "attributekeys",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_analyzes",
                table: "analyzes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accauntReqest",
                table: "accauntReqest",
                column: "id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Point_coordinatesid",
                table: "Point",
                column: "coordinatesid");

            migrationBuilder.CreateIndex(
                name: "IX_element_culcherobjectid",
                table: "element",
                column: "culcherobjectid");

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractAttributeValue_treeelements_TreeElementid",
                table: "AbstractAttributeValue",
                column: "TreeElementid",
                principalTable: "treeelements",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractAttributeValue_attributekeys_attributekeyid",
                table: "AbstractAttributeValue",
                column: "attributekeyid",
                principalTable: "attributekeys",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractAttributeValue_values_valueid",
                table: "AbstractAttributeValue",
                column: "valueid",
                principalTable: "values",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_analyzes_specimen_Specimenid",
                table: "analyzes",
                column: "Specimenid",
                principalTable: "specimen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_analyzes_Person_personid",
                table: "analyzes",
                column: "personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_analyzes_Point_pointid",
                table: "analyzes",
                column: "pointid",
                principalTable: "Point",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_analyzes_ChronoCodes_codeid",
                table: "analyzes",
                column: "codeid",
                principalTable: "ChronoCodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_analyzes_Tree_treeid",
                table: "analyzes",
                column: "treeid",
                principalTable: "Tree",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_analyzes_Color_colorid",
                table: "analyzes",
                column: "colorid",
                principalTable: "Color",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_attributekeys_treetypes_TreeTypeid",
                table: "attributekeys",
                column: "TreeTypeid",
                principalTable: "treetypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_attributekeys_types_entitytypeId",
                table: "attributekeys",
                column: "entitytypeId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemistryElMassDole_analyzes_rfanalyzeid",
                table: "ChemistryElMassDole",
                column: "rfanalyzeid",
                principalTable: "analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_datings_analyzes_dchanalyzeid",
                table: "datings",
                column: "dchanalyzeid",
                principalTable: "analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_datings_analyzes_rcanalyzeid",
                table: "datings",
                column: "rcanalyzeid",
                principalTable: "analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_values_types_typeId",
                table: "values",
                column: "typeId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treeelements_Point_Pointid",
                table: "treeelements",
                column: "Pointid",
                principalTable: "Point",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treeelements_element_materialobjectid",
                table: "treeelements",
                column: "materialobjectid",
                principalTable: "element",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treeelements_treeelements_parentid",
                table: "treeelements",
                column: "parentid",
                principalTable: "treeelements",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treeelements_treetypes_typeid",
                table: "treeelements",
                column: "typeid",
                principalTable: "treetypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_roots_element_elementid",
                table: "roots",
                column: "elementid",
                principalTable: "element",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_roots_treeelements_rootid",
                table: "roots",
                column: "rootid",
                principalTable: "treeelements",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_roots_treetypes_treetypeid",
                table: "roots",
                column: "treetypeid",
                principalTable: "treetypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_element_CulcherObject_culcherobjectid",
                table: "element",
                column: "culcherobjectid",
                principalTable: "CulcherObject",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_element_element_parentid",
                table: "element",
                column: "parentid",
                principalTable: "element",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HasBactery_analyzes_mbanalyzeid",
                table: "HasBactery",
                column: "mbanalyzeid",
                principalTable: "analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_AbstractAttributeValue_PhotoAttributeValueid",
                table: "photos",
                column: "PhotoAttributeValueid",
                principalTable: "AbstractAttributeValue",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_Sector_Sectorid",
                table: "photos",
                column: "Sectorid",
                principalTable: "Sector",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_Point_pointid",
                table: "photos",
                column: "pointid",
                principalTable: "Point",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_organizations_Organizationid",
                table: "Point",
                column: "Organizationid",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Vector3_coordinatesid",
                table: "Point",
                column: "coordinatesid",
                principalTable: "Vector3",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Vector3_directionid",
                table: "Point",
                column: "directionid",
                principalTable: "Vector3",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_element_elementid",
                table: "Point",
                column: "elementid",
                principalTable: "element",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sector_analyzes_esanalyzeid",
                table: "Sector",
                column: "esanalyzeid",
                principalTable: "analyzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_specimen_Point_Pointid",
                table: "specimen",
                column: "Pointid",
                principalTable: "Point",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_specimen_organizations_organizationid",
                table: "specimen",
                column: "organizationid",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_specimen_Person_personid",
                table: "specimen",
                column: "personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_specimen_storage_storageid",
                table: "specimen",
                column: "storageid",
                principalTable: "storage",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_storage_organizations_organizationid",
                table: "storage",
                column: "organizationid",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
