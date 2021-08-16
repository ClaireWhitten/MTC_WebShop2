using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "3ba08e02-85b4-4488-8108-e526aa987eed" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee9e763-1f51-4d0d-a463-b7a8a791234b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ba08e02-85b4-4488-8108-e526aa987eed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "768a00b5-7dac-4157-a351-0b34ba09e76f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "2b0edfd3-320c-418c-97c6-6770f60a1279");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ee764bb4-d56f-43a6-a9e0-38d1ee69460f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "6b9f5326-7629-45c0-a849-531a855f0e31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d24a001-91c4-434e-b14f-7263ca2bf39c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5010307-42d6-4b4e-b857-6924862d5c0d", "AQAAAAEAACcQAAAAEOOh/KAPO0OMDTvbY/HlYp0mp+0bWQoUNyi7oRNxw6La3igL5dqc3Cxx9A/dOen6+Q==", "c3cb57ca-4fa3-49c8-9871-76722f1b0362" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84479e99-a2b8-4555-8e8f-6123844367c6", "AQAAAAEAACcQAAAAECvr66c4F+2xKsI089OPH+p6Wf6bSUzmaAlJMocvVJI7E2YVMjYPNxw+y7f2da6WxQ==", "88508d75-3d3d-4064-9ce1-89206ab22f3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bfe016a-c883-42fd-acce-edc911c382be", "AQAAAAEAACcQAAAAEL2A3MAAISxYY+QI2zQff5gVAvkUHoV82hElZlNYwfGa50P1yUkDG4Sgz8PVPOl5gQ==", "3308e7ed-5735-43be-baa8-3fe3b4067b22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52d868e9-9ddd-497e-80b9-3d2d602a54d8", "AQAAAAEAACcQAAAAEF4zddCgt14tvVlThnv6nTK5xN/7GKwyCuocNTmRdWgHmqBIS/xNgIA2/UTG4z7qcA==", "ff11a379-5b30-4264-9de4-b567f2ca7acf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f34ac968-6fc7-4f43-8aa7-734c6e8b4c33", "AQAAAAEAACcQAAAAEM3xUk9V8CouqErzUrK8JdcaameABu1UZ8c8uWUR4nj2frjSbAtaSuN1TfvULf+JDQ==", "ee693011-9c80-4ae2-9dd9-222800cede04" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "1f0ecbb3-6371-48d8-97fe-2aa52d512cc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "68cd41be-5292-43d5-b976-e6aee214c94c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ebb395e1-ec38-4b78-bb91-8c7d80742157");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "06478b81-b42a-4932-985b-ac1ee331b13a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51028b7a-f4d6-4f07-a7ef-11b041e9efc6", "UserAdmin", "USERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsRemovable", "Name", "NormalizedName" },
                values: new object[] { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "38742ca1-3f0b-45e8-86ce-6db68c7549ea", false, "Moderator", "MODERATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f76dfa9-f229-475f-83db-c85c7fccef23", "AQAAAAEAACcQAAAAENsAnpOCMlMKpCX/f/KZxzCMxc7tzqVPVzoc4Sl0eNIVE3ngJ6/f16kIedLgOK8omw==", "1b5b6f50-ea82-4231-8707-05b5fa0ebebc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d332e37c-8cb8-4e04-94f9-c9935be15b3a", "AQAAAAEAACcQAAAAEAJBwlmybe72jqZSzzNhYamIIQ6QdtE5LO/Vai4kVuThtf+KOXRdh2SMsjaJthlS4Q==", "0e7b8d86-4b42-4629-94c5-5d8fb0d0a6bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa0a1148-aa70-4e8e-a1d7-ca4c8ca9bdec", "AQAAAAEAACcQAAAAEIOSe199penX9iEzffrbK4/a8rAWOyb3LnMkQ9/5qEQZgWrJGz86IIfU5sNmy/2CVQ==", "5d0f5477-24e8-446b-ae3c-f8943755c9f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3249898e-cf08-473e-a2fd-6cd6fcf0dafe", "AQAAAAEAACcQAAAAEOFMYMdw0yjqhmFYyqgXGbgZ+yBXPHk283nPO6ZOG4XOM7gxEAZvB1OHy6Hc+Xxvxg==", "b9e747b1-2127-4001-af9d-0e640f374f78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "272f6415-b209-4774-b447-13fbbbc13884", "AQAAAAEAACcQAAAAEJi8aR8KrHHd6vIR8cJt9WoEWniWS3viwsGlLm+xa9mpL0lClAVmovKEKCEHEjdzEg==", "a2175e9d-b6fe-476c-a512-93fe6bcefaa2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ClientId", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "IsRemovable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SupplierId", "TransporterId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ba08e02-85b4-4488-8108-e526aa987eed", 0, null, "ff1bf7ca-5130-475d-82b8-6864a28c5fde", "moderator@mtc.com", true, true, false, false, null, "MODERATOR@MTC.COM", "MODERATOR@MTC.COM", "AQAAAAEAACcQAAAAEHOSah1etE/d7+y/qFEKhdzxGLRDev8Gfak5DwFeerlaop/HzobBJ7lkOefiGjSQsw==", null, false, "6b0c9bc5-eda5-442a-983b-671ec88a3c20", null, null, false, "moderator@mtc.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "3ba08e02-85b4-4488-8108-e526aa987eed" });
        }
    }
}
