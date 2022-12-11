using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainGroupId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SubGroupId",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainGroupId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubGroupId",
                table: "Courses",
                type: "int",
                nullable: true);
        }
    }
}
