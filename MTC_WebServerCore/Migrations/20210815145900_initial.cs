using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "27e900a5-2120-40f7-bf10-90865caa386a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "2d89a893-9750-43cf-938a-0ac7337f52f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f14fc6ed-cd62-43d1-8ee4-db957c025a39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee9e763-1f51-4d0d-a463-b7a8a791234b",
                column: "ConcurrencyStamp",
                value: "efadaac0-57f1-413f-9117-f8541793f70c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "f401e76d-3f4d-43b4-879f-53135c5a1575");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "048edf52-4e2a-4a37-8f31-26697024020e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ba08e02-85b4-4488-8108-e526aa987eed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d1ef630-6044-4eb9-98fc-67a2ae1b8a25", "AQAAAAEAACcQAAAAELlz+u3kFS8de+uj1qEGW/9hzLpjORtr0QrW/aJbcGqVtvzRtHLGJPaqbJYPiRVMpw==", "5a42ab2d-7d96-4f8b-9dcd-092e4e7c98bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9b55ba5-634b-456b-8e40-bd41e400638d", "AQAAAAEAACcQAAAAEF6bRgsmGRl0PDxvKseOI6DYCpQo3u2ANhO/PQW9np68DBx+Y3Uq30nN8CUFbAARzQ==", "4dfd6198-549c-49ee-a67f-132b078655ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bd7373f-bdfe-4922-b2fc-ed9d231e8cb5", "AQAAAAEAACcQAAAAENAo62lP457TFzbwnTanFa3DTsuhQ/+tQn7VI6CCp+aWJ0bKdqXTgUT74jHsRraqfw==", "bb092123-3f05-4be3-9076-a8d02f2216cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1218ca8-1a24-43e4-8046-0db4ca45e520", "AQAAAAEAACcQAAAAEI0Zi6EsdzKZFR3ILH4fyrrMzAFx/NMvurQ+Rh5ws5Riex7sn6hY3WwOXeRxK4HLaA==", "ea63c235-5505-4dce-a589-fde4082bd830" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36462e34-ab6b-435a-ad60-503e38e9ad94", "AQAAAAEAACcQAAAAEERA3gJMRgqiefLhB1OR0sgkRoJ/xi1lvovvLDuT+4F4P71yUwG6I51Ums+y+mYgMQ==", "cd5587ba-a840-4783-9975-32d7ec923054" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9b03f0a-bb31-454b-adba-201ac682b751", "AQAAAAEAACcQAAAAEKKSnSPmFX00oKKwe3dJ+b3MSR2jrr0nlr1S5VUZBubgFV9mOeqFynec6UYH0ain4A==", "f1674fdc-df36-4cd7-858f-09dd9a0e7fbd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ProductImages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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
        }
    }
}
