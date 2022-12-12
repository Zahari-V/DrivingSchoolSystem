﻿// <auto-generated />
using System;
using DrivingSchoolSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DrivingSchoolId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DrivingSchoolId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://imgs.search.brave.com/FHh0vvdqKaQ4tRliDZYO09P2VZALnkDn_GFTCPyXHBs/rs:fit:400:250:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWEtZnRy/LWltZy00MDB4MjUw/LnBuZw",
                            Name = "Категория А"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://imgs.search.brave.com/Vtxrn9269ymjU-lrju3p0RDU-Bxyg6U4DvRJ0tVZcVo/rs:fit:480:367:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWExLTQ4/MHgzNjcucG5n",
                            Name = "Категория А1"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://imgs.search.brave.com/rZn_i_U4QdfSN8tIwPHyUNL_ibsMrcjHkt-fhUaVH5U/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWEyLWZ0/ci1pbWcucG5n",
                            Name = "Категория A2"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://imgs.search.brave.com/U0QAzA_anbbMsvGsPUXODhJd2HT74Q_TuXixh8DaZFg/rs:fit:700:536:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWItYjEu/cG5n",
                            Name = "Категория B"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "https://imgs.search.brave.com/UjwXBg0qLe2ers5_rw0ppBO_2oGTca4RL2eOkKMrkyc/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWItZS1m/dHItaW1nLnBuZw",
                            Name = "Категория B+E"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "https://imgs.search.brave.com/2vqlr1hK8Wa03qE8uEY-dqWxXBF9Yp8wA8P9UNPKZ4Y/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWMtZnRy/LWltZy5wbmc",
                            Name = "Категория C"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "https://imgs.search.brave.com/rYXho7__cqZo4sr1c--T7_B7D6u9HNWUsSp2DzTr3eI/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWMtZS1m/dHItaW1nLnBuZw",
                            Name = "Категория C+E"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "https://imgs.search.brave.com/VqKsfSA7_cYdRAeDKi-wMgnheJbvUh5HCzfhLWHzUXc/rs:fit:700:548:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWQucG5n",
                            Name = "Категория D"
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = "https://imgs.search.brave.com/Gd30GUaVD8I_B2tdcJbfMf7_wO4cBmYmubk01_fpYwk/rs:fit:400:250:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWQxLWZ0/ci1pbWctNDAweDI1/MC5wbmc",
                            Name = "Категория D1"
                        });
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.DrivingSchool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneContact")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("DrivingSchools");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.DrivingSchoolCategory", b =>
                {
                    b.Property<int>("DrivingSchoolId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("DrivingSchoolId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("DrivingSchoolsCategories");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.InstructorCategory", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("InstructorsCategories");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateForDrive")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("StudentCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentCardId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.StudentCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DrivedHours")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCards");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasDefaultValue("https://imgs.search.brave.com/G4V3oO6hyzU7zIFGh46tw2rNQQr1sCgN0b2sygyE3-Q/rs:fit:820:641:1/g:ce/aHR0cHM6Ly93d3cu/cG5na2l0LmNvbS9w/bmcvZGV0YWlsLzI4/MS0yODEyODIxX3Vz/ZXItYWNjb3VudC1t/YW5hZ2VtZW50LWxv/Z28tdXNlci1pY29u/LXBuZy5wbmc");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5b837013-946c-406e-8fce-9631c2844350",
                            AccessFailedCount = 0,
                            AccountId = new Guid("00000000-0000-0000-0000-000000000000"),
                            ConcurrencyStamp = "ea980200-c065-4473-8b62-f8c48a143771",
                            Email = "admin@abv.bg",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ABV.BG",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEKDjXPKds8NRMqLd0XgdAWEqbA++7KVXVMSTzwgwXeiQIK8sMhCOxQ0Kx5Ngb85BtA==",
                            PhoneNumber = "0889324353",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0ccce128-a89d-4334-be8b-a1607edb9100",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                            ConcurrencyStamp = "78508b03-0703-4f5f-9ed1-9267f32496ce",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "42196e3c-e72a-4778-994f-36c85380e060",
                            ConcurrencyStamp = "bb5064e1-446e-425d-bf85-3b1d0ec2ed89",
                            Name = "Instructor",
                            NormalizedName = "INSTRUCTOR"
                        },
                        new
                        {
                            Id = "9b325984-c63f-4dec-a00b-eeaab3d34035",
                            ConcurrencyStamp = "8ad3b721-3e09-4d76-ae8c-4f6ac440d675",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                            ConcurrencyStamp = "e7b736f7-e95e-47da-8c7e-af3d90ecc5ed",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "5b837013-946c-406e-8fce-9631c2844350",
                            RoleId = "b4656095-c561-4bfa-a5ad-08f7678af1bf"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Account", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.DrivingSchool", "DrivingSchool")
                        .WithMany("Accounts")
                        .HasForeignKey("DrivingSchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("DrivingSchoolSystem.Infrastructure.Data.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("DrivingSchool");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Course", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Manager", "Manager")
                        .WithMany("Courses")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.DrivingSchoolCategory", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("DrivingSchoolsCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.DrivingSchool", "DrivingSchool")
                        .WithMany("EducationCategories")
                        .HasForeignKey("DrivingSchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("DrivingSchool");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Instructor", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.InstructorCategory", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("InstructorsCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Instructor", "Instructor")
                        .WithMany("InstructorsCategories")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Manager", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Schedule", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.StudentCard", "StudentCard")
                        .WithMany("Schedules")
                        .HasForeignKey("StudentCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentCard");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Student", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.StudentCard", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Course", "Course")
                        .WithMany("StudentCards")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Instructor", "Instructor")
                        .WithMany("StudentCards")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.Student", "Student")
                        .WithMany("StudentCards")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DrivingSchoolSystem.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("DrivingSchoolsCategories");

                    b.Navigation("InstructorsCategories");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Course", b =>
                {
                    b.Navigation("StudentCards");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.DrivingSchool", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("EducationCategories");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Instructor", b =>
                {
                    b.Navigation("InstructorsCategories");

                    b.Navigation("StudentCards");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Manager", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.Student", b =>
                {
                    b.Navigation("StudentCards");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.StudentCard", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("DrivingSchoolSystem.Infrastructure.Data.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
