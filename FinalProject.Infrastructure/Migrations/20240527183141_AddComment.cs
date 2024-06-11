using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    public partial class AddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "e93324b3-ed53-4a9d-8498-fd60de07df37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "97fca1a8-7efe-4663-81f5-8f99c5674e5d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efc18f17-1888-4f14-ae60-066d9ba1f528", "AQAAAAEAACcQAAAAEH6IDPiV8dqclS4GRnVzXFV+fsaSJOvJv7O2jL78yg1UUvm5HUfmvPwF18mml6qecw==", "723e079a-ea4c-4a62-8d37-5a9ad1d8d24f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb1d1e73-363f-4a56-8b08-06d11a68892c", "AQAAAAEAACcQAAAAEDapvP4BERFwPzS3g55CP0xfo+kxlcdn1GLNF3vKrzRPJrlLdnhrdnHPIEL8Tdb17Q==", "f0effa62-98e9-4df6-8ea6-daaed9ce82e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "ad7752cf-8875-4531-85d0-72b6e89a73f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "5fced825-837b-434a-8a62-c6a40ec372f8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c8390b2-c969-4707-a8ca-aa4780c5d8e8", "AQAAAAEAACcQAAAAEIiEXgeFjt9RR2jFERF/mZvPgQ0gEXAJwNgCqdZmKH/jkSag4sZ46IbLWn5QYdEt4g==", "ca62af09-604c-4272-9eb1-48d40d474455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48320b47-0fba-4c0a-beb1-9cbad3b9cd8b", "AQAAAAEAACcQAAAAEFPdlARTWg8k9qjuXOgCy7ANfhbyyCduE3Xbz1EqXA1b3UHSGY47KXhsgddi/vIf5g==", "48ab2de6-b72d-4cab-922d-3fe974b220d8" });
        }
    }
}
