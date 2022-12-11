using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addAdminMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminMessageId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminMessages",
                columns: table => new
                {
                    AdminMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecieversGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMessages", x => x.AdminMessageId);
                    table.ForeignKey(
                        name: "FK_AdminMessages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AdminMessageId",
                table: "Messages",
                column: "AdminMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMessages_SenderId",
                table: "AdminMessages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AdminMessages_AdminMessageId",
                table: "Messages",
                column: "AdminMessageId",
                principalTable: "AdminMessages",
                principalColumn: "AdminMessageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AdminMessages_AdminMessageId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "AdminMessages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AdminMessageId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AdminMessageId",
                table: "Messages");
        }
    }
}
