using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "Suppliers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "ac7f63fc-1244-46ba-b379-13c3aa00e75c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "36c8321d-1835-4a80-8c12-87bbcf3ac07f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c7f163bd-e204-4bb8-b7b2-dd210709f640");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee9e763-1f51-4d0d-a463-b7a8a791234b",
                column: "ConcurrencyStamp",
                value: "8429c788-6bc5-48ea-82f8-96753312b9c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "5e998a16-ff98-404b-933c-f9fc3a54aa70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "56128569-89ab-464f-a3cb-7b16da921779");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ad7cec8-74e4-4e07-ade3-852bb65f9e55", "AQAAAAEAACcQAAAAEKOiUy1SojxbhCBZ8ZOtWR7y833KmwFGhAxjkhIl9V3SQunkDpQ4b+kWw71DhdlBlA==", "fc50e409-dbc6-4ca1-b90f-edd640c15b4f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ClientId", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsRemovable", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SupplierId", "TransporterId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e08d7ef7-2615-4385-844f-81834bb6e776", 0, null, "49c4fc75-360f-4f2f-9ac9-43dfc7452571", "client@mtc.com", true, false, false, null, "CLIENT@MTC.COM", "CLIENT@MTC.COM", "AQAAAAEAACcQAAAAENXOuK116A46S8/UIIVowygiDM6uMWkpjxSsbGKAwakIQpjEq45mnXl/O71L1uH+yA==", null, false, "091398bf-4bb6-47df-b6ba-20b99af46101", null, null, false, "client@mtc.com" },
                    { "c6bbcf91-ab26-4bf1-a8ac-6251444d1464", 0, null, "bdb38957-21a9-4e1e-9264-c8e69695171f", "UserAdmin@mtc.com", true, false, false, null, "USERADMIN@MTC.COM", "USERADMIN@MTC.COM", "AQAAAAEAACcQAAAAEPufULJK6fncP9vJtjZ+XL5ji6Q9qv2Ch9aLLBrbjdKvg/3rUV2AhFn3G8vlJJHolQ==", null, false, "3e4218a1-9323-4e10-9a41-2ba9a6e3cfdd", null, null, false, "UserAdmin@mtc.com" },
                    { "3ba08e02-85b4-4488-8108-e526aa987eed", 0, null, "fd0fbca6-12e0-48b5-bbef-da2344083f04", "moderator@mtc.com", true, false, false, null, "MODERATOR@MTC.COM", "MODERATOR@MTC.COM", "AQAAAAEAACcQAAAAECv/zeVPnvBQS1uTVMPZgMktF0pY8DJv0d33qNLLnqvIkcjIUMTW5C7hCsBCvdH61g==", null, false, "86bca75f-7237-42a2-beea-cf4045f81b8c", null, null, false, "moderator@mtc.com" },
                    { "f0cd17fb-639c-4bd4-aa51-cb64259d9743", 0, null, "9b95fc40-d8b3-4f87-b10c-52aab72ccaf9", "supplier@mtc.com", true, false, false, null, "SUPPLIER@MTC.COM", "SUPPLIER@MTC.COM", "AQAAAAEAACcQAAAAEAOuj/l1w/kAfKIU+3nsm9DGA2Lc2MKSxZn5/3uGT7rDBWGgIOuBzEG1RO0urDnQiA==", null, false, "e13473cd-ad2b-4333-979a-d1661d7181c1", null, null, false, "supplier@mtc.com" },
                    { "a0392e57-a71c-4314-b87c-ba8dc7628fcc", 0, null, "d7e911d4-fdae-4e79-b4fe-6b162f4713ea", "transporter@mtc.com", true, false, false, null, "TRANSPORTER@MTC.COM", "TRANSPORTER@MTC.COM", "AQAAAAEAACcQAAAAEKQtfw3a7l6HHTV2yPjtQHKWXWiFe9wNtZkyHzSWZ7d1IxNRs43KiSet0zAhlcpL3g==", null, false, "866b4cae-a80f-4740-a889-cea3027eecce", null, null, false, "transporter@mtc.com" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DiscountPercentage", "IsActive" },
                values: new object[,]
                {
                    { "e08d7ef7-2615-4385-844f-81834bb6e776", 0.0, true },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0.0, true }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BTW", "CompanyNummer", "IsActive", "Name", "WebSite" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "BE0123456789", "0123456789", true, "MTCSuperUserSupplier", "www.MTCtestsupplier.be" },
                    { "f0cd17fb-639c-4bd4-aa51-cb64259d9743", "22222222222222", "22222222222", true, "TestSupplier", "www.MTCtestsupplier.be" }
                });

            migrationBuilder.InsertData(
                table: "Transporters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "MTCSuperUserTransporter" },
                    { "a0392e57-a71c-4314-b87c-ba8dc7628fcc", "TestTransporter" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "e08d7ef7-2615-4385-844f-81834bb6e776" },
                    { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "a0392e57-a71c-4314-b87c-ba8dc7628fcc" },
                    { "277f86fd-db6a-449a-a7de-25917a177a61", "f0cd17fb-639c-4bd4-aa51-cb64259d9743" },
                    { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "3ba08e02-85b4-4488-8108-e526aa987eed" },
                    { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "c6bbcf91-ab26-4bf1-a8ac-6251444d1464" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ee9e763-1f51-4d0d-a463-b7a8a791234b", "3ba08e02-85b4-4488-8108-e526aa987eed" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1dde702e-2587-41bd-bec5-0f4cc5d05498", "a0392e57-a71c-4314-b87c-ba8dc7628fcc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6aaef1a-8312-4185-8b51-1e3a09421ff7", "c6bbcf91-ab26-4bf1-a8ac-6251444d1464" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7e19e371-55db-4c16-b9c0-4103de5b39fd", "e08d7ef7-2615-4385-844f-81834bb6e776" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "277f86fd-db6a-449a-a7de-25917a177a61", "f0cd17fb-639c-4bd4-aa51-cb64259d9743" });

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743");

            migrationBuilder.DeleteData(
                table: "Transporters",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "Transporters",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ba08e02-85b4-4488-8108-e526aa987eed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743");

            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "52437f6a-82e3-4582-9b31-7547ff7e175b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "9ec5b9f9-a95c-4297-8b53-8d56961b7605");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "cb80d1f4-b62b-405f-938c-64f7b1bcb233");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee9e763-1f51-4d0d-a463-b7a8a791234b",
                column: "ConcurrencyStamp",
                value: "c18ea18f-3fab-465b-8923-8040bb4b5c4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "98750fc7-6c44-4a5b-a732-88f5740fa2e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "fb1c7bd9-a508-4ff3-b27a-3412cff4bfb3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "331260cc-dacd-4675-8346-078e583e5f9e", "AQAAAAEAACcQAAAAEJTK4DAwyx1Y3503geIQOKJi186OwIDCCnp1eY7nszBNc0H69tl4lgNZJyJl7OCUUg==", "c9a1028a-a8c8-428e-a2d1-53face8389a2" });
        }
    }
}
