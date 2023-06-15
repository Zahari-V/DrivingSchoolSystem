using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class AddedDrivingSchoolLogoImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoImg",
                table: "DrivingSchools",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "https://img.freepik.com/premium-vector/cardrivingcarlogodrivingschoolsteeringwheellogovector2024_509644-247.jpg");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "2ef835de-fbb6-480e-b53b-a3624dfe6206");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "a70b6948-8e84-4189-96cf-7c29fd441fcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "4b36b682-f904-41e3-9b91-0f1da1d04f57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                column: "ConcurrencyStamp",
                value: "fce4dfee-4b9a-4510-9cde-6a680f43d082");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c989c4e-dbe2-4e41-9c89-4da865fe0ec1", "AQAAAAEAACcQAAAAEKtoymhgto+Y4Um1kOW99yH3DeaWwXWPYh64hM/dk2ldNfQgpPUj3kHZAxQFz5ynWw==", "74dfa58c-b9ed-4bea-871d-d479e9cba1fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoImg",
                table: "DrivingSchools");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0939e4a6-956d-4aec-89ab-c20db77048be", "AQAAAAEAACcQAAAAEIp0QZhz5wGQ18TdwDFcOcHAywWUG8pHGWrJUGi88pyvNliTPZNPSG6v6S7LvxcGdw==", "a55b3092-01d8-4763-99a9-5f29a90db32f" });
        }
    }
}
