using System.ComponentModel.DataAnnotations.Schema;

namespace HareketRehberi.Domain.Models.Entities
{
    public class Question : BaseEntity
    {
        public int EvaluationId { get; set; }
        public string QuestionText { get; set; }

        [ForeignKey("EvaluationId")]
        public Evaluation Evaluation { get; set; }
    }
}
