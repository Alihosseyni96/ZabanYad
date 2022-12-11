using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editreplycommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Read",
                table: "ReplyComments",
                newName: "IsDelete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ReplyComments",
                newName: "Read");
        }
    }
}
