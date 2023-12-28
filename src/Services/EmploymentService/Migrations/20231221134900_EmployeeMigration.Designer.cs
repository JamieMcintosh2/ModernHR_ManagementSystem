﻿// <auto-generated />
using EmploymentService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmploymentService.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20231221134900_EmployeeMigration")]
    partial class EmployeeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmploymentService.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("jobId")
                        .HasColumnType("int");

                    b.Property<int>("officeId")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.HasIndex("jobId");

                    b.HasIndex("officeId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("EmploymentService.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("jobs");
                });

            modelBuilder.Entity("EmploymentService.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuildingNum")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("offices");
                });

            modelBuilder.Entity("EmploymentService.Models.Employee", b =>
                {
                    b.HasOne("EmploymentService.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("jobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmploymentService.Models.Office", "Office")
                        .WithMany()
                        .HasForeignKey("officeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Office");
                });
#pragma warning restore 612, 618
        }
    }
}
