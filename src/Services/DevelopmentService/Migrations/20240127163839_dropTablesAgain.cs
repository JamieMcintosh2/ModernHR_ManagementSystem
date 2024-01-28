using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentService.Migrations
{
    public partial class dropTablesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpPerformanceHistories");

            migrationBuilder.DropTable(
                name: "EmpFeedbackHistories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
