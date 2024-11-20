using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learnify.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignmentresponserelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "AppAssignmentResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppAssignmentResponses_AssignmentId",
                table: "AppAssignmentResponses",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAssignmentResponses_AppAssignments_AssignmentId",
                table: "AppAssignmentResponses",
                column: "AssignmentId",
                principalTable: "AppAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAssignmentResponses_AppAssignments_AssignmentId",
                table: "AppAssignmentResponses");

            migrationBuilder.DropIndex(
                name: "IX_AppAssignmentResponses_AssignmentId",
                table: "AppAssignmentResponses");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "AppAssignmentResponses");
        }
    }
}
