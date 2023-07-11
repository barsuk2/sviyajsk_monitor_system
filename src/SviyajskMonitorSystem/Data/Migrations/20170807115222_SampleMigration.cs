using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class SampleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Person_Personid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Specimen_SampleId",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_Sector_SectorId",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Sector_SectorId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Organizations_Organizationid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Person_Personid",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Color_Colorid",
                table: "Sector");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Regions_RegionId",
                table: "Sector");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Organizations_Organizationid",
                table: "Storage");

            migrationBuilder.DropTable(
                name: "Specimen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sector",
                table: "Sector");

            migrationBuilder.RenameTable(
                name: "Sector",
                newName: "Sectors");

            migrationBuilder.RenameColumn(
                name: "Organizationid",
                table: "Storage",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_Organizationid",
                table: "Storage",
                newName: "IX_Storage_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Sector_RegionId",
                table: "Sectors",
                newName: "IX_Sectors_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Sector_Colorid",
                table: "Sectors",
                newName: "IX_Sectors_Colorid");

            migrationBuilder.RenameColumn(
                name: "Personid",
                table: "Point",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Organizationid",
                table: "Point",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_Personid",
                table: "Point",
                newName: "IX_Point_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_Organizationid",
                table: "Point",
                newName: "IX_Point_OrganizationId");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Person",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Person",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Organizations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Organizations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Personid",
                table: "Analyzes",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_Personid",
                table: "Analyzes",
                newName: "IX_Analyzes_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sectors",
                table: "Sectors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dateofget = table.Column<DateTime>(nullable: false),
                    Physical = table.Column<bool>(nullable: false),
                    PpersonId = table.Column<int>(nullable: true),
                    SamplePlaceId = table.Column<int>(nullable: true),
                    Shifr = table.Column<string>(nullable: false),
                    StorageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samples_Person_PpersonId",
                        column: x => x.PpersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Samples_Point_SamplePlaceId",
                        column: x => x.SamplePlaceId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Samples_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samples_PpersonId",
                table: "Samples",
                column: "PpersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_SamplePlaceId",
                table: "Samples",
                column: "SamplePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_StorageId",
                table: "Samples",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Person_PersonId",
                table: "Analyzes",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Samples_SampleId",
                table: "Analyzes",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemistryElMassDole_Sectors_SectorId",
                table: "ChemistryElMassDole",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Sectors_SectorId",
                table: "Photos",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Organizations_OrganizationId",
                table: "Point",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Person_PersonId",
                table: "Point",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Color_Colorid",
                table: "Sectors",
                column: "Colorid",
                principalTable: "Color",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Regions_RegionId",
                table: "Sectors",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Organizations_OrganizationId",
                table: "Storage",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Person_PersonId",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Samples_SampleId",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_Sectors_SectorId",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Sectors_SectorId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Organizations_OrganizationId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Person_PersonId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Color_Colorid",
                table: "Sectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Regions_RegionId",
                table: "Sectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Organizations_OrganizationId",
                table: "Storage");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sectors",
                table: "Sectors");

            migrationBuilder.RenameTable(
                name: "Sectors",
                newName: "Sector");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Storage",
                newName: "Organizationid");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_OrganizationId",
                table: "Storage",
                newName: "IX_Storage_Organizationid");

            migrationBuilder.RenameIndex(
                name: "IX_Sectors_RegionId",
                table: "Sector",
                newName: "IX_Sector_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Sectors_Colorid",
                table: "Sector",
                newName: "IX_Sector_Colorid");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Point",
                newName: "Personid");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Point",
                newName: "Organizationid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_PersonId",
                table: "Point",
                newName: "IX_Point_Personid");

            migrationBuilder.RenameIndex(
                name: "IX_Point_OrganizationId",
                table: "Point",
                newName: "IX_Point_Organizationid");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Person",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Organizations",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Organizations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Analyzes",
                newName: "Personid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_PersonId",
                table: "Analyzes",
                newName: "IX_Analyzes_Personid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sector",
                table: "Sector",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Specimen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dateofget = table.Column<DateTime>(nullable: false),
                    Personid = table.Column<int>(nullable: true),
                    Physical = table.Column<bool>(nullable: false),
                    PointId = table.Column<int>(nullable: true),
                    Shifr = table.Column<string>(nullable: false),
                    StorageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specimen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specimen_Person_Personid",
                        column: x => x.Personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_Point_PointId",
                        column: x => x.PointId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specimen_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_Personid",
                table: "Specimen",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_PointId",
                table: "Specimen",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_StorageId",
                table: "Specimen",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Person_Personid",
                table: "Analyzes",
                column: "Personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Specimen_SampleId",
                table: "Analyzes",
                column: "SampleId",
                principalTable: "Specimen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemistryElMassDole_Sector_SectorId",
                table: "ChemistryElMassDole",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Sector_SectorId",
                table: "Photos",
                column: "SectorId",
                principalTable: "Sector",
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
                name: "FK_Point_Person_Personid",
                table: "Point",
                column: "Personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sector_Color_Colorid",
                table: "Sector",
                column: "Colorid",
                principalTable: "Color",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sector_Regions_RegionId",
                table: "Sector",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Organizations_Organizationid",
                table: "Storage",
                column: "Organizationid",
                principalTable: "Organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
