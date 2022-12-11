using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageToTypes_TypeId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "MessageToTypes");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TypeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "WalletToTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletToTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletToTypeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wallets_WalletToTypes_WalletToTypeTypeId",
                        column: x => x.WalletToTypeTypeId,
                        principalTable: "WalletToTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletToTypeTypeId",
                table: "Wallets",
                column: "WalletToTypeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "WalletToTypes");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Messages",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MessageToTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Typetitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageToTypes", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TypeId",
                table: "Messages",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageToTypes_TypeId",
                table: "Messages",
                column: "TypeId",
                principalTable: "MessageToTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
