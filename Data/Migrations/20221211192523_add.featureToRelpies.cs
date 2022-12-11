using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addfeatureToRelpies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnswer",
                table: "ReplyComments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswer",
                table: "ReplyComments");
        }
    }
}
