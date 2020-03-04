using Microsoft.EntityFrameworkCore.Migrations;

namespace NHSDP_SPA.Auth.Migrations
{
    public partial class remove_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f4f296-d6db-4d19-bc15-9cff9c4440a1");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1afcf615-3495-41b7-8f67-52a91860179d", "f010a467-f85c-4685-b89f-06626ffab8d1", "consumer", "CONSUMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1afcf615-3495-41b7-8f67-52a91860179d");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8f4f296-d6db-4d19-bc15-9cff9c4440a1", "69f25603-d6ac-443d-a883-2b45cf397ac3", "consumer", "CONSUMER" });
        }
    }
}
