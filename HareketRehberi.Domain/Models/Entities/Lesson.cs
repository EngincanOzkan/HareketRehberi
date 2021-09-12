using System;
using System.ComponentModel.DataAnnotations;

namespace HareketRehberi.Domain.Models.Entities
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        public string LessonName { get; set; }
        public bool ProgressiveRelaxationExercise { get; set; }
    }
}
