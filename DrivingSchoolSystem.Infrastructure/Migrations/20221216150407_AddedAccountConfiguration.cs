using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class AddedAccountConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_DrivingSchools_DrivingSchoolId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Accounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DrivingSchoolId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "DrivingSchoolId", "Email", "FirstName", "LastName", "MiddleName", "NormalizedEmail", "PhoneNumber", "RoleId", "UserId" },
                values: new object[] { new Guid("db4b5796-75a6-4c96-9c1b-98ee8dbee27d"), null, "admin@abv.bg", "Петър", "Тодоров", "Петров", "ADMIN@ABV.BG", "0889324353", "b4656095-c561-4bfa-a5ad-08f7678af1bf", "5b837013-946c-406e-8fce-9631c2844350" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "27201999-5d7f-4233-94b5-535a9c72ba7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "33dacbb0-abbc-4ff0-9b6b-cb0bc4a9adfd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "c0755835-e07c-4e1c-9382-bd82b88b312f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                column: "ConcurrencyStamp",
                value: "24b8e386-3499-4168-9cc0-e9aeeb7a4e51");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350",
                columns: new[] { "AccountId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new Guid("db4b5796-75a6-4c96-9c1b-98ee8dbee27d"), "0939e4a6-956d-4aec-89ab-c20db77048be", "AQAAAAEAACcQAAAAEIp0QZhz5wGQ18TdwDFcOcHAywWUG8pHGWrJUGi88pyvNliTPZNPSG6v6S7LvxcGdw==", "a55b3092-01d8-4763-99a9-5f29a90db32f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_DrivingSchools_DrivingSchoolId",
                table: "Accounts",
                column: "DrivingSchoolId",
                principalTable: "DrivingSchools",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_DrivingSchools_DrivingSchoolId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("db4b5796-75a6-4c96-9c1b-98ee8dbee27d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "DrivingSchoolId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_DrivingSchools_DrivingSchoolId",
                table: "Accounts",
                column: "DrivingSchoolId",
                principalTable: "DrivingSchools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
