﻿// <auto-generated />
using System;
using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250416125047_CreatedSeedDatas")]
    partial class CreatedSeedDatas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RowNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RowNumber"));

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"),
                            CreatedAt = new DateTime(2023, 7, 24, 10, 0, 0, 0, DateTimeKind.Local),
                            IsDeleted = false,
                            Name = "Test Department",
                            RowNumber = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.TodoTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignedDepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RowNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RowNumber"));

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatusChangedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssignedDepartmentId");

                    b.HasIndex("CreatedById");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a7f8ae2f-5adb-46b7-a6b9-cf2af668ff2c"),
                            AssignedDepartmentId = new Guid("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"),
                            CreatedAt = new DateTime(2023, 7, 24, 10, 0, 0, 0, DateTimeKind.Local),
                            CreatedById = new Guid("a1759505-2118-47f1-9f77-1a7b9c6a49c4"),
                            Description = "Test description",
                            IsDeleted = false,
                            RowNumber = 0,
                            Status = 0,
                            StatusChangedAt = new DateTime(2025, 4, 16, 15, 50, 46, 495, DateTimeKind.Local).AddTicks(5057),
                            Title = "Test title"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RowNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RowNumber"));

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1759505-2118-47f1-9f77-1a7b9c6a49c4"),
                            CreatedAt = new DateTime(2023, 7, 24, 10, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"),
                            Email = "admin@taskmanagementsystem.com",
                            FirstName = "Admin",
                            IsDeleted = false,
                            LastName = "User",
                            RowNumber = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.TodoTask", b =>
                {
                    b.HasOne("Domain.Entities.Department", "AssignedDepartment")
                        .WithMany()
                        .HasForeignKey("AssignedDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedDepartment");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
