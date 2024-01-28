using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentService.Migrations
{
    public partial class updateFeedbackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_performances_performanceId",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_performanceId",
                table: "feedbacks");

            migrationBuilder.DropColumn(
                name: "performanceId",
                table: "feedbacks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "performanceId",
                table: "feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_performanceId",
                table: "feedbacks",
                column: "performanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_performances_performanceId",
                table: "feedbacks",
                column: "performanceId",
                principalTable: "performances",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
