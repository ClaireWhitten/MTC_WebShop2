using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsRemovable", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "cb80d1f4-b62b-405f-938c-64f7b1bcb233", false, "SuperAdmin", "SUPERADMIN" },
                    { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "fb1c7bd9-a508-4ff3-b27a-3412cff4bfb3", false, "UserAdmin", "USERADMIN" },
                    { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "c18ea18f-3fab-465b-8923-8040bb4b5c4e", false, "Moderator", "MODERATOR" },
                    { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "98750fc7-6c44-4a5b-a732-88f5740fa2e7", false, "Client", "CLIENT" },
                    { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "52437f6a-82e3-4582-9b31-7547ff7e175b", false, "Transporter", "TRANSPORTER" },
                    { "277f86fd-db6a-449a-a7de-25917a177a61", "9ec5b9f9-a95c-4297-8b53-8d56961b7605", false, "Supplier", "SUPPLIER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "331260cc-dacd-4675-8346-078e583e5f9e", "AQAAAAEAACcQAAAAEJTK4DAwyx1Y3503geIQOKJi186OwIDCCnp1eY7nszBNc0H69tl4lgNZJyJl7OCUUg==", "c9a1028a-a8c8-428e-a2d1-53face8389a2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "277f86fd-db6a-449a-a7de-25917a177a61", "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "277f86fd-db6a-449a-a7de-25917a177a61", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee9e763-1f51-4d0d-a463-b7a8a791234b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fda5ee32-4560-45a6-8e23-204cfdc85672", "AQAAAAEAACcQAAAAEGALjQkwRg//z58ffk2pLsykbk534/m3uWenXtfhRSIIFPVtixeI9dEaEbxkjNtMDA==", "cbdae444-c6b6-424f-bed3-e7cd57a6b430" });
        }
    }
}
