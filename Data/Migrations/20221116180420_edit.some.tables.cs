using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class editsometables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseGroups_MainGroupId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseGroups_SubGroupId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseLevels_CourseLevelLevelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseStatuses_CourseStatusStatusId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseLevels");

            migrationBuilder.DropTable(
                name: "CourseStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseLevelLevelId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseStatusStatusId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_MainGroupId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SubGroupId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseLevelLevelId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseStatusStatusId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Courses",
                newName: "CourseStatus");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "Courses",
                newName: "CourseLevel");

            migrationBuilder.CreateTable(
                name: "CourseToGroups",
                columns: table => new
                {
                    CG_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseToGroups", x => x.CG_Id);
                    table.ForeignKey(
                        name: "FK_CourseToGroups_CourseGroups_CourseGroupId",
                        column: x => x.CourseGroupId,
                        principalTable: "CourseGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseToGroups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseToGroups_CourseGroupId",
                table: "CourseToGroups",
                column: "CourseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseToGroups_CourseId",
                table: "CourseToGroups",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseToGroups");

            migrationBuilder.RenameColumn(
                name: "CourseStatus",
                table: "Courses",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "CourseLevel",
                table: "Courses",
                newName: "LevelId");

            migrationBuilder.AddColumn<int>(
                name: "CourseLevelLevelId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseStatusStatusId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseLevels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    LevelTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "CourseStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StatusTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseLevelLevelId",
                table: "Courses",
                column: "CourseLevelLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseStatusStatusId",
                table: "Courses",
                column: "CourseStatusStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_MainGroupId",
                table: "Courses",
                column: "MainGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubGroupId",
                table: "Courses",
                column: "SubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseGroups_MainGroupId",
                table: "Courses",
                column: "MainGroupId",
                principalTable: "CourseGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseGroups_SubGroupId",
                table: "Courses",
                column: "SubGroupId",
                principalTable: "CourseGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseLevels_CourseLevelLevelId",
                table: "Courses",
                column: "CourseLevelLevelId",
                principalTable: "CourseLevels",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseStatuses_CourseStatusStatusId",
                table: "Courses",
                column: "CourseStatusStatusId",
                principalTable: "CourseStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
