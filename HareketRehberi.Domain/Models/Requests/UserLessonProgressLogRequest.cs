using System;

namespace HareketRehberi.Domain.Models.Requests
{
    public class UserLessonProgressLogRequest
    {
        public int? Id { get; set; }
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public bool? IsStart { get; set; } //false is end
        public DateTime? OperationTime { get; set; }
        public Guid? OperationIdentifier { get; set; } // start log and end log must be same
    }
}
