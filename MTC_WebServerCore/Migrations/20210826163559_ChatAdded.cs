using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class ChatAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsernameSender = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserNameReceiver = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false),
                    IsFromAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CliendId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_CliendId",
                        column: x => x.CliendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "23c24051-706a-4b6b-9be4-fae4e57aab8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "d2de1625-6497-4962-b871-952102753ed1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "10983d3e-c31b-436e-a5b8-fe986cd01c28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "30d1705f-73d6-42d2-8c48-389054608c1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "1e44b6c8-f322-4383-8a68-70d1a08f469f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "578830a8-8631-4c29-bee5-59d4621abe22", "AQAAAAEAACcQAAAAEOJLR4YJrFBzc/azaZxt4m6bqCdRMDBLHvdsavTmfVpZoJ+8rnnzAEkl2NbVWg/9ag==", "ea961093-3776-4d03-9e33-c24ab5df68c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "328064e6-b2cc-4c86-b6a5-ed55a4a7395d", "AQAAAAEAACcQAAAAEBwNuBC2S69BfPlGCUfUcCwnjKwmxgVAxGiX4dYF/qw9MyJEUf1TmejCfNS6jGO2UA==", "79fcf0b7-da93-4304-ba3a-f3c501305448" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2aef698d-ce12-4de8-998e-725f247b2d2d", "AQAAAAEAACcQAAAAENnNBz8lqTZbAyyzjPOx+sUQw0f0aS/UsLY1YDNY+5PpJAV8BDhmx+QzZ6CGy6vpeA==", "75d2641c-127a-44b9-bf81-16f4c858a825" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4a15fe1-6074-42ab-a753-b5fd39f85b31", "AQAAAAEAACcQAAAAEDKA1xhLc0WgZyatmKDiMG2OqT36RslzrqSQGGYlwAK0kMAIGznX3kfPgCCtaFy7SQ==", "5e9ec6b7-9cff-44ae-bc3a-80b3ad786050" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e5b01fc-dcde-483d-adbb-060b9058e738", "AQAAAAEAACcQAAAAEIMRTj7hRp4qSo6Y/9wWg28rViL4LGBmWB9tCWmtHRJgB85sZ5xy7LeLG8HlFnlZLw==", "0e45f54f-96dd-4853-8399-d037fa506f29" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_CliendId",
                table: "ChatMessages",
                column: "CliendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

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
    }
}
