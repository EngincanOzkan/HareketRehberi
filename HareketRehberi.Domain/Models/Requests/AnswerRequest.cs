namespace HareketRehberi.Domain.Models.Requests
{
    public class AnswerRequest
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool? IsSurvey { get; set; }
        public bool? IsRightAnswer { get; set; }
        public int QuestionId { get; set; }
    }
}
