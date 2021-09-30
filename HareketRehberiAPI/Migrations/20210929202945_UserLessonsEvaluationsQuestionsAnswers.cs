using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace HareketRehberiAPI.Migrations
{
    public partial class UserLessonsEvaluationsQuestionsAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLessonsEvaluationsQuestionsAnswersTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsSurvey = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RightAnswerId = table.Column<int>(type: "int", nullable: false),
                    OperationIdentifier = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessonsEvaluationsQuestionsAnswersTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLessonsEvaluationsQuestionsAnswersTable_Evaluations_Eval~",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLessonsEvaluationsQuestionsAnswersTable_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLessonsEvaluationsQuestionsAnswersTable_Questions_Questi~",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonsEvaluationsQuestionsAnswersTable_EvaluationId",
                table: "UserLessonsEvaluationsQuestionsAnswersTable",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonsEvaluationsQuestionsAnswersTable_LessonId",
                table: "UserLessonsEvaluationsQuestionsAnswersTable",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonsEvaluationsQuestionsAnswersTable_QuestionId",
                table: "UserLessonsEvaluationsQuestionsAnswersTable",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLessonsEvaluationsQuestionsAnswersTable");
        }
    }
}
