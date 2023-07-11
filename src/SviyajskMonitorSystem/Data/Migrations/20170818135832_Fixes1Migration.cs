using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SviyajskMonitorSystem.Data.Migrations
{
    public partial class Fixes1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Point_pointId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Organizations_OrganizationId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Person_PersonId",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_OrganizationId",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_PersonId",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "path",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "pointId",
                table: "Photos",
                newName: "PointId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Photos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_pointId",
                table: "Photos",
                newName: "IX_Photos_PointId");

            migrationBuilder.AddColumn<int>(
                name: "StoragePlaceId",
                table: "Point",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_StoragePlaceId",
                table: "Point",
                column: "StoragePlaceId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Point_PointId",
                table: "Photos",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Storage_StoragePlaceId",
                table: "Point",
                column: "StoragePlaceId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Point_PointId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Storage_StoragePlaceId",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "IX_Point_StoragePlaceId",
                table: "Point");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "StoragePlaceId",
                table: "Point");

            migrationBuilder.RenameColumn(
                name: "PointId",
                table: "Photos",
                newName: "pointId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Photos",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_PointId",
                table: "Photos",
                newName: "IX_Photos_pointId");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Point",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_OrganizationId",
                table: "Point",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Point_PersonId",
                table: "Point",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Point_pointId",
                table: "Photos",
                column: "pointId",
                principalTable: "Point",
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
        }
    }
}
