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
    [Migration("20240124132435_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DevelopmentService.Models.Feedback", b =>
                {
                    b.Property<int>("performanceId")
                        .HasColumnType("integer");

                    b.Property<string>("feedback")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<DateTimeOffset>("feedbackDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("overallScore")
                        .HasColumnType("integer");

                    b.HasKey("performanceId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("DevelopmentService.Models.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("DevelopmentService.Models.Feedback", b =>
                {
                    b.HasOne("DevelopmentService.Models.Performance", "Performance")
                        .WithMany()
                        .HasForeignKey("performanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Performance");
                });
#pragma warning restore 612, 618
        }
    }
}
