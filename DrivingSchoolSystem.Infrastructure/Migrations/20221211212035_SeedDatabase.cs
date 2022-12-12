using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42196e3c-e72a-4778-994f-36c85380e060", "7705e687-9352-4e0a-b318-5f2e46c577dd", "Instructor", "INSTRUCTOR" },
                    { "9b325984-c63f-4dec-a00b-eeaab3d34035", "e540140b-4fac-4276-8912-afc37e0f0b51", "Student", "STUDENT" },
                    { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "1483e98d-c94a-4dd2-9bee-7aa3494dc113", "Admin", "ADMIN" },
                    { "f33ee30d-f3c5-4243-b4b8-a7fa240c3707", "d6883662-8fe5-4167-8480-6739da1c0959", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5b837013-946c-406e-8fce-9631c2844350", 0, new Guid("00000000-0000-0000-0000-000000000000"), "b93fc1d3-421a-4003-a104-035181a22d6b", "admin@abv.bg", true, false, null, "ADMIN@ABV.BG", "ADMIN", "AQAAAAEAACcQAAAAEF1Qf7+Q5p3ZmXOH022KWXWUW0vUHTbvc0kwWfkRJVJf2xQR/8AgyyIdpPZevSrOyg==", "0889324353", false, "c653ebef-76d7-4125-aba1-72fea93fa7a6", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://imgs.search.brave.com/FHh0vvdqKaQ4tRliDZYO09P2VZALnkDn_GFTCPyXHBs/rs:fit:400:250:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWEtZnRy/LWltZy00MDB4MjUw/LnBuZw", "Категория А" },
                    { 2, "https://imgs.search.brave.com/Vtxrn9269ymjU-lrju3p0RDU-Bxyg6U4DvRJ0tVZcVo/rs:fit:480:367:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWExLTQ4/MHgzNjcucG5n", "Категория А1" },
                    { 3, "https://imgs.search.brave.com/rZn_i_U4QdfSN8tIwPHyUNL_ibsMrcjHkt-fhUaVH5U/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWEyLWZ0/ci1pbWcucG5n", "Категория A2" },
                    { 4, "https://imgs.search.brave.com/U0QAzA_anbbMsvGsPUXODhJd2HT74Q_TuXixh8DaZFg/rs:fit:700:536:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWItYjEu/cG5n", "Категория B" },
                    { 5, "https://imgs.search.brave.com/UjwXBg0qLe2ers5_rw0ppBO_2oGTca4RL2eOkKMrkyc/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWItZS1m/dHItaW1nLnBuZw", "Категория B+E" },
                    { 6, "https://imgs.search.brave.com/2vqlr1hK8Wa03qE8uEY-dqWxXBF9Yp8wA8P9UNPKZ4Y/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWMtZnRy/LWltZy5wbmc", "Категория C" },
                    { 7, "https://imgs.search.brave.com/rYXho7__cqZo4sr1c--T7_B7D6u9HNWUsSp2DzTr3eI/rs:fit:900:900:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWMtZS1m/dHItaW1nLnBuZw", "Категория C+E" },
                    { 8, "https://imgs.search.brave.com/VqKsfSA7_cYdRAeDKi-wMgnheJbvUh5HCzfhLWHzUXc/rs:fit:700:548:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWQucG5n", "Категория D" },
                    { 9, "https://imgs.search.brave.com/Gd30GUaVD8I_B2tdcJbfMf7_wO4cBmYmubk01_fpYwk/rs:fit:400:250:1/g:ce/aHR0cHM6Ly9rYXJh/aS5iZS93cC1jb250/ZW50L3VwbG9hZHMv/MjAyMC8wNS9rYXRl/Z29yaXlhLWQxLWZ0/ci1pbWctNDAweDI1/MC5wbmc", "Категория D1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "5b837013-946c-406e-8fce-9631c2844350" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "5b837013-946c-406e-8fce-9631c2844350" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350");
        }
    }
}
