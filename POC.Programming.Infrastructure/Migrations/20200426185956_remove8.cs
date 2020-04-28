using Microsoft.EntityFrameworkCore.Migrations;

namespace POC.Programming.Infrastructure.Migrations
{
    public partial class remove8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgrammingLanguageDetailsId",
                table: "ProgrammingLanguageDetails");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguageId",
                table: "ProgrammingLanguage");

            migrationBuilder.DropColumn(
                name: "ProgrammingCategoryId",
                table: "ProgrammingCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguageDetailsId",
                table: "ProgrammingLanguageDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguageId",
                table: "ProgrammingLanguage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingCategoryId",
                table: "ProgrammingCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
