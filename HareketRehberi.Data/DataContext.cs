using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HareketRehberi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonPdfFileRelation> LessonPdfFileRelations { get; set; }
        public DbSet<LessonSoundFileRelation> LessonSoundFileRelations { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<LessonEvaluationMatch> LessonEvaluationMatches { get; set; }
        public DbSet<LessonUserMatch> LessonUserMatches { get; set; }
        public DbSet<UserLessonProgressLog> UserLessonProgressLogs { get; set; }
        public DbSet<UserLessonsEvaluationsQuestionsAnswers> UserLessonsEvaluationsQuestionsAnswersTable { get; set; }
    }
}
