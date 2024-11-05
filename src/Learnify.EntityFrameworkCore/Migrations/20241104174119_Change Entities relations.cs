using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learnify.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntitiesrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEnrollments_AppStudents_StudentId",
                table: "AppEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppStudentProgresses_AppStudents_StudentId",
                table: "AppStudentProgresses");

            migrationBuilder.DropTable(
                name: "AppStudents");

            migrationBuilder.DropIndex(
                name: "IX_AppStudentProgresses_StudentId",
                table: "AppStudentProgresses");

            migrationBuilder.DropIndex(
                name: "IX_AppEnrollments_StudentId",
                table: "AppEnrollments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AppStudentProgresses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AppEnrollments");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "AppStudentProgresses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "AppEnrollments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentProgresses_UserId",
                table: "AppStudentProgresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEnrollments_UserId",
                table: "AppEnrollments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEnrollments_AbpUsers_UserId",
                table: "AppEnrollments",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppStudentProgresses_AbpUsers_UserId",
                table: "AppStudentProgresses",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEnrollments_AbpUsers_UserId",
                table: "AppEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppStudentProgresses_AbpUsers_UserId",
                table: "AppStudentProgresses");

            migrationBuilder.DropIndex(
                name: "IX_AppStudentProgresses_UserId",
                table: "AppStudentProgresses");

            migrationBuilder.DropIndex(
                name: "IX_AppEnrollments_UserId",
                table: "AppEnrollments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppStudentProgresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppEnrollments");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AppStudentProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AppEnrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentProgresses_StudentId",
                table: "AppStudentProgresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEnrollments_StudentId",
                table: "AppEnrollments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEnrollments_AppStudents_StudentId",
                table: "AppEnrollments",
                column: "StudentId",
                principalTable: "AppStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppStudentProgresses_AppStudents_StudentId",
                table: "AppStudentProgresses",
                column: "StudentId",
                principalTable: "AppStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
