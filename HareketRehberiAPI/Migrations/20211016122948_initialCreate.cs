using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace HareketRehberiAPI.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EvaluationName = table.Column<string>(nullable: true),
                    IsSurvey = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonName = table.Column<string>(nullable: true),
                    ProgressiveRelaxationExercise = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordKey = table.Column<byte[]>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EvaluationId = table.Column<int>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonEvaluationMatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonId = table.Column<int>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonEvaluationMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonEvaluationMatches_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonEvaluationMatches_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonPdfFileRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileGuid = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPdfFileRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonPdfFileRelations_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonSoundFileRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonId = table.Column<int>(nullable: false),
                    PageNumber = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileGuid = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonSoundFileRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonSoundFileRelations_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonUserMatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonUserMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonUserMatches_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonUserMatches_SystemUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLessonProgressLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsStart = table.Column<bool>(nullable: true),
                    OperationTime = table.Column<DateTime>(nullable: false),
                    OperationIdentifier = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessonProgressLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLessonProgressLogs_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLessonProgressLogs_SystemUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AnswerText = table.Column<string>(nullable: true),
                    IsSurvey = table.Column<bool>(nullable: false),
                    IsRightAnswer = table.Column<bool>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLessonsEvaluationsQuestionsAnswersTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LessonId = table.Column<int>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    IsSurvey = table.Column<bool>(nullable: false),
                    RightAnswerId = table.Column<int>(nullable: false),
                    OperationIdentifier = table.Column<byte[]>(nullable: false)
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
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonEvaluationMatches_EvaluationId",
                table: "LessonEvaluationMatches",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonEvaluationMatches_LessonId",
                table: "LessonEvaluationMatches",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPdfFileRelations_LessonId",
                table: "LessonPdfFileRelations",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonSoundFileRelations_LessonId",
                table: "LessonSoundFileRelations",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonUserMatches_LessonId",
                table: "LessonUserMatches",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonUserMatches_UserId",
                table: "LessonUserMatches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_EvaluationId",
                table: "Questions",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonProgressLogs_LessonId",
                table: "UserLessonProgressLogs",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonProgressLogs_UserId",
                table: "UserLessonProgressLogs",
                column: "UserId");

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
                name: "Answers");

            migrationBuilder.DropTable(
                name: "LessonEvaluationMatches");

            migrationBuilder.DropTable(
                name: "LessonPdfFileRelations");

            migrationBuilder.DropTable(
                name: "LessonSoundFileRelations");

            migrationBuilder.DropTable(
                name: "LessonUserMatches");

            migrationBuilder.DropTable(
                name: "UserLessonProgressLogs");

            migrationBuilder.DropTable(
                name: "UserLessonsEvaluationsQuestionsAnswersTable");

            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Evaluations");
        }
    }
}
