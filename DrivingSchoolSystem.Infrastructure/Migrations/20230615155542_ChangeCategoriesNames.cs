using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class ChangeCategoriesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "cb65987e-f5dc-4d23-980f-1307b240165f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "182cf248-8d16-4c87-a966-477dc9d340cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "be70fe8c-0676-4b3a-a854-2fbe1cca0622");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                column: "ConcurrencyStamp",
                value: "06924d56-5150-4cc5-9224-3333554a187a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b837013-946c-406e-8fce-9631c2844350",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5034e748-076d-4695-aebb-a3cf65fd65c1", "AQAAAAEAACcQAAAAEIbExjeAgs1YFY55kESxSwpKpei8MEP5un0ZBwInHW+dom4Td3Rvw08gTeDuqcbOsA==", "21a1188b-23f6-4696-8507-21145f886549" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "А");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "А1");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "A2");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "B");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "B+E");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "C");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "C+E");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "D");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "D1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Категория А");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Категория А1");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Категория A2");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Категория B");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Категория B+E");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Категория C");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Категория C+E");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Категория D");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Категория D1");
        }
    }
}
