using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Infrastructure.Migrations
{
    public partial class AddJiraAccountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JiraAccountId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "855ebc6c-926f-4624-a4aa-8f1a7ed8ad86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "b46212ed-1566-42e7-9c6c-d2a77ebed355");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eca78e87-a7ba-4c81-b0c1-0dd98ec7a291", "AQAAAAEAACcQAAAAEJRVH1UwHLDN2Bpk0QWHRwsTVg6WnC/knsEbpjdI105GEfdXTG8YdhKVtoUNUR187g==", "9a8ea5d5-6869-4a7e-bb18-3677d0a43292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7dac184-2ae1-42b0-beda-ff9b91f24ded", "AQAAAAEAACcQAAAAEMzsV9pVU9mXVLp9wDY4rG53YYYE7zLAqtCfWxGlZfiK87oNduXK+j8wAqgeiq2B2Q==", "dcd9c4d1-eba2-4dbd-ba7f-1bdfe2eab41d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JiraAccountId",
                table: "AspNetUsers");

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
    }
}
