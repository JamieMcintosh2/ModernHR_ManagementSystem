using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentService.Migrations
{
    public partial class tryAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpFeedbackHistories_feedbacks_EmpFeedbackEmpId",
                table: "EmpFeedbackHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpPerformanceHistories_performances_EmpPerformanceEmpId",
                table: "EmpPerformanceHistories");

            migrationBuilder.DropIndex(
                name: "IX_EmpPerformanceHistories_EmpPerformanceEmpId",
                table: "EmpPerformanceHistories");

            migrationBuilder.DropIndex(
                name: "IX_EmpFeedbackHistories_EmpFeedbackEmpId",
                table: "EmpFeedbackHistories");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "EmpPerformanceHistories");

            migrationBuilder.DropColumn(
                name: "EmpFeedbackEmpId",
                table: "EmpFeedbackHistories");

            migrationBuilder.RenameColumn(
                name: "EmpPerformanceEmpId",
                table: "EmpPerformanceHistories",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "EmpFeedbackHistories",
                newName: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmpPerformanceHistories",
                newName: "EmpPerformanceEmpId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmpFeedbackHistories",
                newName: "EmpId");

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "EmpPerformanceHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpFeedbackEmpId",
                table: "EmpFeedbackHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmpPerformanceHistories_EmpPerformanceEmpId",
                table: "EmpPerformanceHistories",
                column: "EmpPerformanceEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFeedbackHistories_EmpFeedbackEmpId",
                table: "EmpFeedbackHistories",
                column: "EmpFeedbackEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpFeedbackHistories_feedbacks_EmpFeedbackEmpId",
                table: "EmpFeedbackHistories",
                column: "EmpFeedbackEmpId",
                principalTable: "feedbacks",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpPerformanceHistories_performances_EmpPerformanceEmpId",
                table: "EmpPerformanceHistories",
                column: "EmpPerformanceEmpId",
                principalTable: "performances",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
