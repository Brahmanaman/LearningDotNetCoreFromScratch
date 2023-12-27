using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningDotNetCoreFromScratch.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student_Table");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "StudentCourse_Table");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course_Table");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId",
                table: "StudentCourse_Table",
                newName: "IX_StudentCourse_Table_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "StudentCourse_Table",
                newName: "IX_StudentCourse_Table_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Table",
                table: "Student_Table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse_Table",
                table: "StudentCourse_Table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course_Table",
                table: "Course_Table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Table_Course_Table_CourseId",
                table: "StudentCourse_Table",
                column: "CourseId",
                principalTable: "Course_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Table_Student_Table_StudentId",
                table: "StudentCourse_Table",
                column: "StudentId",
                principalTable: "Student_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Table_Course_Table_CourseId",
                table: "StudentCourse_Table");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Table_Student_Table_StudentId",
                table: "StudentCourse_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse_Table",
                table: "StudentCourse_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Table",
                table: "Student_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course_Table",
                table: "Course_Table");

            migrationBuilder.RenameTable(
                name: "StudentCourse_Table",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Student_Table",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Course_Table",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_Table_StudentId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_Table_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
