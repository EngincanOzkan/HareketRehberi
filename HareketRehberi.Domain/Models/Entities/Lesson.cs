using System;
namespace HareketRehberi.Domain.Models.Entities
{
    public class Lesson : BaseEntity
    {
        public string LessonName { get; set; }
        public bool ProgressiveRelaxationExercise { get; set; }
    }
}
