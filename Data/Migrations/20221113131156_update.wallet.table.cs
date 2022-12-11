using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updatewallettable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionNumber",
                table: "Wallets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionNumber",
                table: "Wallets");
        }
    }
}
