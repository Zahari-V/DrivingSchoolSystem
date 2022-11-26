using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolSystem.Infrastructure.Migrations
{
    public partial class AddIsRegisteredInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "f86e1120-a1dc-4e64-803b-96ca4787d21d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "7290ae6e-912d-44f9-b424-0e4a003dff96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "4264fac7-5c45-4d8a-ac1c-e685d4ae5276");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65474606-d7e0-48a6-a6b3-3136c233dd4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "598fb101-4a36-497e-978b-7f5a6dbf8d86", "AQAAAAEAACcQAAAAEIVznuGuW47E9Yt0alRGinUlOIem1eARzktHdF84iFd0pU4Dsv4HgFb2ts1xw9ZU+g==", "4761e7d2-ef03-4038-afde-bc5096c68e76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a98e90bc-1adc-4f87-bb4e-9e12a2d39090",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eeeab4e0-80d8-4e31-8205-905befe222af", "AQAAAAEAACcQAAAAEAZBODIYnRMIniMfEyK+UP7ia25xqMHUk6LPhYrq/G90jXyOOS5jIKKFI/A/2y3qVg==", "d2122eac-1210-432d-9f4c-13e94f31eeea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42196e3c-e72a-4778-994f-36c85380e060",
                column: "ConcurrencyStamp",
                value: "ceecb815-d838-43b7-8327-6d6e9625df23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b325984-c63f-4dec-a00b-eeaab3d34035",
                column: "ConcurrencyStamp",
                value: "55e887f4-e44f-4612-8fd1-239f8a62f9dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                column: "ConcurrencyStamp",
                value: "f99e19ed-43fb-46e9-b00c-e26d98c48e7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65474606-d7e0-48a6-a6b3-3136c233dd4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c8ee137-dafa-4073-acb6-2d96ffeb66bb", "AQAAAAEAACcQAAAAEAG0guR2eTpKqENYy79NR05bcVevhe+R6UECRlY75YFMNiuk8mvxjdqXRKwZiqFSNQ==", "6c548ec5-19ca-46fc-8bd7-68095c5dd446" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a98e90bc-1adc-4f87-bb4e-9e12a2d39090",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7ba5b48-9a52-4391-bb3c-3a54743dc25a", "AQAAAAEAACcQAAAAEJMWSj0UFwVOW+brFGr9ew91/Qy9z37eDTKEgad0fLZZ8EmyuFp/2XtSueTRnarFWQ==", "c96d1439-fec4-4b3f-ab7d-44806ae47891" });
        }
    }
}
