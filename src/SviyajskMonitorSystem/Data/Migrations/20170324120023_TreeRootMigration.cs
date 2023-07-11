using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class TreeRootMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identifier",
                table: "treeelements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "roots",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    elementid = table.Column<int>(nullable: true),
                    rootid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roots", x => x.id);
                    table.ForeignKey(
                        name: "FK_roots_element_elementid",
                        column: x => x.elementid,
                        principalTable: "element",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_roots_treeelements_rootid",
                        column: x => x.rootid,
                        principalTable: "treeelements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roots_elementid",
                table: "roots",
                column: "elementid");

            migrationBuilder.CreateIndex(
                name: "IX_roots_rootid",
                table: "roots",
                column: "rootid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roots");

            migrationBuilder.DropColumn(
                name: "identifier",
                table: "treeelements");
        }
    }
}
