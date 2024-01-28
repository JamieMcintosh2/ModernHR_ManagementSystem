using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevelopmentService.Migrations
{
    public partial class freshHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "historicalPerformance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn), // This line specifies auto-generation
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Strengths = table.Column<string>(type: "text", nullable: false),
                    Weaknesses = table.Column<string>(type: "text", nullable: false),
                    ReviewDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicalPerformance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "historicalFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn), // This line specifies auto-generation
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Feedback = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    OverallScore = table.Column<int>(type: "integer", nullable: false),
                    FeedbackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicalFeedback", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicalPerformance");

            migrationBuilder.DropTable(
                name: "historicalFeedback");
        }
    }
}
