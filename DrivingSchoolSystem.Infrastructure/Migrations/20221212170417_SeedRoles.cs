using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "bb5064e1-446e-425d-bf85-3b1d0ec2ed89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "8ad3b721-3e09-4d76-ae8c-4f6ac440d675");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "78508b03-0703-4f5f-9ed1-9267f32496ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                column: "ConcurrencyStamp",
                value: "e7b736f7-e95e-47da-8c7e-af3d90ecc5ed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea980200-c065-4473-8b62-f8c48a143771", "AQAAAAEAACcQAAAAEKDjXPKds8NRMqLd0XgdAWEqbA++7KVXVMSTzwgwXeiQIK8sMhCOxQ0Kx5Ngb85BtA==", "0ccce128-a89d-4334-be8b-a1607edb9100" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "819dd118-216a-4f36-834a-03bc364b2cff", "AQAAAAEAACcQAAAAEE4JftnacLw73oLVCKDGpbQC3t78tqmfYVS5z9qCsuE4oFnKamT4Klx2AUteCfthPQ==", "af275ac1-160c-4288-89a9-f0219a84ab57" });
        }
    }
}
