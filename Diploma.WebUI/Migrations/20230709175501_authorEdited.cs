using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.WebUI.Migrations
{
    public partial class authorEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicDegreeId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcademicDegreeİd",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AcademicDegreeId",
                table: "Authors",
                column: "AcademicDegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AcademicDegrees_AcademicDegreeId",
                table: "Authors",
                column: "AcademicDegreeId",
                principalTable: "AcademicDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AcademicDegrees_AcademicDegreeId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_AcademicDegreeId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AcademicDegreeId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AcademicDegreeİd",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Authors");
        }
    }
}
