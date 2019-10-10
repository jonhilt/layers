using Microsoft.EntityFrameworkCore.Migrations;

namespace NeoFindR.Migrations
{
    public partial class simplifyingentityagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "Inhabitants");

            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "Cache");

            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "Agents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "Inhabitants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "Cache",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "Agents",
                nullable: false,
                defaultValue: 0);
        }
    }
}
