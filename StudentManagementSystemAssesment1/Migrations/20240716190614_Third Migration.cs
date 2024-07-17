using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemAssesment1.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_StudentId",
                table: "Departments");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StudentId",
                table: "Departments",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_StudentId",
                table: "Departments");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StudentId",
                table: "Departments",
                column: "StudentId");
        }
    }
}
