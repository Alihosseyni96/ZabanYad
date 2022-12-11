using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class newfeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CourseGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CourseGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
