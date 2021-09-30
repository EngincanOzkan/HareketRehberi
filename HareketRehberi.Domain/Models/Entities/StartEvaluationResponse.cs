using System;
using System.Collections.Generic;

namespace HareketRehberi.Domain.Models.Entities
{
    public class StartEvaluationResponse : BaseEntity
    {
        public int UserLessonsEvaluationsQuestionsAnswersId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public Guid OperationIdentifier { get; set; } //UserLessonProgressLog ile aynı guid, ders sessionu ile sınavı bağlamak için
        public List<int> RightAnswers { get; set; } = new List<int>();
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
