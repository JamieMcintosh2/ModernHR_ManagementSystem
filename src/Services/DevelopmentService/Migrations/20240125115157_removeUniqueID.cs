﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentService.Migrations
{
    public partial class removeUniqueID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_performances",
                table: "performances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_feedbacks",
                table: "feedbacks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_performances",
                table: "performances",
                column: "EmpId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedbacks",
                table: "feedbacks",
                column: "EmpId");
        }
    }
}
