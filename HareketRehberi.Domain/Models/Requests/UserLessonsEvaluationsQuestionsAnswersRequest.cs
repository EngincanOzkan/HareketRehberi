using System;

namespace HareketRehberi.Domain.Models.Requests
{
    public class UserLessonsEvaluationsQuestionsAnswersRequest
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int EvaluationId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public bool IsSurvey { get; set; }
        public int RightAnswerId { get; set; }
        public Guid OperationIdentifier { get; set; } //UserLessonProgressLog ile aynı guid, ders sessionu ile sınavı bağlamak için
    }
}
