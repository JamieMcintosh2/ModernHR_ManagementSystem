using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentService.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "performances",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    strengths = table.Column<string>(type: "text", nullable: false),
                    weaknesses = table.Column<string>(type: "text", nullable: false),
                    reviewDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_performances", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    performanceId = table.Column<int>(type: "integer", nullable: false),
                    feedback = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    overallScore = table.Column<int>(type: "integer", nullable: false),
                    feedbackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_feedbacks_performances_performanceId",
                        column: x => x.performanceId,
                        principalTable: "performances",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_performanceId",
                table: "feedbacks",
                column: "performanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "performances");

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    reviewDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    strengths = table.Column<string>(type: "text", nullable: false),
                    weaknesses = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    performanceId = table.Column<int>(type: "integer", nullable: false),
                    feedback = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    feedbackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    overallScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Feedback_Performance_performanceId",
                        column: x => x.performanceId,
                        principalTable: "Performance",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_performanceId",
                table: "Feedback",
                column: "performanceId");
        }
    }
}
