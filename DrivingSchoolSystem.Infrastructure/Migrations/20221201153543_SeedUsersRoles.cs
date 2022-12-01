using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class SeedUsersRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "c65dc741-1118-4d90-b27c-c2643611662d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "267228cb-ee4e-4a51-abf3-e7c2266b67a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "ce8ca732-cd81-4d88-bb14-ab7cc6685048");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "65474606-d7e0-48a6-a6b3-3136c233dd4d" },
                    { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "a98e90bc-1adc-4f87-bb4e-9e12a2d39090" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65474606-d7e0-48a6-a6b3-3136c233dd4d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00a4f2ab-0823-4cc6-839f-9fe56d73196f", "b7bd9a12-9880-4367-ae8b-28afce922d40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a98e90bc-1adc-4f87-bb4e-9e12a2d39090",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "15a4c9ce-aecb-4025-b8a3-3f33afe78950", "53d25e44-4787-4449-8d9d-944e43613a04" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "65474606-d7e0-48a6-a6b3-3136c233dd4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "a98e90bc-1adc-4f87-bb4e-9e12a2d39090" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "c3f92961-ee05-4cb5-8293-e558b626d8a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "9f9d8e63-3ee9-4fc7-97d8-0354f7b09408");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "ab7830bc-58e6-4e2f-a4c1-41b34ca4f00c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65474606-d7e0-48a6-a6b3-3136c233dd4d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e61764a-d0f4-434b-83a6-262b3fa0a444", "172c08e1-14a0-42a0-a6a5-f8b326596b7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a98e90bc-1adc-4f87-bb4e-9e12a2d39090",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1db3002e-4629-43ee-9968-0d83e686a026", "033aa7cb-f69b-4c3e-a90b-3552c5892196" });
        }
    }
}
