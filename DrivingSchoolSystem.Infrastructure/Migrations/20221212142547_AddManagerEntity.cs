using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class AddManagerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Manager_ManagerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Accounts_ManagerId",
                table: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Managers",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Manager_ManagerId",
                table: "Managers",
                newName: "IX_Managers_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Managers_ManagerId",
                table: "Courses",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Accounts_AccountId",
                table: "Managers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Managers_ManagerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Accounts_AccountId",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Manager",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_AccountId",
                table: "Manager",
                newName: "IX_Manager_ManagerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "7705e687-9352-4e0a-b318-5f2e46c577dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "e540140b-4fac-4276-8912-afc37e0f0b51");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "1483e98d-c94a-4dd2-9bee-7aa3494dc113");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                column: "ConcurrencyStamp",
                value: "d6883662-8fe5-4167-8480-6739da1c0959");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b93fc1d3-421a-4003-a104-035181a22d6b", "AQAAAAEAACcQAAAAEF1Qf7+Q5p3ZmXOH022KWXWUW0vUHTbvc0kwWfkRJVJf2xQR/8AgyyIdpPZevSrOyg==", "c653ebef-76d7-4125-aba1-72fea93fa7a6" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Manager_ManagerId",
                table: "Courses",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Accounts_ManagerId",
                table: "Manager",
                column: "ManagerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
