using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class chatBijgewerkt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CliendId",
                table: "ChatMessages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "363df989-9d68-496e-8d66-894e2e1f3e9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "7c13ffd4-31e3-4fa8-93d6-5a6d6f79fc07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e65639c4-53f7-49f8-9767-cf699017cd65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "fb6b1714-f05a-4a0c-bd30-5951b979ac71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "1c3f7cf0-a2f0-4af3-8015-873db07764ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7afe28ce-0b29-46e7-afe8-396e29fccf6b", "AQAAAAEAACcQAAAAEExvZ4v52kVp0vYHVePhQcORCHgej4eWL8eD0NUB/9N7Wy/EyKX0fz3U36UaJhRaMQ==", "f66f50f7-ea7e-420a-bc40-98e75a372943" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ac4de13-2f58-430d-a667-5bc39d3e9241", "AQAAAAEAACcQAAAAEE98qq/2ZUK7dF9A7ikI4s72iZVDi9FRIW08CaHiPE6ibx6521xAn1BLyvEtfM07jQ==", "8c583def-b8de-42f3-9eb6-720d77c8af58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2148b80b-0ae3-4e0c-9dc6-5b3fc92d35f8", "AQAAAAEAACcQAAAAEPW+XJWMx1XkfdofiPqqVndq4zJcPreCbsb+QvwSexCOSkpsmHX/bjP6cN3AHgbzww==", "58f87615-0bf8-421e-9bc7-b62f16acacff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6173fad-abe7-4f2f-9a31-2608e783f9fe", "AQAAAAEAACcQAAAAEEiJKQqawDQHur681AiavPnYiszCni5dpFo/cMrfPJZSXfzzn7XwAcOIFPnK+KTy2Q==", "f2b2a685-9ef3-4a8d-acde-6f61565a8138" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff3e0042-09a8-41ab-aa73-9c299d34f52e", "AQAAAAEAACcQAAAAECz5xLGkhdA/dBjCpF4YRh/i8ZbRZ2p4C3RMCT9g4yDpSteJ3sFiMG7qkfwloHcG0A==", "d323b88e-ed0f-4def-8161-9f8ee351abc1" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Clients_CliendId",
                table: "ChatMessages",
                column: "CliendId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Clients_CliendId",
                table: "ChatMessages");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_CliendId",
                table: "ChatMessages",
                column: "CliendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
