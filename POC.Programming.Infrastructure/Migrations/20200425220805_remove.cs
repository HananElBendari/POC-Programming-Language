using Microsoft.EntityFrameworkCore.Migrations;

namespace POC.Programming.Infrastructure.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "ProgrammingLanguageDetails");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "ProgrammingLanguage");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "ProgrammingCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "ProgrammingLanguageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "ProgrammingLanguage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "ProgrammingCategory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
