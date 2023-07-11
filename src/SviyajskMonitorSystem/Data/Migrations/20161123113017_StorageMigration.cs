using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class StorageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storageplaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storageplaces", x => x.id);
                });

            migrationBuilder.AddColumn<int>(
                name: "Storageid",
                table: "Point",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_Storageid",
                table: "Point",
                column: "Storageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_storageplaces_Storageid",
                table: "Point",
                column: "Storageid",
                principalTable: "storageplaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_storageplaces_Storageid",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_Storageid",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "Storageid",
                table: "Point");

            migrationBuilder.DropTable(
                name: "storageplaces");
        }
    }
}
