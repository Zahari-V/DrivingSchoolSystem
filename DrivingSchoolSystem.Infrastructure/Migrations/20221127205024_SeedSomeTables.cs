using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class SeedSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42196e3c-e72a-4778-994f-36c85380e060", "981d9a40-3b7c-4eca-a1f7-a19e7e03b28e", "Instructor", "INSTRUCTOR" },
                    { "9b325984-c63f-4dec-a00b-eeaab3d34035", "f891606d-bd58-4efd-9015-a25bcf757c9f", "Student", "STUDENT" },
                    { "b4656095-c561-4bfa-a5ad-08f7678af1bf", "0c041daa-3b91-4a75-aef6-9c35f13da138", "Admin", "ADMIN" }
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DrivingSchoolId", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsRegistered", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "65474606-d7e0-48a6-a6b3-3136c233dd4d", 0, "1b0b2c41-22ce-401a-aa81-6e078ce1a188", 2, "rosen85_Sofia@abv.bg", false, "Петър", "https://imgs.search.brave.com/7RoZdgbwxvnACxZN74kJ9Cc7y2r9peTmTq-0bEu7zmE/rs:fit:1200:1024:1/g:ce/aHR0cDovL3d3dy5w/c2RncmFwaGljcy5j/b20vZmlsZS91c2Vy/LWljb24uanBn", true, "Петров", false, null, "Любенов", "ROSEN85_SOFIA@ABV.BG", "ADMIN-ROSEN85-SOFIA", "AQAAAAEAACcQAAAAEOvAOCN3Sezazx2q+T2TOutExyi3KLSUc2LfMAClTTK4MQq8VvwgALfRMfyXzIAuOQ==", "0889312141", false, "8a92ec70-fb80-44c8-9a58-c74fbab12f2e", false, "Admin-Rosen85-Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DrivingSchoolId", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsRegistered", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a98e90bc-1adc-4f87-bb4e-9e12a2d39090", 0, "240c7d30-2224-498a-9bc5-453129f727cf", 1, "avtostart_Vidin@abv.bg", false, "Георги", "https://imgs.search.brave.com/toKRUCUyE8TM1qEktBt5ukJhyHFq1j4ZJ555sHuxI7I/rs:fit:1200:1200:1/g:ce/aHR0cDovL3BsdXNw/bmcuY29tL2ltZy1w/bmcvdXNlci1wbmct/aWNvbi15b3VuZy11/c2VyLWljb24tMjQw/MC5wbmc", true, "Георгиев", false, null, "Красимиров", "AVTOSTART_VIDIN@ABV.BG", "ADMIN-AVTOSTART-VIDIN", "AQAAAAEAACcQAAAAEOFmBJZ0ptyT/3dYrsq6ePqEY/RKm20NbcBeyKJHD6Q9q+LZRuXb8YfJW+8R+K6H4g==", "0888326291", false, "46024205-8cbd-49c1-8293-eb7426c08ce9", false, "Admin-Avtostart-Vidin" });

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
        }
    }
}
