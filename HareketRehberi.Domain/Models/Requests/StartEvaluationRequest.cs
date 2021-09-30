using System;

namespace HareketRehberi.Domain.Models.Requests
{
    public class StartEvaluationRequest
    {
        public int LessonId { get; set; }
        public int EvaluationId { get; set; }
        public int UserId { get; set; }
        public Guid OperationIdentifier { get; set; }
    }
}
