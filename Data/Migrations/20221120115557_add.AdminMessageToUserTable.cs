using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addAdminMessageToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMessages",
                columns: table => new
                {
                    AdminMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AdminMessateToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminMessageId = table.Column<int>(type: "int", nullable: false),
                    RecieverId = table.Column<int>(type: "int", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMessateToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminMessateToUsers_AdminMessages_AdminMessageId",
                        column: x => x.AdminMessageId,
                        principalTable: "AdminMessages",
                        principalColumn: "AdminMessageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdminMessateToUsers_Users_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminMessages_SenderId",
                table: "AdminMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMessateToUsers_AdminMessageId",
                table: "AdminMessateToUsers",
                column: "AdminMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMessateToUsers_RecieverId",
                table: "AdminMessateToUsers",
                column: "RecieverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMessateToUsers");

            migrationBuilder.DropTable(
                name: "AdminMessages");
        }
    }
}
