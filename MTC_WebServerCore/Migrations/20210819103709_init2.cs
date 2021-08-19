using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransporterId",
                table: "OrderLineOUTs",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "b696f6d7-7ffd-4f5c-99b7-ebd0dc8b0d40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "21be6d47-3db1-43b5-bfdd-6031bc9d4e74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2ee8a2bf-3d1a-4d4a-b115-8294ff3aa957");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "b40eefcb-c345-428e-96fb-f3d582918224");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "71cedaf8-8cdc-4c9e-9381-46a343ecd95f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f74e31a3-3261-416e-9d34-05d8a4362805", "AQAAAAEAACcQAAAAEFrPjF8y6/qnxKA16b3kZbtsIE9H4P/sV7wK+A1346Ah7A9Nb1/h6D7F1cy/LjdX6g==", "4f213035-7447-4abc-bd42-d9d6023d8a6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64183e83-9847-443b-ade1-7d8b91882d49", "AQAAAAEAACcQAAAAEFmB7vzmAksYQUHt+YoTTIYHxjjRoGPAFUmwRBMIwahRe32/bzRApDsVMNtSB58eiQ==", "249ce9fb-4a1c-4217-bdd2-149eb2cab416" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82a90eeb-f068-411d-aacd-5dce748df05b", "AQAAAAEAACcQAAAAEKphNH2EKk952A9cId8jUzIIw3aWWtSMEs/ZBE8pZAaMuRb/DSHHu/KpOMFgspzgMw==", "d97780a5-a021-4d54-9a37-71a336e287d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4737b3e0-79a2-4183-b523-171d73a3057d", "AQAAAAEAACcQAAAAELUC2a7379cvUodD5wIVhisbLx1Ck+sjtyFS6FKUqMOtRHifqAYBdlK/KXnCukiRdg==", "559c3cd4-727b-4f40-8ca6-65042e3d09cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0f9819a-d2e2-4b09-b72e-386ddb13b49b", "AQAAAAEAACcQAAAAEPuejNx3Ckls6gbJOurU7tssszdtPDP+tH32yrvxbvOuU3mZ+Pkj4GuQe4PBTgkLXA==", "5ed2af6d-80e4-4556-beb7-4239cd7c932f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransporterId",
                table: "OrderLineOUTs",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "fdc3760e-eab3-4825-8dbd-01dc403fdcd1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "ca01224a-283c-4048-b1f9-e3d6e27cd3e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "79438ccc-b82d-4712-9448-4bed72d0e1ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "884035dc-23d6-4870-8cff-fb185fe6ef12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "ce6f90a3-eb6d-4fe6-885a-641e2be3a398");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb3cd166-6f24-4071-8954-682ef98b2066", "AQAAAAEAACcQAAAAEMHMkHnLvavXi/fIfe4ciSXJ8Yj0TKP/HdOYa0Zrj/5OSdkbW91WjPP5N303DiCFpg==", "d1da164e-8a0d-433d-91d6-f097690fcde1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d0c8408-4320-4f6f-9c59-45380c6d2fa7", "AQAAAAEAACcQAAAAEOb/8QhMBueLQRXy1QG1mEwBPPbUeDX0Rfub2YKmSMOC9w4GpBDO1/YIZdnOpQDmPg==", "c3cf937c-c6ea-49fc-a7ae-3e25656af579" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "475ee17e-4fd2-4f66-a7fa-972723bafd62", "AQAAAAEAACcQAAAAEIEeZXew7++zlADFQSZEd6z0ed39H9u5u8jwJ0Q8QSuVDlB58XBRxS/kafF92Fowpg==", "577f2c5f-5d8b-44eb-93c8-b6d7e28a5e1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f853e240-d182-454f-9751-4f217b9a8ef1", "AQAAAAEAACcQAAAAELhOQ0Jko7SyTnTPRxqC4y8V8KtHUn5Jh8hEg9wXYCZNzdhg+7w3PxpuQWYcj6tkyA==", "baaa9dcf-26fd-4d62-9bfb-81a5bb4703b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9a17586-dd2e-42a9-9fca-c320c1a2a6a4", "AQAAAAEAACcQAAAAENhZE4dQ151J5QVShmiFbyokd8EA1ls9nR5IR5K8OObM4nsXm0bNyAvCwJzdPkWYlQ==", "fb0a0f40-16d1-40ee-94a3-41e3288096b0" });
        }
    }
}
