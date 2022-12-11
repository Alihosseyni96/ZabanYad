using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class newtabledirectBuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectBuys",
                columns: table => new
                {
                    DirectBuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectBuys", x => x.DirectBuyId);
                    table.ForeignKey(
                        name: "FK_DirectBuys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectBuys_UserId",
                table: "DirectBuys",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectBuys");
        }
    }
}
