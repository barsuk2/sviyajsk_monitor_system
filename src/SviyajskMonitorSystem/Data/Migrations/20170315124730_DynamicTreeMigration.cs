using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class DynamicTreeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_CulcherObject_culcherObjectid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Person_personid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_storageplaces_storageid",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_storageplaces",
                table: "storageplaces");

            migrationBuilder.DropIndex(
                name: "IX_Point_culcherObjectid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "storageplaces");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "storageplaces");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "storageplaces");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "storageplaces");

            migrationBuilder.DropColumn(
                name: "culcherObjectid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "dateofget",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "shifr",
                table: "Point");

            migrationBuilder.RenameTable(
                name: "storageplaces",
                newName: "storage");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "storage",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "Point",
                newName: "Personid");

            migrationBuilder.RenameColumn(
                name: "storageid",
                table: "Point",
                newName: "Organizationid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_personid",
                table: "Point",
                newName: "IX_Point_Personid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_storageid",
                table: "Point",
                newName: "IX_Point_Organizationid");

            migrationBuilder.AddColumn<int>(
                name: "organizationid",
                table: "storage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecoreElementid",
                table: "photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Specimenid",
                table: "analyzes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_storage",
                table: "storage",
                column: "id");

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "treetypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treetypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specimen",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pointid = table.Column<int>(nullable: true),
                    dateofget = table.Column<DateTime>(nullable: false),
                    organizationid = table.Column<int>(nullable: true),
                    personid = table.Column<int>(nullable: true),
                    physical = table.Column<bool>(nullable: false),
                    shifr = table.Column<string>(nullable: false),
                    storageid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specimen", x => x.id);
                    table.ForeignKey(
                        name: "FK_specimen_Point_Pointid",
                        column: x => x.Pointid,
                        principalTable: "Point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_specimen_organizations_organizationid",
                        column: x => x.organizationid,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_specimen_Person_personid",
                        column: x => x.personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_specimen_storage_storageid",
                        column: x => x.storageid,
                        principalTable: "storage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attributekeys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TreeTypeid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attributekeys", x => x.id);
                    table.ForeignKey(
                        name: "FK_attributekeys_treetypes_TreeTypeid",
                        column: x => x.TreeTypeid,
                        principalTable: "treetypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "treeelements",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    materialobjectid = table.Column<int>(nullable: true),
                    parentid = table.Column<long>(nullable: true),
                    typeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treeelements", x => x.id);
                    table.ForeignKey(
                        name: "FK_treeelements_element_materialobjectid",
                        column: x => x.materialobjectid,
                        principalTable: "element",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_treeelements_treeelements_parentid",
                        column: x => x.parentid,
                        principalTable: "treeelements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_treeelements_treetypes_typeid",
                        column: x => x.typeid,
                        principalTable: "treetypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbstractAttributeValue",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    TreeElementid = table.Column<long>(nullable: true),
                    attributekeyid = table.Column<int>(nullable: true),
                    itemid = table.Column<int>(nullable: true),
                    listname = table.Column<string>(nullable: true),
                    floatvalue = table.Column<float>(nullable: true),
                    intvalue = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractAttributeValue", x => x.id);
                    table.ForeignKey(
                        name: "FK_AbstractAttributeValue_treeelements_TreeElementid",
                        column: x => x.TreeElementid,
                        principalTable: "treeelements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbstractAttributeValue_attributekeys_attributekeyid",
                        column: x => x.attributekeyid,
                        principalTable: "attributekeys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_storage_organizationid",
                table: "storage",
                column: "organizationid");

            migrationBuilder.CreateIndex(
                name: "IX_photos_DecoreElementid",
                table: "photos",
                column: "DecoreElementid");

            migrationBuilder.CreateIndex(
                name: "IX_analyzes_Specimenid",
                table: "analyzes",
                column: "Specimenid");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractAttributeValue_TreeElementid",
                table: "AbstractAttributeValue",
                column: "TreeElementid");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractAttributeValue_attributekeyid",
                table: "AbstractAttributeValue",
                column: "attributekeyid");

            migrationBuilder.CreateIndex(
                name: "IX_attributekeys_TreeTypeid",
                table: "attributekeys",
                column: "TreeTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_treeelements_materialobjectid",
                table: "treeelements",
                column: "materialobjectid");

            migrationBuilder.CreateIndex(
                name: "IX_treeelements_parentid",
                table: "treeelements",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_treeelements_typeid",
                table: "treeelements",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_specimen_Pointid",
                table: "specimen",
                column: "Pointid");

            migrationBuilder.CreateIndex(
                name: "IX_specimen_organizationid",
                table: "specimen",
                column: "organizationid");

            migrationBuilder.CreateIndex(
                name: "IX_specimen_personid",
                table: "specimen",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_specimen_storageid",
                table: "specimen",
                column: "storageid");

            migrationBuilder.AddForeignKey(
                name: "FK_analyzes_specimen_Specimenid",
                table: "analyzes",
                column: "Specimenid",
                principalTable: "specimen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_photos_DecoreElement_DecoreElementid",
                table: "photos",
                column: "DecoreElementid",
                principalTable: "DecoreElement",
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
                name: "FK_Point_Person_Personid",
                table: "Point",
                column: "Personid",
                principalTable: "Person",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_analyzes_specimen_Specimenid",
                table: "analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_photos_DecoreElement_DecoreElementid",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_organizations_Organizationid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Person_Personid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_storage_organizations_organizationid",
                table: "storage");

            migrationBuilder.DropTable(
                name: "AbstractAttributeValue");

            migrationBuilder.DropTable(
                name: "specimen");

            migrationBuilder.DropTable(
                name: "treeelements");

            migrationBuilder.DropTable(
                name: "attributekeys");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "treetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_storage",
                table: "storage");

            migrationBuilder.DropIndex(
                name: "IX_storage_organizationid",
                table: "storage");

            migrationBuilder.DropIndex(
                name: "IX_photos_DecoreElementid",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_analyzes_Specimenid",
                table: "analyzes");

            migrationBuilder.DropColumn(
                name: "organizationid",
                table: "storage");

            migrationBuilder.DropColumn(
                name: "DecoreElementid",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "Specimenid",
                table: "analyzes");

            migrationBuilder.RenameTable(
                name: "storage",
                newName: "storageplaces");

            migrationBuilder.RenameColumn(
                name: "place",
                table: "storageplaces",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Personid",
                table: "Point",
                newName: "personid");

            migrationBuilder.RenameColumn(
                name: "Organizationid",
                table: "Point",
                newName: "storageid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_Personid",
                table: "Point",
                newName: "IX_Point_personid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_Organizationid",
                table: "Point",
                newName: "IX_Point_storageid");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "storageplaces",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "storageplaces",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "storageplaces",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "storageplaces",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "culcherObjectid",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateofget",
                table: "Point",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "shifr",
                table: "Point",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_storageplaces",
                table: "storageplaces",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Point_culcherObjectid",
                table: "Point",
                column: "culcherObjectid");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_CulcherObject_culcherObjectid",
                table: "Point",
                column: "culcherObjectid",
                principalTable: "CulcherObject",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Person_personid",
                table: "Point",
                column: "personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_storageplaces_storageid",
                table: "Point",
                column: "storageid",
                principalTable: "storageplaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
