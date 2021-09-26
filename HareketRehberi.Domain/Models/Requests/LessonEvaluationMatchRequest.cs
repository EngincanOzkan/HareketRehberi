namespace HareketRehberi.Domain.Models.Requests
{
    public class LessonEvaluationMatchRequest
    {
        public int? Id { get; set; }
        public int LessonId { get; set; }
        public int EvaluationId { get; set; }
    }
}
