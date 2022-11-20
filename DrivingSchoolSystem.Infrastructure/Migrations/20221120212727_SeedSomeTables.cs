using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class SeedSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DrivingSchoolId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42196e3c-e72a-4778-994f-36c85380e060", "ceecb815-d838-43b7-8327-6d6e9625df23", "Instructor", "INSTRUCTOR" },
                    { "9b325984-c63f-4dec-a00b-eeaab3d34035", "55e887f4-e44f-4612-8fd1-239f8a62f9dd", "Student", "STUDENT" },
                    { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "f99e19ed-43fb-46e9-b00c-e26d98c48e7d", "Admin", "ADMIN" }
                });

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
                table: "DrivingSchools",
                columns: new[] { "Id", "Address", "Name", "PhoneContact", "Town" },
                values: new object[,]
                {
                    { 1, "ул. „Железничарска“ 34", "\"Автостарт - Великин\" ЕООД", "0888129915", "Видин" },
                    { 2, "ул. „Въстаник“ 5", "\"РОСЕН - 85\" ООД", "0899833302", "София" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DrivingSchoolId", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "65474606-d7e0-48a6-a6b3-3136c233dd4d", 0, "8c8ee137-dafa-4073-acb6-2d96ffeb66bb", 2, "rosen85_Sofia@abv.bg", false, "Petar", "https://imgs.search.brave.com/7RoZdgbwxvnACxZN74kJ9Cc7y2r9peTmTq-0bEu7zmE/rs:fit:1200:1024:1/g:ce/aHR0cDovL3d3dy5w/c2RncmFwaGljcy5j/b20vZmlsZS91c2Vy/LWljb24uanBn", "Petrov", false, null, "Lubenov", "ROSEN85_SOFIA@ABV.BG", "ADMIN-ROSEN85-SOFIA", "AQAAAAEAACcQAAAAEAG0guR2eTpKqENYy79NR05bcVevhe+R6UECRlY75YFMNiuk8mvxjdqXRKwZiqFSNQ==", "0889312141", false, "6c548ec5-19ca-46fc-8bd7-68095c5dd446", false, "Admin-Rosen85-Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DrivingSchoolId", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a98e90bc-1adc-4f87-bb4e-9e12a2d39090", 0, "c7ba5b48-9a52-4391-bb3c-3a54743dc25a", 1, "avtostart_Vidin@abv.bg", false, "Georgi", "https://imgs.search.brave.com/toKRUCUyE8TM1qEktBt5ukJhyHFq1j4ZJ555sHuxI7I/rs:fit:1200:1200:1/g:ce/aHR0cDovL3BsdXNw/bmcuY29tL2ltZy1w/bmcvdXNlci1wbmct/aWNvbi15b3VuZy11/c2VyLWljb24tMjQw/MC5wbmc", "Georgiev", false, null, "Krasimirov", "AVTOSTART_VIDIN@ABV.BG", "ADMIN-AVTOSTART-VIDIN", "AQAAAAEAACcQAAAAEJMWSj0UFwVOW+brFGr9ew91/Qy9z37eDTKEgad0fLZZ8EmyuFp/2XtSueTRnarFWQ==", "0888326291", false, "c96d1439-fec4-4b3f-ab7d-44806ae47891", false, "Admin-Avtostart-Vidin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "65474606-d7e0-48a6-a6b3-3136c233dd4d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "a98e90bc-1adc-4f87-bb4e-9e12a2d39090" });
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
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "65474606-d7e0-48a6-a6b3-3136c233dd4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "a98e90bc-1adc-4f87-bb4e-9e12a2d39090" });

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
                keyValue: "65474606-d7e0-48a6-a6b3-3136c233dd4d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a98e90bc-1adc-4f87-bb4e-9e12a2d39090");

            migrationBuilder.DeleteData(
                table: "DrivingSchools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DrivingSchools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "DrivingSchoolId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
