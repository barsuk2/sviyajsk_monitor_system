using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class ElementsAttributeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatObjects",
                table: "AbstractAttributeValue",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatObjects",
                table: "AbstractAttributeValue");
        }
    }
}
