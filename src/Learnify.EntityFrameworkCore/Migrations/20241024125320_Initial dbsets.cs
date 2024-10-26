using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learnify.Migrations
{
    /// <inheritdoc />
    public partial class Initialdbsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCourseSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCourseSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCourseSteps_AppCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "AppCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppEnrollments_AppCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "AppCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppEnrollments_AppStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AppStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppStudentProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseStepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudentProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudentProgresses_AppCourseSteps_CourseStepId",
                        column: x => x.CourseStepId,
                        principalTable: "AppCourseSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppStudentProgresses_AppStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AppStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCourseSteps_CourseId",
                table: "AppCourseSteps",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEnrollments_CourseId",
                table: "AppEnrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEnrollments_StudentId",
                table: "AppEnrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentProgresses_CourseStepId",
                table: "AppStudentProgresses",
                column: "CourseStepId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentProgresses_StudentId",
                table: "AppStudentProgresses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppEnrollments");

            migrationBuilder.DropTable(
                name: "AppStudentProgresses");

            migrationBuilder.DropTable(
                name: "AppCourseSteps");

            migrationBuilder.DropTable(
                name: "AppStudents");

            migrationBuilder.DropTable(
                name: "AppCourses");
        }
    }
}
