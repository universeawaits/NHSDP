using Microsoft.EntityFrameworkCore.Migrations;

namespace NHSDP_SPA.WEB.Migrations
{
    public partial class Constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudyingPlaces_InternshipId",
                table: "StudyingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Programs_InternshipId",
                table: "Programs");

            migrationBuilder.CreateIndex(
                name: "IX_StudyingPlaces_InternshipId_OfficeId",
                table: "StudyingPlaces",
                columns: new[] { "InternshipId", "OfficeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_InternshipId_CourseId",
                table: "Programs",
                columns: new[] { "InternshipId", "CourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Technology_HoursCount",
                table: "Courses",
                columns: new[] { "Technology", "HoursCount" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudyingPlaces_InternshipId_OfficeId",
                table: "StudyingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Programs_InternshipId_CourseId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Technology_HoursCount",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_StudyingPlaces_InternshipId",
                table: "StudyingPlaces",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_InternshipId",
                table: "Programs",
                column: "InternshipId");
        }
    }
}
