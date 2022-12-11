using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editepisodeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Courses_CourseId",
                table: "Episode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episode",
                table: "Episode");

            migrationBuilder.RenameTable(
                name: "Episode",
                newName: "Episodes");

            migrationBuilder.RenameIndex(
                name: "IX_Episode_CourseId",
                table: "Episodes",
                newName: "IX_Episodes_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Courses_CourseId",
                table: "Episodes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Courses_CourseId",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes");

            migrationBuilder.RenameTable(
                name: "Episodes",
                newName: "Episode");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_CourseId",
                table: "Episode",
                newName: "IX_Episode_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episode",
                table: "Episode",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Courses_CourseId",
                table: "Episode",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
