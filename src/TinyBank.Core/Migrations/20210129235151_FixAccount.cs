using Microsoft.EntityFrameworkCore.Migrations;

namespace TinyBank.Core.Migrations
{
    public partial class FixAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_AccNumber",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccNumber",
                table: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountId",
                table: "Account",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_AccountId",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "AccNumber",
                table: "Account",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccNumber",
                table: "Account",
                column: "AccNumber",
                unique: true,
                filter: "[AccNumber] IS NOT NULL");
        }
    }
}
