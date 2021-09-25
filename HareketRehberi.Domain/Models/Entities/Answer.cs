using System.ComponentModel.DataAnnotations.Schema;

namespace HareketRehberi.Domain.Models.Entities
{
    public class Answer : BaseEntity
    {
        public string AnswerText { get; set; }
        public bool IsSurvey { get; set; }
        public bool? IsRightAnswer { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
