using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                keyValue: "6ee9e763-1f51-4d0d-a463-b7a8a791234b",
                column: "ConcurrencyStamp",
                value: "38742ca1-3f0b-45e8-86ce-6db68c7549ea");

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
                column: "ConcurrencyStamp",
                value: "51028b7a-f4d6-4f07-a7ef-11b041e9efc6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ba08e02-85b4-4488-8108-e526aa987eed",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff1bf7ca-5130-475d-82b8-6864a28c5fde", true, "AQAAAAEAACcQAAAAEHOSah1etE/d7+y/qFEKhdzxGLRDev8Gfak5DwFeerlaop/HzobBJ7lkOefiGjSQsw==", "6b0c9bc5-eda5-442a-983b-671ec88a3c20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f76dfa9-f229-475f-83db-c85c7fccef23", true, "AQAAAAEAACcQAAAAENsAnpOCMlMKpCX/f/KZxzCMxc7tzqVPVzoc4Sl0eNIVE3ngJ6/f16kIedLgOK8omw==", "1b5b6f50-ea82-4231-8707-05b5fa0ebebc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d332e37c-8cb8-4e04-94f9-c9935be15b3a", true, "AQAAAAEAACcQAAAAEAJBwlmybe72jqZSzzNhYamIIQ6QdtE5LO/Vai4kVuThtf+KOXRdh2SMsjaJthlS4Q==", "0e7b8d86-4b42-4629-94c5-5d8fb0d0a6bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa0a1148-aa70-4e8e-a1d7-ca4c8ca9bdec", true, "AQAAAAEAACcQAAAAEIOSe199penX9iEzffrbK4/a8rAWOyb3LnMkQ9/5qEQZgWrJGz86IIfU5sNmy/2CVQ==", "5d0f5477-24e8-446b-ae3c-f8943755c9f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3249898e-cf08-473e-a2fd-6cd6fcf0dafe", true, "AQAAAAEAACcQAAAAEOFMYMdw0yjqhmFYyqgXGbgZ+yBXPHk283nPO6ZOG4XOM7gxEAZvB1OHy6Hc+Xxvxg==", "b9e747b1-2127-4001-af9d-0e640f374f78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "272f6415-b209-4774-b447-13fbbbc13884", true, "AQAAAAEAACcQAAAAEJi8aR8KrHHd6vIR8cJt9WoEWniWS3viwsGlLm+xa9mpL0lClAVmovKEKCEHEjdzEg==", "a2175e9d-b6fe-476c-a512-93fe6bcefaa2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                column: "IsActive",
                value: true);
        }
    }
}
