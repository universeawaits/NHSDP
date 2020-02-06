using Microsoft.EntityFrameworkCore.Migrations;

namespace NHSDP_Request_handling.WEB.Migrations
{
    public partial class builder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudyingPlaces_InternshipId",
                table: "StudyingPlaces",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyingPlaces_OfficeId",
                table: "StudyingPlaces",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CourseId",
                table: "Programs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_InternshipId",
                table: "Programs",
                column: "InternshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Courses_CourseId",
                table: "Programs",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Internships_InternshipId",
                table: "Programs",
                column: "InternshipId",
                principalTable: "Internships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyingPlaces_Internships_InternshipId",
                table: "StudyingPlaces",
                column: "InternshipId",
                principalTable: "Internships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyingPlaces_Offices_OfficeId",
                table: "StudyingPlaces",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Courses_CourseId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Internships_InternshipId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyingPlaces_Internships_InternshipId",
                table: "StudyingPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyingPlaces_Offices_OfficeId",
                table: "StudyingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_StudyingPlaces_InternshipId",
                table: "StudyingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_StudyingPlaces_OfficeId",
                table: "StudyingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Programs_CourseId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_InternshipId",
                table: "Programs");
        }
    }
}
