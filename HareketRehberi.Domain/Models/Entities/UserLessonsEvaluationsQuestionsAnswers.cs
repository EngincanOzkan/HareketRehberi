using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HareketRehberi.Domain.Models.Entities
{
    public class UserLessonsEvaluationsQuestionsAnswers : BaseEntity
    {
        public int LessonId { get; set; }
        public int EvaluationId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public int UserId { get; set; }
        public bool IsSurvey { get; set; }
        public int RightAnswerId { get; set; }
        public Guid OperationIdentifier { get; set; } //UserLessonProgressLog ile aynı guid, ders sessionu ile sınavı bağlamak için

        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
        [ForeignKey("EvaluationId")]
        public Evaluation Evaluation { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
