using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<long>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SubjectCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "ExamStudent",
                columns: table => new
                {
                    ExamsExamId = table.Column<long>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStudent", x => new { x.ExamsExamId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ExamStudent_Exams_ExamsExamId",
                        column: x => x.ExamsExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamSubject",
                columns: table => new
                {
                    ExamsExamId = table.Column<long>(type: "INTEGER", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSubject", x => new { x.ExamsExamId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_ExamSubject_Exams_ExamsExamId",
                        column: x => x.ExamsExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "Score", "StudentId", "SubjectId" },
                values: new object[] { 1L, 5, 1L, 1 });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "Score", "StudentId", "SubjectId" },
                values: new object[] { 2L, 8, 2L, 2 });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "Score", "StudentId", "SubjectId" },
                values: new object[] { 3L, 10, 3L, 3 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "DateOfBirth", "Email", "Name" },
                values: new object[] { 1L, "Nam Dinh", new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoatdfk2001@gmail.com", "Mai Huy B" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "DateOfBirth", "Email", "Name" },
                values: new object[] { 2L, "Nam Dinh", new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoatdfk2001@gmail.com", "Mai Huy A" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "DateOfBirth", "Email", "Name" },
                values: new object[] { 3L, "Nam Dinh", new DateTime(2001, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoatdfk2001@gmail.com", "Mai Huy C" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Description", "EndDate", "StartDate", "SubjectCode", "SubjectName" },
                values: new object[] { 1, "this is a language", new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "K203", "C start it program" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Description", "EndDate", "StartDate", "SubjectCode", "SubjectName" },
                values: new object[] { 2, "this is a language", new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "K204", "PHP program" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Description", "EndDate", "StartDate", "SubjectCode", "SubjectName" },
                values: new object[] { 3, "this is a language", new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "K205", "JAVA  program" });

            migrationBuilder.CreateIndex(
                name: "IX_ExamStudent_StudentId",
                table: "ExamStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSubject_SubjectId",
                table: "ExamSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamStudent");

            migrationBuilder.DropTable(
                name: "ExamSubject");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
