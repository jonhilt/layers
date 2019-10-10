using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeoFindR.Migrations
{
    public partial class agents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "Inhabitants",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "Cache",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActiveStatus = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    EntityStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cache", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActiveStatus = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    EntityStatus = table.Column<int>(nullable: false),
                    LastRebooted = table.Column<DateTime>(nullable: false),
                    CacheId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastCrashed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Cache_CacheId",
                        column: x => x.CacheId,
                        principalTable: "Cache",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CacheId",
                table: "Agents",
                column: "CacheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Cache");

            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "Inhabitants");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Inhabitants");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Inhabitants");

            migrationBuilder.DropColumn(
                name: "EntityStatus",
                table: "Inhabitants");
        }
    }
}
