using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevelopmentService.Migrations
{
    public partial class addHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpFeedbackHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    Feedback = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    OverallScore = table.Column<int>(type: "integer", nullable: false),
                    FeedbackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EmpFeedbackEmpId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFeedbackHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFeedbackHistories_feedbacks_EmpFeedbackEmpId",
                        column: x => x.EmpFeedbackEmpId,
                        principalTable: "feedbacks",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpPerformanceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    Strengths = table.Column<string>(type: "text", nullable: false),
                    Weaknesses = table.Column<string>(type: "text", nullable: false),
                    ReviewDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EmpPerformanceEmpId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPerformanceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPerformanceHistories_performances_EmpPerformanceEmpId",
                        column: x => x.EmpPerformanceEmpId,
                        principalTable: "performances",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpFeedbackHistories_EmpFeedbackEmpId",
                table: "EmpFeedbackHistories",
                column: "EmpFeedbackEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPerformanceHistories_EmpPerformanceEmpId",
                table: "EmpPerformanceHistories",
                column: "EmpPerformanceEmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpFeedbackHistories");

            migrationBuilder.DropTable(
                name: "EmpPerformanceHistories");
        }
    }
}
