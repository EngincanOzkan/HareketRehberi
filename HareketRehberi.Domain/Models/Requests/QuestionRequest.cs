namespace HareketRehberi.Domain.Models.Requests
{
    public class QuestionRequest
    {
        public int? Id { get; set; }
        public int EvaluationId { get; set; }
        public string QuestionText { get; set; }
    }
}
