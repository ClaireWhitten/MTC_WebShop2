using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dde702e-2587-41bd-bec5-0f4cc5d05498",
                column: "ConcurrencyStamp",
                value: "12439f06-84d7-4dad-9ab1-ebbceff7bd20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "277f86fd-db6a-449a-a7de-25917a177a61",
                column: "ConcurrencyStamp",
                value: "bb5b7d36-1da3-44f1-99f6-a0f06d344d43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5a127efe-f361-4a3a-909b-3d89feb276be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e19e371-55db-4c16-b9c0-4103de5b39fd",
                column: "ConcurrencyStamp",
                value: "a26e6c8e-bb19-44a1-83f2-0291e28e788d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aaef1a-8312-4185-8b51-1e3a09421ff7",
                column: "ConcurrencyStamp",
                value: "335b740f-bd04-4a0f-8e51-97784018ff0d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70b60a32-b0bc-4ca6-ac30-f678dc5126e5", "AQAAAAEAACcQAAAAEJ6eH/5Ab4FmVczn83Ejj1X2fU/lBzfNPlrXYccumk/QzPD8C1Gyr9bHHqTq0/3vHg==", "204485ab-63a9-4f09-b39d-bb2691cfc4d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0392e57-a71c-4314-b87c-ba8dc7628fcc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "457fbb1c-d52d-4992-b1cb-e168ed17f9f3", "AQAAAAEAACcQAAAAEFmSFTON8YTq76IsWx+sc/o2lV0JPNrdswy0rSf0GpoywUv3/dlqCcv2ijDq1XEDUw==", "b240da1d-b9c6-41df-8f65-b5815c80b739" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6bbcf91-ab26-4bf1-a8ac-6251444d1464",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfe428a7-65e1-4a55-8c34-013b03daecba", "AQAAAAEAACcQAAAAEMLU104ocoxmxKPdq+hXUzy1hyoAuzCeG8Cd/0iWpo9dApPL5MFYcn8nYV537JAEOQ==", "00aaaec4-b5d2-4834-b907-b8adf3a572ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e08d7ef7-2615-4385-844f-81834bb6e776",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dcd252d-4bcd-4ad4-bc1b-b6620a9fb10c", "AQAAAAEAACcQAAAAEBBi96od04XGKACIytVgeSO7jsvXNTWuj3qyTdnl/LQeMlliNw4ey4LkfAaT7vTFSA==", "85adb137-961e-4963-8875-b097a7ea3fb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0cd17fb-639c-4bd4-aa51-cb64259d9743",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb589ec-1e50-4fcb-8887-44b797c50ac9", "AQAAAAEAACcQAAAAEILsGOIpx9i1wkk40OLO2bBkm89tPIj5mNE2p86VXBax/2+iDO7dSe4DspmLR+rOlg==", "d046038a-0533-4cf3-bf17-4ac5c8612513" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_Id",
                table: "Clients",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_Id",
                table: "Suppliers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transporters_AspNetUsers_Id",
                table: "Transporters",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_Id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_Id",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transporters_AspNetUsers_Id",
                table: "Transporters");

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
    }
}
