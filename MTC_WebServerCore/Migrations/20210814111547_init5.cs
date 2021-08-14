using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "Suppliers",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAdditional",
                table: "Clients",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "815ce370-f34a-4964-b2cd-fd363e043e0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "13097799-e423-49db-8783-7b2647433420");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "287760e7-9ba5-4ab8-8bb5-6f96a4aaab6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee9e763-1f51-4d0d-a463-b7a8a791234b",
                column: "ConcurrencyStamp",
                value: "dacf02e6-4742-4713-bd3b-b2782a89c67b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "69edcdbb-8372-4419-9746-b5a1c18d9fb6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "0055d50f-284b-4fce-b392-583fa7be1e07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ba08e02-85b4-4488-8108-e526aa987eed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec4c9004-94e7-400e-a157-84e659d964c0", "AQAAAAEAACcQAAAAEAZdntn3MDElXi0Hkx/FYJlXs3u8L4v7QSl5RcRadCjnAjDF3Ph7et5X/xSDLYAyOA==", "83f339c2-261d-441d-9eaa-8b888a3c2da5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d15d3d84-14e6-4190-a1c7-8daa837a094e", "AQAAAAEAACcQAAAAEKnB0QHNHm2+9ElSoRKrL2LkliPaBx7Q7/M9nXeLU8odjvLNEeIQh7Kl+1EtlQXKkg==", "69a5b282-b58d-42f5-8606-f91e40afe8cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d73cc22-2c4a-4ba3-bdd6-b4efb268b8e5", "AQAAAAEAACcQAAAAECoXoq8YEP2K9gC/w63Dk5yoBlWCUnckiDNv3/9xvq9xqYJKusah4Ywj8/X+CCxFmw==", "e87fac85-6e51-45b7-a2b5-3e347ac2a115" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d7409a3-0a32-49d1-a754-2a918ed33182", "AQAAAAEAACcQAAAAEKY4Ygcq7Bhod3ZfZiOCzx8aucWbLu+SQ5vA7sGnWdNRn80TR+dCYu1KQxgEEJKfmQ==", "a34370ba-4df1-45d7-ae32-169c8a29b21f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "427059aa-aca9-4439-856e-cdeb4724358f", "AQAAAAEAACcQAAAAEMTWtJMlQDxxLWbgII/Sd2M1C8vYUsEpviLIDzMwvB46KCH62yZkOQ1EVWWWabkljQ==", "24002f1b-329d-4f3e-8d27-0a061603218b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4b76ed7-d4d9-4925-9b5c-a1dfb647df03", "AQAAAAEAACcQAAAAEHoWyVhdQZJDuNGdjq1Wyk5u6FxT5cc2Le6/VG3G6/xyjoHqERfguNc9twqRy7q6lg==", "5345283a-97b7-48c5-9bd3-b1f09f824071" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Super", "User" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "FirstName", "LastName", "NameAdditional" },
                values: new object[] { "testClientvoornaam", "testclientAchternaam", "tst" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "NameAdditional",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "Suppliers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
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
                keyValue: "3ba08e02-85b4-4488-8108-e526aa987eed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd0fbca6-12e0-48b5-bbef-da2344083f04", "AQAAAAEAACcQAAAAECv/zeVPnvBQS1uTVMPZgMktF0pY8DJv0d33qNLLnqvIkcjIUMTW5C7hCsBCvdH61g==", "86bca75f-7237-42a2-beea-cf4045f81b8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ad7cec8-74e4-4e07-ade3-852bb65f9e55", "AQAAAAEAACcQAAAAEKOiUy1SojxbhCBZ8ZOtWR7y833KmwFGhAxjkhIl9V3SQunkDpQ4b+kWw71DhdlBlA==", "fc50e409-dbc6-4ca1-b90f-edd640c15b4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7e911d4-fdae-4e79-b4fe-6b162f4713ea", "AQAAAAEAACcQAAAAEKQtfw3a7l6HHTV2yPjtQHKWXWiFe9wNtZkyHzSWZ7d1IxNRs43KiSet0zAhlcpL3g==", "866b4cae-a80f-4740-a889-cea3027eecce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdb38957-21a9-4e1e-9264-c8e69695171f", "AQAAAAEAACcQAAAAEPufULJK6fncP9vJtjZ+XL5ji6Q9qv2Ch9aLLBrbjdKvg/3rUV2AhFn3G8vlJJHolQ==", "3e4218a1-9323-4e10-9a41-2ba9a6e3cfdd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49c4fc75-360f-4f2f-9ac9-43dfc7452571", "AQAAAAEAACcQAAAAENXOuK116A46S8/UIIVowygiDM6uMWkpjxSsbGKAwakIQpjEq45mnXl/O71L1uH+yA==", "091398bf-4bb6-47df-b6ba-20b99af46101" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b95fc40-d8b3-4f87-b10c-52aab72ccaf9", "AQAAAAEAACcQAAAAEAOuj/l1w/kAfKIU+3nsm9DGA2Lc2MKSxZn5/3uGT7rDBWGgIOuBzEG1RO0urDnQiA==", "e13473cd-ad2b-4333-979a-d1661d7181c1" });
        }
    }
}
