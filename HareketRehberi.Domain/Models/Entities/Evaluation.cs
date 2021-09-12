using System.ComponentModel.DataAnnotations;

namespace HareketRehberi.Domain.Models.Entities
{
    public class Evaluation
    {
        [Key]
        public int Id { get; set; }
        public string EvaluationName { get; set; }
        public bool IsSurvey { get; set; }
    }
}
