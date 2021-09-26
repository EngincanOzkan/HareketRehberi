using System.Collections.Generic;

namespace HareketRehberi.Domain.Models.Requests
{
    public class LessonUserMatchRequest
    {
        public int? Id { get; set; }
        public int LessonId { get; set; }
        public int? UserId { get; set; }
        public List<int> UserIds { get; set; } = new List<int>();
    }
}
