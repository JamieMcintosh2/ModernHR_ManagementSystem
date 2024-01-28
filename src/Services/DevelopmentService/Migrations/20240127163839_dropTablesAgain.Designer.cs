﻿// <auto-generated />
using System;
using DevelopmentService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevelopmentService.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20240127163839_dropTablesAgain")]
    partial class dropTablesAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DevelopmentService.Models.EmpFeedback", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnType("integer");

                    b.Property<string>("feedback")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<DateTimeOffset>("feedbackDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("overallScore")
                        .HasColumnType("integer");

                    b.HasKey("EmpId");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("DevelopmentService.Models.EmpPerformance", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("reviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("strengths")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("weaknesses")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EmpId");

                    b.ToTable("performances");
                });

            modelBuilder.Entity("DevelopmentService.Models.FeedbackHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<DateTimeOffset>("FeedbackDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OverallScore")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("EmpFeedbackHistories");
                });

            modelBuilder.Entity("DevelopmentService.Models.PerformanceHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("ReviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Strengths")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Weaknesses")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmpPerformanceHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
