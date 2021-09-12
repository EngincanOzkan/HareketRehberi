using System.ComponentModel.DataAnnotations;

namespace HareketRehberi.Domain.Models.Requests
{
    public class EvaluationRequest
    {
        public int? Id { get; set; }
        public string EvaluationName { get; set; }
        public bool IsSurvey { get; set; }
    }
}
