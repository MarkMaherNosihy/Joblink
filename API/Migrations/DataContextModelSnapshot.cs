﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("API.Entities.Application", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("JobId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("API.Entities.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("API.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Field")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int>("OpenPositions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AccountCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("API.Entities.Company", b =>
                {
                    b.HasBaseType("API.Entities.User");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<short>("CompanySize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Founded")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("API.Entities.Employee", b =>
                {
                    b.HasBaseType("API.Entities.User");

                    b.Property<string>("CV_URL")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("API.Entities.Application", b =>
                {
                    b.HasOne("API.Entities.Employee", "Employee")
                        .WithMany("Applications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("API.Entities.Experience", b =>
                {
                    b.HasOne("API.Entities.Employee", "Employee")
                        .WithMany("Experiences")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Entities.Job", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("API.Entities.Employee", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Experiences");
                });
#pragma warning restore 612, 618
        }
    }
}
