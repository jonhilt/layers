using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeoFindR.Migrations
{
    public partial class simplifyingentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Inhabitants");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Inhabitants");

            migrationBuilder.DropColumn(
                name: "EntityStatus",
                table: "Inhabitants");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cache");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Cache");

            migrationBuilder.DropColumn(
                name: "EntityStatus",
                table: "Cache");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "EntityStatus",
                table: "Agents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Inhabitants",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Inhabitants",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EntityStatus",
                table: "Inhabitants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Cache",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Cache",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EntityStatus",
                table: "Cache",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Agents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Agents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EntityStatus",
                table: "Agents",
                nullable: false,
                defaultValue: 0);
        }
    }
}
