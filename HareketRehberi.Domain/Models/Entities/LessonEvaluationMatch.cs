using System.ComponentModel.DataAnnotations.Schema;

namespace HareketRehberi.Domain.Models.Entities
{
    public class LessonEvaluationMatch : BaseEntity
    {
        public int LessonId { get; set; }
        public int EvaluationId { get; set; }

        [ForeignKey("EvaluationId")]
        public Evaluation Evaluation { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
    }
}
