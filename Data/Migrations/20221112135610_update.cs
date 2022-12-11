using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletToTypes_WalletToTypeTypeId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_WalletToTypeTypeId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "WalletToTypeTypeId",
                table: "Wallets");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_TypeId",
                table: "Wallets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletToTypes_TypeId",
                table: "Wallets",
                column: "TypeId",
                principalTable: "WalletToTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletToTypes_TypeId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_TypeId",
                table: "Wallets");

            migrationBuilder.AddColumn<int>(
                name: "WalletToTypeTypeId",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletToTypeTypeId",
                table: "Wallets",
                column: "WalletToTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletToTypes_WalletToTypeTypeId",
                table: "Wallets",
                column: "WalletToTypeTypeId",
                principalTable: "WalletToTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
