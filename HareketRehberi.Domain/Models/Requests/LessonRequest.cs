
using System;

namespace HareketRehberi.Domain.Models.Requests
{
    public class LessonRequest
    {
        public int? Id { get; set; }
        public string LessonName { get; set; }
        public bool ProgressiveRelaxationExercise { get; set; }
    }
}
