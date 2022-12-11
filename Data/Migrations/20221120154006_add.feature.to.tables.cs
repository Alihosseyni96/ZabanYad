using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addfeaturetotables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverGroup",
                table: "AdminMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverGroup",
                table: "AdminMessages");
        }
    }
}
