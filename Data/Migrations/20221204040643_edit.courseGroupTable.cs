using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editcourseGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainGroupImage",
                table: "CourseGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainGroupImage",
                table: "CourseGroups");
        }
    }
}
