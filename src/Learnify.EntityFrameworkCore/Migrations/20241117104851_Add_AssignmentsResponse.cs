using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learnify.Migrations
{
    /// <inheritdoc />
    public partial class Add_AssignmentsResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAssignmentResponses_AppStudentProgresses_StudentProgressId",
                table: "AppAssignmentResponses");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAssignmentResponses_AppStudentProgresses_StudentProgressId",
                table: "AppAssignmentResponses",
                column: "StudentProgressId",
                principalTable: "AppStudentProgresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAssignmentResponses_AppStudentProgresses_StudentProgressId",
                table: "AppAssignmentResponses");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAssignmentResponses_AppStudentProgresses_StudentProgressId",
                table: "AppAssignmentResponses",
                column: "StudentProgressId",
                principalTable: "AppStudentProgresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
