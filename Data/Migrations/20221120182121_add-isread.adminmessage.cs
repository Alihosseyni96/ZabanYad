using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addisreadadminmessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "AdminMessageToUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "AdminMessageToUsers");
        }
    }
}
