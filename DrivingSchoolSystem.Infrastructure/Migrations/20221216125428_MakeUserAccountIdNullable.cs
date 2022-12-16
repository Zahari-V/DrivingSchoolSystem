using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class MakeUserAccountIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "661afd00-e7eb-427b-bbd2-2682c55056cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "ff677625-db93-435f-a5e8-d98e31925e97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "1080bc79-e937-4bde-9335-5bd049e5a663");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                column: "ConcurrencyStamp",
                value: "35c2efd3-ad23-4776-bfe7-666804dc7d2e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350",
                columns: new[] { "AccountId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "6daeccc7-2641-44d7-b1b2-79449379a5bf", "AQAAAAEAACcQAAAAEKv/HLHm7WoyfmUCAAjgE6Xu7Hao2o5vJTSzRqYH2oOjoyXAa7xUHXbe96gwk4hwiw==", "3300e825-c661-4e3c-bebb-00331169012b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "d3833b6f-6c54-4312-accd-e255eb44f6bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "e1403a79-53ac-4547-afad-15d2a30bacfa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "7bbdb3cf-ab03-4e41-ae0a-77d8295fb3a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                column: "ConcurrencyStamp",
                value: "f802042f-5de8-43c2-b61f-dcd91e85bc1d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350",
                columns: new[] { "AccountId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "819dd118-216a-4f36-834a-03bc364b2cff", "AQAAAAEAACcQAAAAEE4JftnacLw73oLVCKDGpbQC3t78tqmfYVS5z9qCsuE4oFnKamT4Klx2AUteCfthPQ==", "af275ac1-160c-4288-89a9-f0219a84ab57" });
        }
    }
}
