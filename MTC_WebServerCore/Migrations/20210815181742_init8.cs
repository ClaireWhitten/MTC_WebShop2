using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Suppliers_SupplierId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Transporters_TransporterId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SupplierId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TransporterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TransporterId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transporters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Suppliers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "493a5fc0-2f8e-410e-8124-28341e6ceacd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "d6d8c50d-d85e-4c7a-94ee-de47501ddc03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a436037f-9936-4253-bd34-66831d720d4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "06cd3ca2-8ac5-4b02-9642-f9154e6e0c32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "3f9c1f5f-568d-4b73-89b5-042ba75f0113");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0f3a164-ce36-490a-bb18-4cfa79339a80", "AQAAAAEAACcQAAAAEFbaPMcdPN+aZ6Cihk2SOS1LWs6RFuyq70f4pxm+22O9+wBtbQF6i/LgosVSd43yTw==", "9292fb52-30aa-4034-936c-6ca85e98d4d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "726dd4e6-95c6-455b-9663-1e073a9f8cae", "AQAAAAEAACcQAAAAEAF1RZcv2FP3Nwlt1SAfSyECp5Qgzgne1oiwBMVXLCH9IDkdbabF7HAq8tw9Q6sh6Q==", "51ca1d1f-0a53-4425-8b96-69fda5df6ee8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ce9bcbc-b3bd-4143-9c14-baa15b826a45", "AQAAAAEAACcQAAAAEH3iHCTtd01d8LODhzAqKF6J/8y9CH1IOe2ZwUHlJXTNarejCJetXmTRimhJX0HSzw==", "5352b109-2f5a-4737-aade-7dbbaa027550" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ad22e39-cb3e-45f7-9c95-fc7cdebcdaeb", "AQAAAAEAACcQAAAAEPcb/MFJ51bvklSy2i70Tk5GMF8gEOMEGTQNP6NHLsc7CQKQjvW0ZbNv1qKAebZTcw==", "914d210c-a925-4758-b349-8fc4c55b2e99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37cce980-721d-4157-8772-25745e778809", "AQAAAAEAACcQAAAAEN0D+w4EdA2ssiBJUDecswAMx42De1n9CKJKai/bIoDH1lY1iRHMH5rbZBCzH2s83w==", "5eaa06da-5886-47ff-ba21-572e157e1b4a" });

            migrationBuilder.CreateIndex(
                name: "IX_Transporters_UserId",
                table: "Transporters",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_UserId",
                table: "Suppliers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transporters_AspNetUsers_UserId",
                table: "Transporters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_UserId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transporters_AspNetUsers_UserId",
                table: "Transporters");

            migrationBuilder.DropIndex(
                name: "IX_Transporters_UserId",
                table: "Transporters");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transporters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransporterId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

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
                column: "ConcurrencyStamp",
                value: "5d24a001-91c4-434e-b14f-7263ca2bf39c");

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SupplierId",
                table: "AspNetUsers",
                column: "SupplierId",
                unique: true,
                filter: "[SupplierId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TransporterId",
                table: "AspNetUsers",
                column: "TransporterId",
                unique: true,
                filter: "[TransporterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clients_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Suppliers_SupplierId",
                table: "AspNetUsers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Transporters_TransporterId",
                table: "AspNetUsers",
                column: "TransporterId",
                principalTable: "Transporters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
