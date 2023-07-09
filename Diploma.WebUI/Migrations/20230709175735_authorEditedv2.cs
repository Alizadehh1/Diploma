using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.WebUI.Migrations
{
    public partial class authorEditedv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AcademicDegrees_AcademicDegreeId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AcademicDegreeİd",
                table: "Authors");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicDegreeId",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AcademicDegrees_AcademicDegreeId",
                table: "Authors",
                column: "AcademicDegreeId",
                principalTable: "AcademicDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AcademicDegrees_AcademicDegreeId",
                table: "Authors");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicDegreeId",
                table: "Authors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AcademicDegreeİd",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AcademicDegrees_AcademicDegreeId",
                table: "Authors",
                column: "AcademicDegreeId",
                principalTable: "AcademicDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
