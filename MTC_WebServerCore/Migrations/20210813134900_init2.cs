using Microsoft.EntityFrameworkCore.Migrations;

namespace MTC_WebServerCore.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fda5ee32-4560-45a6-8e23-204cfdc85672", "AQAAAAEAACcQAAAAEGALjQkwRg//z58ffk2pLsykbk534/m3uWenXtfhRSIIFPVtixeI9dEaEbxkjNtMDA==", "cbdae444-c6b6-424f-bed3-e7cd57a6b430" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4516cc41-90e9-4ac9-9975-4d8c7ae06845", "AQAAAAEAACcQAAAAEABaQ1Iy/sRocSPwcvv6Nx4vNoJmtJABn4UHsxeqE9bNKzbWTPpF5Wwu8PDnavkt4g==", "5a430e38-c37f-4d16-ab3d-9b5ef08c7bca" });
        }
    }
}
