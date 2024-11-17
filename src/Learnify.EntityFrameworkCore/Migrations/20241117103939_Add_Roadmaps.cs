using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learnify.Migrations
{
    /// <inheritdoc />
    public partial class Add_Roadmaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "AppStudentProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppAssignmentResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    score = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentProgressId = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAssignmentResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAssignmentResponses_AppStudentProgresses_StudentProgressId",
                        column: x => x.StudentProgressId,
                        principalTable: "AppStudentProgresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseStepId = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAssignments_AppCourseSteps_CourseStepId",
                        column: x => x.CourseStepId,
                        principalTable: "AppCourseSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRoadmaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoadmaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoadmapCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RoadmapId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoadmapCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoadmapCourses_AppCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "AppCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoadmapCourses_AppRoadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "AppRoadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppStudentRoadmaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoadmapId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudentRoadmaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudentRoadmaps_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppStudentRoadmaps_AppRoadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "AppRoadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAssignmentResponses_StudentProgressId",
                table: "AppAssignmentResponses",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssignments_CourseStepId",
                table: "AppAssignments",
                column: "CourseStepId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoadmapCourses_CourseId",
                table: "AppRoadmapCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoadmapCourses_RoadmapId",
                table: "AppRoadmapCourses",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentRoadmaps_RoadmapId",
                table: "AppStudentRoadmaps",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentRoadmaps_UserId",
                table: "AppStudentRoadmaps",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAssignmentResponses");

            migrationBuilder.DropTable(
                name: "AppAssignments");

            migrationBuilder.DropTable(
                name: "AppRoadmapCourses");

            migrationBuilder.DropTable(
                name: "AppStudentRoadmaps");

            migrationBuilder.DropTable(
                name: "AppRoadmaps");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "AppStudentProgresses");
        }
    }
}
