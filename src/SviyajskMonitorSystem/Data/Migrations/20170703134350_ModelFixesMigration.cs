using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class ModelFixesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_ChemistryElMassDole_ChemistryElement_chelementid",
                table: "ChemistryElMassDole");

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
                name: "FK_HasBactery_Bacterya_bacteryaid",
                table: "HasBactery");

            migrationBuilder.DropForeignKey(
                name: "FK_HasBactery_Analyzes_mbanalyzeid",
                table: "HasBactery");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Sector_Sectorid",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Analyzes_esanalyzeid",
                table: "Sector");

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

            migrationBuilder.DropIndex(
                name: "IX_Specimen_organizationid",
                table: "Specimen");

            migrationBuilder.DropIndex(
                name: "IX_Datings_dchanalyzeid",
                table: "Datings");

            migrationBuilder.DropColumn(
                name: "organizationid",
                table: "Specimen");

            migrationBuilder.DropColumn(
                name: "celluloznaya",
                table: "HasBactery");

            migrationBuilder.DropColumn(
                name: "lingnirazr",
                table: "HasBactery");

            migrationBuilder.DropColumn(
                name: "proteznaya",
                table: "HasBactery");

            migrationBuilder.DropColumn(
                name: "dchanalyzeid",
                table: "Datings");

            migrationBuilder.RenameColumn(
                name: "place",
                table: "Storage",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "organizationid",
                table: "Storage",
                newName: "Organizationid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Storage",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_organizationid",
                table: "Storage",
                newName: "IX_Storage_Organizationid");

            migrationBuilder.RenameColumn(
                name: "storageid",
                table: "Specimen",
                newName: "StorageId");

            migrationBuilder.RenameColumn(
                name: "shifr",
                table: "Specimen",
                newName: "Shifr");

            migrationBuilder.RenameColumn(
                name: "physical",
                table: "Specimen",
                newName: "Physical");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "Specimen",
                newName: "Personid");

            migrationBuilder.RenameColumn(
                name: "dateofget",
                table: "Specimen",
                newName: "Dateofget");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Specimen",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_storageid",
                table: "Specimen",
                newName: "IX_Specimen_StorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_personid",
                table: "Specimen",
                newName: "IX_Specimen_Personid");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Sector",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sector",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "esanalyzeid",
                table: "Sector",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Sector_esanalyzeid",
                table: "Sector",
                newName: "IX_Sector_RegionId");

            migrationBuilder.RenameColumn(
                name: "Sectorid",
                table: "Photos",
                newName: "SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_Sectorid",
                table: "Photos",
                newName: "IX_Photos_SectorId");

            migrationBuilder.RenameColumn(
                name: "mbanalyzeid",
                table: "HasBactery",
                newName: "MbanalyzeId");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "HasBactery",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "bacteryaid",
                table: "HasBactery",
                newName: "Bacteryaid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "HasBactery",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_HasBactery_mbanalyzeid",
                table: "HasBactery",
                newName: "IX_HasBactery_MbanalyzeId");

            migrationBuilder.RenameIndex(
                name: "IX_HasBactery_bacteryaid",
                table: "HasBactery",
                newName: "IX_HasBactery_Bacteryaid");

            migrationBuilder.RenameColumn(
                name: "rcanalyzeid",
                table: "Datings",
                newName: "RcanalyzeId");

            migrationBuilder.RenameColumn(
                name: "probability",
                table: "Datings",
                newName: "Probability");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Datings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Datings",
                newName: "DateTo");

            migrationBuilder.RenameIndex(
                name: "IX_Datings_rcanalyzeid",
                table: "Datings",
                newName: "IX_Datings_RcanalyzeId");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "ChemistryElMassDole",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "chelementid",
                table: "ChemistryElMassDole",
                newName: "Chelementid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ChemistryElMassDole",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "rfanalyzeid",
                table: "ChemistryElMassDole",
                newName: "SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_ChemistryElMassDole_chelementid",
                table: "ChemistryElMassDole",
                newName: "IX_ChemistryElMassDole_Chelementid");

            migrationBuilder.RenameIndex(
                name: "IX_ChemistryElMassDole_rfanalyzeid",
                table: "ChemistryElMassDole",
                newName: "IX_ChemistryElMassDole_SectorId");

            migrationBuilder.RenameColumn(
                name: "colorid",
                table: "Analyzes",
                newName: "Colorid");

            migrationBuilder.RenameColumn(
                name: "rcdate",
                table: "Analyzes",
                newName: "Rcdate");

            migrationBuilder.RenameColumn(
                name: "labdatingnumber",
                table: "Analyzes",
                newName: "Labdatingnumber");

            migrationBuilder.RenameColumn(
                name: "error",
                table: "Analyzes",
                newName: "Error");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "Analyzes",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "treeid",
                table: "Analyzes",
                newName: "Treeid");

            migrationBuilder.RenameColumn(
                name: "roundscount",
                table: "Analyzes",
                newName: "Roundscount");

            migrationBuilder.RenameColumn(
                name: "codeid",
                table: "Analyzes",
                newName: "Codeid");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Analyzes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "Analyzes",
                newName: "Personid");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Analyzes",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Analyzes",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Analyzes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "pointId",
                table: "Analyzes",
                newName: "TreeTypeid");

            migrationBuilder.RenameColumn(
                name: "Specimenid",
                table: "Analyzes",
                newName: "SampleId");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_colorid",
                table: "Analyzes",
                newName: "IX_Analyzes_Colorid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_treeid",
                table: "Analyzes",
                newName: "IX_Analyzes_Treeid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_codeid",
                table: "Analyzes",
                newName: "IX_Analyzes_Codeid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_personid",
                table: "Analyzes",
                newName: "IX_Analyzes_Personid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_pointId",
                table: "Analyzes",
                newName: "IX_Analyzes_TreeTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_Specimenid",
                table: "Analyzes",
                newName: "IX_Analyzes_SampleId");

            migrationBuilder.AddColumn<int>(
                name: "Colorid",
                table: "Sector",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateFrom",
                table: "Datings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentgenFluoriscAnalyzeId",
                table: "ChemistryElMassDole",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Error",
                table: "Analyzes",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateFrom",
                table: "Analyzes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateTo",
                table: "Analyzes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Celluloznaya",
                table: "Analyzes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lingnirazr",
                table: "Analyzes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Proteznaya",
                table: "Analyzes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElectroMicroScanAnalyzeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Analyzes_ElectroMicroScanAnalyzeId",
                        column: x => x.ElectroMicroScanAnalyzeId,
                        principalTable: "Analyzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Colorid",
                table: "Sector",
                column: "Colorid");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_RegionId",
                table: "Photos",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemistryElMassDole_RentgenFluoriscAnalyzeId",
                table: "ChemistryElMassDole",
                column: "RentgenFluoriscAnalyzeId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ElectroMicroScanAnalyzeId",
                table: "Regions",
                column: "ElectroMicroScanAnalyzeId");

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
                name: "FK_Analyzes_ChronoCodes_Codeid",
                table: "Analyzes",
                column: "Codeid",
                principalTable: "ChronoCodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Tree_Treeid",
                table: "Analyzes",
                column: "Treeid",
                principalTable: "Tree",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Tree_TreeTypeid",
                table: "Analyzes",
                column: "TreeTypeid",
                principalTable: "Tree",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyzes_Color_Colorid",
                table: "Analyzes",
                column: "Colorid",
                principalTable: "Color",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemistryElMassDole_ChemistryElement_Chelementid",
                table: "ChemistryElMassDole",
                column: "Chelementid",
                principalTable: "ChemistryElement",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemistryElMassDole_Analyzes_RentgenFluoriscAnalyzeId",
                table: "ChemistryElMassDole",
                column: "RentgenFluoriscAnalyzeId",
                principalTable: "Analyzes",
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
                name: "FK_Datings_Analyzes_RcanalyzeId",
                table: "Datings",
                column: "RcanalyzeId",
                principalTable: "Analyzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HasBactery_Bacterya_Bacteryaid",
                table: "HasBactery",
                column: "Bacteryaid",
                principalTable: "Bacterya",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HasBactery_Analyzes_MbanalyzeId",
                table: "HasBactery",
                column: "MbanalyzeId",
                principalTable: "Analyzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Regions_RegionId",
                table: "Photos",
                column: "RegionId",
                principalTable: "Regions",
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
                name: "FK_Specimen_Person_Personid",
                table: "Specimen",
                column: "Personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specimen_Storage_StorageId",
                table: "Specimen",
                column: "StorageId",
                principalTable: "Storage",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Person_Personid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Specimen_SampleId",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_ChronoCodes_Codeid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Tree_Treeid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Tree_TreeTypeid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyzes_Color_Colorid",
                table: "Analyzes");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_ChemistryElement_Chelementid",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_Analyzes_RentgenFluoriscAnalyzeId",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemistryElMassDole_Sector_SectorId",
                table: "ChemistryElMassDole");

            migrationBuilder.DropForeignKey(
                name: "FK_Datings_Analyzes_RcanalyzeId",
                table: "Datings");

            migrationBuilder.DropForeignKey(
                name: "FK_HasBactery_Bacterya_Bacteryaid",
                table: "HasBactery");

            migrationBuilder.DropForeignKey(
                name: "FK_HasBactery_Analyzes_MbanalyzeId",
                table: "HasBactery");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Regions_RegionId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Sector_SectorId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Color_Colorid",
                table: "Sector");

            migrationBuilder.DropForeignKey(
                name: "FK_Sector_Regions_RegionId",
                table: "Sector");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Person_Personid",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Specimen_Storage_StorageId",
                table: "Specimen");

            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Organizations_Organizationid",
                table: "Storage");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Sector_Colorid",
                table: "Sector");

            migrationBuilder.DropIndex(
                name: "IX_Photos_RegionId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_ChemistryElMassDole_RentgenFluoriscAnalyzeId",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "Colorid",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Datings");

            migrationBuilder.DropColumn(
                name: "RentgenFluoriscAnalyzeId",
                table: "ChemistryElMassDole");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Analyzes");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Analyzes");

            migrationBuilder.DropColumn(
                name: "Celluloznaya",
                table: "Analyzes");

            migrationBuilder.DropColumn(
                name: "Lingnirazr",
                table: "Analyzes");

            migrationBuilder.DropColumn(
                name: "Proteznaya",
                table: "Analyzes");

            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Storage",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "Organizationid",
                table: "Storage",
                newName: "organizationid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Storage",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Storage_Organizationid",
                table: "Storage",
                newName: "IX_Storage_organizationid");

            migrationBuilder.RenameColumn(
                name: "StorageId",
                table: "Specimen",
                newName: "storageid");

            migrationBuilder.RenameColumn(
                name: "Shifr",
                table: "Specimen",
                newName: "shifr");

            migrationBuilder.RenameColumn(
                name: "Physical",
                table: "Specimen",
                newName: "physical");

            migrationBuilder.RenameColumn(
                name: "Personid",
                table: "Specimen",
                newName: "personid");

            migrationBuilder.RenameColumn(
                name: "Dateofget",
                table: "Specimen",
                newName: "dateofget");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specimen",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_StorageId",
                table: "Specimen",
                newName: "IX_Specimen_storageid");

            migrationBuilder.RenameIndex(
                name: "IX_Specimen_Personid",
                table: "Specimen",
                newName: "IX_Specimen_personid");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Sector",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sector",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Sector",
                newName: "esanalyzeid");

            migrationBuilder.RenameIndex(
                name: "IX_Sector_RegionId",
                table: "Sector",
                newName: "IX_Sector_esanalyzeid");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "Photos",
                newName: "Sectorid");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_SectorId",
                table: "Photos",
                newName: "IX_Photos_Sectorid");

            migrationBuilder.RenameColumn(
                name: "MbanalyzeId",
                table: "HasBactery",
                newName: "mbanalyzeid");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "HasBactery",
                newName: "count");

            migrationBuilder.RenameColumn(
                name: "Bacteryaid",
                table: "HasBactery",
                newName: "bacteryaid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HasBactery",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_HasBactery_MbanalyzeId",
                table: "HasBactery",
                newName: "IX_HasBactery_mbanalyzeid");

            migrationBuilder.RenameIndex(
                name: "IX_HasBactery_Bacteryaid",
                table: "HasBactery",
                newName: "IX_HasBactery_bacteryaid");

            migrationBuilder.RenameColumn(
                name: "RcanalyzeId",
                table: "Datings",
                newName: "rcanalyzeid");

            migrationBuilder.RenameColumn(
                name: "Probability",
                table: "Datings",
                newName: "probability");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Datings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Datings",
                newName: "year");

            migrationBuilder.RenameIndex(
                name: "IX_Datings_RcanalyzeId",
                table: "Datings",
                newName: "IX_Datings_rcanalyzeid");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ChemistryElMassDole",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Chelementid",
                table: "ChemistryElMassDole",
                newName: "chelementid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChemistryElMassDole",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "ChemistryElMassDole",
                newName: "rfanalyzeid");

            migrationBuilder.RenameIndex(
                name: "IX_ChemistryElMassDole_Chelementid",
                table: "ChemistryElMassDole",
                newName: "IX_ChemistryElMassDole_chelementid");

            migrationBuilder.RenameIndex(
                name: "IX_ChemistryElMassDole_SectorId",
                table: "ChemistryElMassDole",
                newName: "IX_ChemistryElMassDole_rfanalyzeid");

            migrationBuilder.RenameColumn(
                name: "Colorid",
                table: "Analyzes",
                newName: "colorid");

            migrationBuilder.RenameColumn(
                name: "Rcdate",
                table: "Analyzes",
                newName: "rcdate");

            migrationBuilder.RenameColumn(
                name: "Labdatingnumber",
                table: "Analyzes",
                newName: "labdatingnumber");

            migrationBuilder.RenameColumn(
                name: "Error",
                table: "Analyzes",
                newName: "error");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Analyzes",
                newName: "count");

            migrationBuilder.RenameColumn(
                name: "Treeid",
                table: "Analyzes",
                newName: "treeid");

            migrationBuilder.RenameColumn(
                name: "Roundscount",
                table: "Analyzes",
                newName: "roundscount");

            migrationBuilder.RenameColumn(
                name: "Codeid",
                table: "Analyzes",
                newName: "codeid");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Analyzes",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Personid",
                table: "Analyzes",
                newName: "personid");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Analyzes",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Analyzes",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Analyzes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TreeTypeid",
                table: "Analyzes",
                newName: "pointId");

            migrationBuilder.RenameColumn(
                name: "SampleId",
                table: "Analyzes",
                newName: "Specimenid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_Colorid",
                table: "Analyzes",
                newName: "IX_Analyzes_colorid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_Treeid",
                table: "Analyzes",
                newName: "IX_Analyzes_treeid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_Codeid",
                table: "Analyzes",
                newName: "IX_Analyzes_codeid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_Personid",
                table: "Analyzes",
                newName: "IX_Analyzes_personid");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_TreeTypeid",
                table: "Analyzes",
                newName: "IX_Analyzes_pointId");

            migrationBuilder.RenameIndex(
                name: "IX_Analyzes_SampleId",
                table: "Analyzes",
                newName: "IX_Analyzes_Specimenid");

            migrationBuilder.AddColumn<int>(
                name: "organizationid",
                table: "Specimen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "celluloznaya",
                table: "HasBactery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lingnirazr",
                table: "HasBactery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "proteznaya",
                table: "HasBactery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "dchanalyzeid",
                table: "Datings",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "error",
                table: "Analyzes",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specimen_organizationid",
                table: "Specimen",
                column: "organizationid");

            migrationBuilder.CreateIndex(
                name: "IX_Datings_dchanalyzeid",
                table: "Datings",
                column: "dchanalyzeid");

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
                name: "FK_ChemistryElMassDole_ChemistryElement_chelementid",
                table: "ChemistryElMassDole",
                column: "chelementid",
                principalTable: "ChemistryElement",
                principalColumn: "id",
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
                name: "FK_HasBactery_Bacterya_bacteryaid",
                table: "HasBactery",
                column: "bacteryaid",
                principalTable: "Bacterya",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HasBactery_Analyzes_mbanalyzeid",
                table: "HasBactery",
                column: "mbanalyzeid",
                principalTable: "Analyzes",
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
                name: "FK_Sector_Analyzes_esanalyzeid",
                table: "Sector",
                column: "esanalyzeid",
                principalTable: "Analyzes",
                principalColumn: "id",
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
    }
}
